using Presupuesto_space;
using PresupuestoRepository_space;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Presupuesto")]
public class PresupuestosController : ControllerBase
{
    private PresupuestoRepository prere = new PresupuestoRepository();

    [HttpPost("Crear_Presupuesto")]
    public IActionResult AltaPresupuesto(Presupuesto presupuesto)
    {
        int cant = prere.CrearPresupuesto(presupuesto);
        if (cant != 0) return Created();
        else return BadRequest();
    }

    [HttpGet("Obtener_Presupuestos")]
    public IActionResult ListarPresupuestos()
    {
        return Ok(prere.ListarPresupuestos());
    }

    [HttpGet("Detalle_Presupuesto")]
    public IActionResult DetallePresupuesto(int id)
    {
        Presupuesto p = prere.DetallePresupuesto(id);
        if(p != null)
        {
            return Ok(p);
        }
        else return NotFound();
    }

    [HttpPost("Agregar_Producto")]
    public IActionResult AgregarProducto(int idPresupuesto, int idProducto, int cantidad)
    {
        int i = prere.AgregarProducto(idPresupuesto, idProducto, cantidad);
        if(i != 0) return Accepted();
        else return BadRequest();
    }

    [HttpPost("Eliminar_Presupuesto")]
    public IActionResult EliminarPresupuesto(int id)
    {
        int i = prere.EliminarPresupuesto(id);
        if(i != 0) return Accepted();
        else return BadRequest();
    }
}