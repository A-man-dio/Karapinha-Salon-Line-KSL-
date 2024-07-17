using KSL_API.DAL;
using KSL_API.DTO.Servico;
using KSL_API.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace KSL.Controllers;
[Route("api/servico")]
[ApiController]
public class ServicosController : ControllerBase
{
    private readonly AppDbContext _context;
    public ServicosController(AppDbContext context )
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var servicos = _context.Servico.ToList();
        return Ok(servicos);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var servico = _context.Servico.Find(id);
        if (servico == null)
        {
            return NotFound();
        }
        return Ok(servico);
    }
    
    [HttpPost] 
    public IActionResult Create([FromBody] CreateServicoDTO servico_DTO)
    {  
        var servicoModel = servico_DTO.ToServicoFromCreatedDTO();
        
        if(_context.Servico.Any(s => s.Nome == servico_DTO.Nome)){
            return BadRequest("Nome de servico já se encontra em uso, insira um outro"); 
        }
        if(_context.Categoria.Find(servico_DTO.IdCategoria) == null){
            return BadRequest("Insira um ID existente para a categoria");
        }
        _context.Servico.Add(servicoModel);
        _context.SaveChanges();
        return (CreatedAtAction(nameof(GetById), new { id = servicoModel.IdServico },
            servicoModel));
    }
    
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateServicoDTO updateDTO)
    {   //busco o utilizador pelo ID
        var servicoModel = _context.Servico.FirstOrDefault(x => x.IdServico == id);

        if (servicoModel == null)
        {
            return NotFound();
        }
        //apresenta o json do elemento que quero alterar, e permite reinserir os dados 
        servicoModel.Nome = updateDTO.Nome;
        servicoModel.IdCategoria = updateDTO.IdCategoria;
        servicoModel.Descricao = updateDTO.Descricao;
        servicoModel.Preco = updateDTO.Preco;
        if(_context.Servico.Any(s => s.Nome == updateDTO.Nome && s.IdServico != id )){
            return BadRequest("Nome de servico já se encontra em uso, insira um outro"); 
        }

        if(_context.Categoria.Find(updateDTO.IdCategoria) == null){
            return BadRequest("Insira um ID existente para a categoria");
        }
        _context.SaveChanges();
        
        return Ok(servicoModel);
    }
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var servicoModel = _context.Servico.FirstOrDefault(x => x.IdServico == id);

        if (servicoModel == null)
        {
            return NotFound();
        }

        _context.Servico.Remove(servicoModel);
        _context.SaveChanges();
        return NoContent();
    }
    
}