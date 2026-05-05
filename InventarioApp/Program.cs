// ============================================================
// SISTEMA DE GESTION DE INVENTARIO
// App de consola con operaciones CRUD en memoria.
// ============================================================

using InventarioApp.Services;

var inventario = new InventarioService();
SembrarDatosDeEjemplo(inventario);

while (true)
{
    MostrarMenu();
    Console.Write("Seleccione una opcion: ");
    var opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            ListarProductos();
            break;
        case "2":
            AgregarProducto();
            break;
        case "3":
            ActualizarCantidad();
            break;
        case "4":
            EliminarProducto();
            break;
        case "5":
            Console.WriteLine($"\nValor total del inventario: ${inventario.ValorTotalInventario():N2}");
            break;
        case "0":
            Console.WriteLine("Hasta luego!");
            return;
        default:
            Console.WriteLine("Opcion invalida.");
            break;
    }
}

void MostrarMenu()
{
    Console.WriteLine();
    Console.WriteLine("==========================================");
    Console.WriteLine("    SISTEMA DE GESTION DE INVENTARIO      ");
    Console.WriteLine("==========================================");
    Console.WriteLine("1. Listar productos");
    Console.WriteLine("2. Agregar producto");
    Console.WriteLine("3. Actualizar cantidad");
    Console.WriteLine("4. Eliminar producto");
    Console.WriteLine("5. Ver valor total del inventario");
    Console.WriteLine("0. Salir");
}

void ListarProductos()
{
    var productos = inventario.ListarTodos();
    Console.WriteLine("\n--- PRODUCTOS ---");
    if (productos.Count == 0)
    {
        Console.WriteLine("(sin productos)");
        return;
    }
    foreach (var p in productos)
        Console.WriteLine(p);
}

void AgregarProducto()
{
    try
    {
        Console.Write("Nombre: ");
        var nombre = Console.ReadLine() ?? "";
        Console.Write("Precio: ");
        var precio = decimal.Parse(Console.ReadLine() ?? "0");
        Console.Write("Cantidad: ");
        var cantidad = int.Parse(Console.ReadLine() ?? "0");

        var producto = inventario.Agregar(nombre, precio, cantidad);
        Console.WriteLine($"Producto agregado: {producto}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

void ActualizarCantidad()
{
    try
    {
        Console.Write("Id del producto: ");
        var id = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Nueva cantidad: ");
        var cantidad = int.Parse(Console.ReadLine() ?? "0");

        Console.WriteLine(inventario.ActualizarCantidad(id, cantidad)
            ? "Cantidad actualizada."
            : "Producto no encontrado.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

void EliminarProducto()
{
    try
    {
        Console.Write("Id del producto: ");
        var id = int.Parse(Console.ReadLine() ?? "0");
        Console.WriteLine(inventario.Eliminar(id)
            ? "Producto eliminado."
            : "Producto no encontrado.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

void SembrarDatosDeEjemplo(InventarioService servicio)
{
    servicio.Agregar("Teclado mecanico", 120000m, 15);
    servicio.Agregar("Mouse inalambrico", 65000m, 30);
    servicio.Agregar("Monitor 24 pulgadas", 550000m, 8);
}
