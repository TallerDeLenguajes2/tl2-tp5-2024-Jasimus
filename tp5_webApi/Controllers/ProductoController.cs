using Microsoft.AspNetCore.Mvc;
using ProductoRepository_space;
using Producto_space;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("Producto")]
public class ProductoController : ControllerBase
{
    private ProductoRepository pr = new ProductoRepository();

    [HttpPost("Alta_Producto")]
    public IActionResult AltaProducto(Producto producto)
    {
        int cant = pr.CrearProducto(producto);
        if (cant != 0) return Created();
        else return BadRequest();
    }

    [HttpPut("Modificar_Producto")]
    public IActionResult ModificarProducto(int id, string descripcion)
    {
        try
        {
            Producto producto = pr.ListarProductos().Single(p => p.IdProducto == id);
            producto.Descripcion = descripcion;
            int cant = pr.ModificarProducto(id, producto);
            if(cant != 0) return Accepted();
            else return BadRequest();
        }
        catch(InvalidOperationException)
        {
            return BadRequest();
        }
    }

    [HttpGet("Obtener_Productos")]
    public IActionResult ListarProductos()
    {
        return Ok(pr.ListarProductos());
    }

    [HttpGet("detalle_Producto")]

    public IActionResult DetalleProducto(int id)
    {
        Producto p = pr.ObtenerProducto(id);
        if (p != null)
        {
            return Ok(p);
        }
        else return NotFound();
    }

    [HttpPost("Eliminar_Producto")]
    
    public IActionResult EliminarProducto(int id)
    {
        int cant = pr.EliminarProducto(id);
        if(cant != 0) return Accepted();
        else return NotFound();
    }
}