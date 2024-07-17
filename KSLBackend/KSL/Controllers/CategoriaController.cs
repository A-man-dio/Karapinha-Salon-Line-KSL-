using KSL_API.DAL;
using KSL_API.DTO.Categoria;
using KSL_API.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace KSL.Controllers;

[Route("api/categoria")]
[ApiController]

public class CategoriaController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public CategoriaController(AppDbContext context )
    {
        _context = context;
    }

    [HttpGet] //recebe da BD e manda para o front 
    public IActionResult GetAll() 
    {
        var categoria = _context.Categoria.ToList();
        return Ok(categoria);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var categoria = _context.Categoria.Find(id);
        if (categoria == null)
        {
            return NotFound();
        }
        return Ok(categoria);
    }
    [HttpPost] 
    public IActionResult Create([FromBody] CreateCategoriaDTO categoria_DTO)
    {
        var categoriaModel = categoria_DTO.ToCategoriaFromCreatedDTO();
        if(_context.Categoria.Any(c => c.Nome == categoria_DTO.Nome)){
            return BadRequest("Nome de categoria já se encontra em uso, insira um outro"); 
        }
        _context.Categoria.Add(categoriaModel);
        _context.SaveChanges();
        return (CreatedAtAction(nameof(GetById), new { id = categoriaModel.IdCategoria },
            categoriaModel));
    } 
    
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateCategoriaDTO updateDTO)
    {   //busco o utilizador pelo ID
        var categoriaModel = _context.Categoria.FirstOrDefault(x => x.IdCategoria== id);

        if (categoriaModel == null)
        {
            return NotFound();
        }

        if(_context.Categoria.Any(c => c.Nome == updateDTO.Nome && c.IdCategoria != id)){
            return BadRequest("Nome de categoria já se encontra em uso, insira um outro"); 
        }
        //apresenta o json do elemento que quero alterar, e permite reinserir os dados 
        categoriaModel.Nome = updateDTO.Nome;
        _context.SaveChanges();
        return Ok(categoriaModel);
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var categoriaModel = _context.Categoria.FirstOrDefault(x => x.IdCategoria== id);

        if (categoriaModel == null)
        {
            return NotFound();
        }

        _context.Categoria.Remove(categoriaModel);
        _context.SaveChanges();
        return NoContent();
    }
}