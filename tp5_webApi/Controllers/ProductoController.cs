using Microsoft.AspNetCore.Mvc;
using ProductoRepository_space;
using Producto_space;
using System.ComponentModel.DataAnnotations;

[ApiController]
[Route("Producto")]
public class ProductoController : ControllerBase
{
    private ProductoRepository pr = new ProductoRepository();

    [HttpPost(Name = "Alta_Producto")]
    public ActionResult AltaProducto(Producto producto)
    {
        int cant = pr.CrearProducto(producto);
        if (cant != 0) return Created();
        else return BadRequest();
    }

    [HttpPut(Name = "Modificar_Producto")]
    public ActionResult ModificarProducto(int id, Producto producto)
    {
        int cant = pr.ModificarProducto(id, producto);
        if(cant != 0) return Accepted();
        else return BadRequest();
    }

    [HttpGet(Name = "Obtener_Productos")]
    public ActionResult ListarProductos()
    {
        return Ok(pr.ListarProductos());
    }

    [HttpGet(Name = "detalle_Producto")]

    public ActionResult DetalleProducto(int id)
    {
        return Ok(pr.ObtenerProducto(id));
    }

    [HttpPost(Name = "Eliminar_Producto")]
    
    public ActionResult EliminarProducto(int id)
    {
        int cant = pr.EliminarProducto(id);
        if(cant != 0) return Accepted();
        else return NotFound();
    }
}