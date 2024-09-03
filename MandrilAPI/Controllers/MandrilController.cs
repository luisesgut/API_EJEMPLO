using MandrilAPI.Helpers;
using MandrilAPI.Models;
using MandrilAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MandrilController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Mandril>> GetMandriles()
    {
        return Ok(MandrilDataStore.current.Mandriles);
    }

    [HttpGet("{mandrilId}")]
    public ActionResult<Mandril> GetMandril(int mandrilId)
    {
        var mandril = MandrilDataStore.current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.MandrilNoEncontrado);


        }
        return Ok(mandril);
    }

    [HttpPost]
    public ActionResult<Mandril> PostMandril(MandrilInsert mandrilInsert)
    {
        var MaxMandrilId = MandrilDataStore.current.Mandriles.Max(x => x.Id);

        var mandrilNuevo = new Mandril()
        {
            Id = MaxMandrilId + 1,
            Nombre = mandrilInsert.Nombre,
            Apellido = mandrilInsert.Apellido
        };

        MandrilDataStore.current.Mandriles.Add(mandrilNuevo);

        return CreatedAtAction(nameof(GetMandril),
            new { mandrilID = mandrilNuevo.Id },
            mandrilNuevo);



    }
    [HttpPut("{mandrilId}")]

    public ActionResult<Mandril> PutMandril([FromRoute]int mandrilId, [FromBody] MandrilInsert mandrilInsert)
    {
        var mandril = MandrilDataStore.current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)

            return NotFound(Mensajes.Mandril.MandrilNoEncontrado);


        mandril.Nombre = mandrilInsert.Nombre;
            mandril.Apellido = mandrilInsert.Apellido;  

            return NoContent();
    }

    [HttpDelete("{mandrilId}")]

    public ActionResult<Mandril> DeleteMandril (int mandrilId)
    {
        var mandril = MandrilDataStore.current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

        if (mandril == null)

            return NotFound(Mensajes.Mandril.MandrilNoEncontrado);

        //MandrilDataStore.current.Mandriles.Remove(mandril);
        MandrilDataStore.current.Mandriles.RemoveAll(x => x.Id == mandrilId);
        return NoContent();
    }
}
