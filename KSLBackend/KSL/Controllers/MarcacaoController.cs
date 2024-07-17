using KSL_API.DAL;
using KSL_API.DTO.Marcacao;
using KSL_API.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KSL.Controllers;
[Route("api/marcacao")]
[ApiController]

public class MarcacaoController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public MarcacaoController(AppDbContext context )
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var marcacao = _context.Marcacao.Include(m => m.ServicosMarcados).ToList();
        return Ok(marcacao);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var marcacao = _context.Marcacao.Include(m => m.ServicosMarcados).
            FirstOrDefault(i => i.IdMarcacao == id);
        if (marcacao == null)
        {
            return NotFound();
        }
        return Ok(marcacao);
    }
    
    [HttpPost] 
    public IActionResult Create([FromBody] CreateMarcacaoDTO marcacao_DTO)
    {
        try
        {
            var marcacaoModel = marcacao_DTO.ToMarcacaoFromCreatedDTO();

            if(_context.Utilizador.Find(marcacao_DTO.IdUtilizador) == null){
                return BadRequest("Insira um ID existente para o Utilizador associado a marcação");
            }

            if(_context.Categoria.Find(marcacao_DTO.IdCategoria) == null){
                return BadRequest("Insira um ID existente para a categoria");
            }

            _context.Marcacao.Add(marcacaoModel);
            _context.SaveChanges();
        
            return CreatedAtAction(nameof(GetById), new { id = marcacaoModel.IdMarcacao }, marcacaoModel);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao criar a marcação: {ex.Message}");
        }
    }
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateMarcacaoDTO updateDTO)
    {   //busco o utilizador pelo ID
        var marcacaoModel = _context.Marcacao.FirstOrDefault(x => x.IdMarcacao== id);

        if (marcacaoModel == null)
        {
            return NotFound();
        }
        //apresenta o json do elemento que quero alterar, e permite reinserir os dados 
        marcacaoModel.IdUtilizador = updateDTO.IdUtilizador;
        marcacaoModel.IdCategoria = updateDTO.IdCategoria;
        marcacaoModel.Data = updateDTO.Data;
        marcacaoModel.Hora = updateDTO.Hora;
        
        if(_context.Utilizador.Find(updateDTO.IdUtilizador) == null){
            return BadRequest("Insira um ID existente para o Utilizador associado a marcação");
        }

        if(_context.Categoria.Find(updateDTO.IdCategoria) == null){
            return BadRequest("Insira um ID existente para a categoria");
        }
        
        _context.SaveChanges();
        
        return Ok(marcacaoModel);
    }
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var marcacaoModel = _context.Marcacao.FirstOrDefault(x => x.IdMarcacao== id);

        if (marcacaoModel == null)
        {
            return NotFound();
        }

        _context.Marcacao.Remove(marcacaoModel);
        _context.SaveChanges();
        return NoContent();
    }
}