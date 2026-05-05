using InventarioApp.Models;

namespace InventarioApp.Services;

/// <summary>
/// Gestiona el inventario de productos en memoria.
/// </summary>
public class InventarioService
{
    private readonly List<Producto> _productos = new();
    private int _siguienteId = 1;

    public Producto Agregar(string nombre, decimal precio, int cantidad)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre no puede estar vacio.");
        if (precio < 0)
            throw new ArgumentException("El precio no puede ser negativo.");
        if (cantidad < 0)
            throw new ArgumentException("La cantidad no puede ser negativa.");

        var producto = new Producto(_siguienteId++, nombre.Trim(), precio, cantidad);
        _productos.Add(producto);
        return producto;
    }

    public IReadOnlyList<Producto> ListarTodos() => _productos.AsReadOnly();

    public Producto? BuscarPorId(int id) => _productos.FirstOrDefault(p => p.Id == id);

    public bool ActualizarCantidad(int id, int nuevaCantidad)
    {
        if (nuevaCantidad < 0)
            throw new ArgumentException("La cantidad no puede ser negativa.");

        var producto = BuscarPorId(id);
        if (producto is null)
            return false;

        producto.Cantidad = nuevaCantidad;
        return true;
    }

    public bool Eliminar(int id)
    {
        var producto = BuscarPorId(id);
        if (producto is null)
            return false;

        _productos.Remove(producto);
        return true;
    }

    public decimal ValorTotalInventario() => _productos.Sum(p => p.ValorTotal);
}
