using KSL_API.DAL;
using KSL_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace KSL.Controllers;

[Route("api/horario")]
[ApiController]

public class HorarioController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public HorarioController(AppDbContext context )
    {
        _context = context;
    }

    [HttpGet] //recebe da BD e manda para o front 
    public IActionResult GetAll() 
    {
        var horario = _context.Horario.ToList();
        return Ok(horario);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var horario = _context.Horario.Find(id);
        if (horario == null)
        {
            return NotFound();
        }
        return Ok(horario);
    }
    [HttpPost] 
    public IActionResult Create([FromBody] Horario horario)
    {
        _context.Horario.Add(horario);
        _context.SaveChanges();
        return (CreatedAtAction(nameof(GetById), new { id = horario.IdHorario },
            horario));
    }
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var horarioModel = _context.Horario.FirstOrDefault(x => x.IdHorario== id);

        if (horarioModel == null)
        {
            return NotFound();
        }

        _context.Horario.Remove(horarioModel);
        _context.SaveChanges();
        return NoContent();
    }
}