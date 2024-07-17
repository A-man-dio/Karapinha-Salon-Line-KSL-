
using KSL_API.DAL;
using KSL_API.DTO.Profissional;
using KSL_API.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace KSL.Controllers;

[Route("api/profissional")]
[ApiController]
public class ProfissionalController: ControllerBase
{
    private readonly AppDbContext _context;
    
    public ProfissionalController(AppDbContext context )
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var profissional = _context.Profissional.ToList();
        
        return Ok(profissional);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var profissional = _context.Profissional.Find(id);
        if (profissional == null)
        {
            return NotFound();
        }
        return Ok(profissional);
    }
    
    [HttpPost] 
    public IActionResult Create([FromBody] CreateProfissionalDTO profissional_DTO)
    {
        var profissionalModel = profissional_DTO.ToProfissionalFromCreatedDTO();
        if(_context.Servico.Find(profissionalModel.IdServico) == null){
            return BadRequest("Insira um ID existente para o servico designado ao profissional");
        }
        _context.Profissional.Add(profissionalModel);
        _context.SaveChanges();
        return (CreatedAtAction(nameof(GetById), new { id = profissionalModel.IdProfissional },
            profissionalModel));
    }
    
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateProfissionalDTO updateDTO)
    {   //busco o utilizador pelo ID
        var profissionalModel = _context.Profissional.FirstOrDefault(x => x.IdProfissional == id);

        if (profissionalModel == null)
        {
            return NotFound();
        }
        //apresenta o json do elemento que quero alterar, e permite reinserir os dados 
        profissionalModel.Nome = updateDTO.Nome;
        profissionalModel.IdServico = updateDTO.IdServico;
        profissionalModel.Email = updateDTO.Email;
        profissionalModel.Telemovel = updateDTO.Telemovel;
        profissionalModel.BI = updateDTO.BI;
        if(_context.Servico.Find(updateDTO.IdServico) == null){
            return BadRequest("Insira um ID existente para o servico designado ao profissional");
            // return NotFound();
        }
        _context.SaveChanges();
        
        return Ok(profissionalModel);
    }
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var profissionalModel = _context.Profissional.FirstOrDefault(x => x.IdProfissional == id);

        if (profissionalModel == null)
        {
            return NotFound();
        }

        _context.Profissional.Remove(profissionalModel);
        _context.SaveChanges();
        return NoContent();
    }
}