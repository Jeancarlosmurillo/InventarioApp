# Sistema de Gestión de Inventario

Aplicación de consola en **C# / .NET 8** para gestionar un inventario de productos (operaciones CRUD en memoria). Proyecto del curso **Fundamentos de .NET**.

## Requisitos

- .NET 8 SDK

## Cómo ejecutar

```bash
cd InventarioApp
dotnet run
```

## Funcionalidades

- Listar productos
- Agregar producto (nombre, precio, cantidad) con validaciones
- Actualizar la cantidad de un producto
- Eliminar un producto
- Calcular el valor total del inventario

## Estructura del proyecto

```
InventarioApp/
├── Inventario.sln
└── InventarioApp/
    ├── Program.cs                     # Punto de entrada y menú de consola
    ├── Models/Producto.cs             # Entidad Producto
    ├── Services/InventarioService.cs  # Lógica del inventario
    └── InventarioApp.csproj           # Configuración del proyecto
```
