using KSL_API.DAL;
using KSL_API.DTO.Utilizador;
using KSL_API.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace KSL.Controllers;

[Route("api/utilizador")]
[ApiController]
public class UtilizadorController : ControllerBase
{
    
    private readonly AppDbContext _context;
    
    public UtilizadorController(AppDbContext context )
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var utilizador = _context.Utilizador.ToList()
            .Select(s => s.ToUtilizadorDto());
        return Ok(utilizador);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var utilizador = _context.Utilizador.Find(id);
        if (utilizador == null)
        {
            return NotFound();
        }
        return Ok(utilizador.ToUtilizadorDto());
    }
    
    [HttpPost] //recebe do front e manda para a BD
    public IActionResult Create([FromBody] CreateUtilizadorDTO Utilizador_DTO)
    {
        var utilizadorModel = Utilizador_DTO.ToUtilizadorFromCreatedDTO();
        if(_context.Utilizador.Any(u => u.Username == Utilizador_DTO.Username)){
            return BadRequest("Username já se encontra em uso, insira um outro"); 
        }
        _context.Utilizador.Add(utilizadorModel);
        _context.SaveChanges();
        return (CreatedAtAction(nameof(GetById), new { id = utilizadorModel.IdUtilizador },
            utilizadorModel.ToUtilizadorDto()));
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UtilizadorUpdateDTO updateDTO)
    {   //busco o utilizador pelo ID
        var utilizadorModel = _context.Utilizador.FirstOrDefault(x => x.IdUtilizador == id);

        if (utilizadorModel == null)
        {
            return NotFound();
        }
        //apresenta o json do elemento que quero alterar, e permite reinserir os dados 
            utilizadorModel.NomeCompleto = updateDTO.NomeCompleto;
            utilizadorModel.Email = updateDTO.Email;
            utilizadorModel.Telemovel = updateDTO.Telemovel;
            utilizadorModel.BI = updateDTO.BI;
            utilizadorModel.Username = updateDTO.Username;
            utilizadorModel.Password = updateDTO.Password;
            
        if(_context.Utilizador.Any(u => u.Username == updateDTO.Username && u.IdUtilizador != id)){
            return BadRequest("Username já se encontra em uso, insira um outro"); 
        }
        _context.SaveChanges();
        return Ok(utilizadorModel.ToUtilizadorDto());
    }
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var utilizadorModel = _context.Utilizador.FirstOrDefault(x => x.IdUtilizador == id);

        if (utilizadorModel == null)
        {
            return NotFound();
        }

        _context.Utilizador.Remove(utilizadorModel);
        _context.SaveChanges();
        return NoContent();
    }
}