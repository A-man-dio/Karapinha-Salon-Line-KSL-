using KSL_API.DAL;
using KSL_API.DTO.ItenMarcacao;
using KSL_API.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace KSL.Controllers;
[Route("api/itenMarcacao")]
[ApiController]
public class ItenMarcacaoConroller : ControllerBase
{
    private readonly AppDbContext _context;
    
    public ItenMarcacaoConroller(AppDbContext context )
    {
        _context = context;
    }

    [HttpGet] //recebe da BD e manda para o front 
    public IActionResult GetAll() 
    {
        var itenMarcacao = _context.ItenMarcacao.ToList();
        return Ok(itenMarcacao);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var itenMarcacao = _context.ItenMarcacao.Find(id);
        if (itenMarcacao == null)
        {
            return NotFound();
        }
        return Ok(itenMarcacao);
    }   
    
    [HttpPost("{idMarcacao}")]
    public IActionResult Create([FromRoute] int idMarcacao,[FromBody] CreateItenMarcacaoDTO itenM_DTO){
        if(_context.Marcacao.Find(idMarcacao) == null)
        {
            return BadRequest("Id de marcação inválido");
        }

        var itenM_Model = itenM_DTO.ToItenMarcacaoFromCreatedDTO(idMarcacao);
        
        if(_context.Servico.Find(itenM_DTO.IdServico) == null) 
        {
            return BadRequest("Id de servico inválido");
        }
        
        if(_context.Profissional.Find(itenM_DTO.IdProfissional) == null)
        {
            return BadRequest("Id de profissional inválido");
        }
        
        _context.ItenMarcacao.Add(itenM_Model);
        _context.SaveChanges();
        
        return (CreatedAtAction(nameof(GetById), new { id = itenM_Model.IdIten },
            itenM_Model));
    }
}