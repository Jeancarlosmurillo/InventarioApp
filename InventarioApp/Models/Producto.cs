namespace InventarioApp.Models;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }

    public Producto(int id, string nombre, decimal precio, int cantidad)
    {
        Id = id;
        Nombre = nombre;
        Precio = precio;
        Cantidad = cantidad;
    }

    public decimal ValorTotal => Precio * Cantidad;

    public override string ToString()
        => $"#{Id,-3} {Nombre,-25} ${Precio,12:N2}  x{Cantidad,-5} = ${ValorTotal,14:N2}";
}
