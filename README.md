# Laboratorio # [Número] – CRUD de Productos en C#

📅 **Fecha:** 24/09/2026

## 📋 Contenido del Repositorio

Aplicación de escritorio en **C# (Windows Forms)** que implementa un **CRUD** (Crear, Leer, Actualizar y Eliminar) de productos conectado a una base de datos **MySQL**. Cada producto tiene nombre, precio, cantidad e imagen.

La práctica aplica los conceptos de Programación Orientada a Objetos vistos en clase:

- **Interfaces:** la validación de campos se hace con la interfaz `IValidadorCampo`, implementada por `ValidadorTexto`, `ValidadorDecimal` y `ValidadorEntero` (polimorfismo).
- **Consultas seguras:** los métodos `InsertSeguro`, `UpdateSeguro` y `DeleteSeguro` usan consultas parametrizadas para evitar la inyección SQL.
- **Eventos del DataGridView:** al hacer clic en una fila, los datos del producto se cargan en el formulario para modificarlo o eliminarlo.

## 🛠️ Tecnologías Utilizadas

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white)
![Git](https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white)

- **Lenguaje / Framework:** C# con Windows Forms (.NET)
- **Base de datos:** MySQL
- **Librería de conexión:** MySqlConnector (paquete NuGet)
- **Herramientas:** Visual Studio, Git, GitHub, [WampServer / XAMPP / MySQL Workbench]

## 🖥️ Capturas de Pantalla y Problemas

### Interfaz Principal

![Interfaz principal](capturas/interfaz-principal.png)

### Problemas / Ejercicios resueltos

- **Ejercicio 1 – Guardar producto:** valida los campos, convierte la imagen a un arreglo de bytes y guarda el registro con `InsertSeguro`. Después refresca el grid y limpia el formulario.

  ![Guardar producto](capturas/guardar.png)

- **Ejercicio 2 – Seleccionar y modificar producto:** con el evento `CellClick` del `DataGridView`, los datos de la fila se cargan en el formulario. Al presionar **Modificar** se actualiza el registro por su `id` con `UpdateSeguro`.

  ![Modificar producto](capturas/modificar.png)

- **Ejercicio 3 – Eliminar producto:** pide confirmación y elimina el registro seleccionado con `DeleteSeguro`.

  ![Eliminar producto](capturas/eliminar.png)

- **Ejercicio 4 – Búsqueda en vivo:** mientras se escribe en el campo de búsqueda, el grid se filtra por id, nombre, precio o cantidad.

  ![Búsqueda](capturas/busqueda.png)

- **Ejercicio 5 – Validación con interfaces:** cada campo tiene su validador y los errores se muestran con un `ErrorProvider` junto al campo. Estas son las reglas:
  - **Nombre:** obligatorio. Se escribe siempre en **MAYÚSCULAS**, aunque el usuario teclee en minúscula.
  - **Precio:** número decimal válido, mayor o igual a 0.
  - **Cantidad:** número entero válido, mayor o igual a 0.

  ![Validaciones](capturas/validaciones.png)

## 📁 Estructura de Carpetas o Directorios

```plaintext
CRUD_PRODUCTOS/
├── CRUD_PRODUCTOS.sln          # Solución de Visual Studio
├── CRUD_PRODUCTOS/
│   ├── Program.cs              # Punto de entrada de la aplicación
│   ├── Form1.cs                # Lógica del formulario (CRUD, eventos, validación)
│   ├── Form1.Designer.cs       # Diseño de los controles del formulario
│   ├── Producto.cs             # Clase modelo del producto
│   ├── Conexion.cs             # Conexión a MySQL y métodos Insert/Update/Delete/Get
│   ├── IValidadorCampo.cs      # Interfaz de validación
│   ├── ValidadorTexto.cs       # Valida campos de texto (no vacíos)
│   ├── ValidadorDecimal.cs     # Valida números decimales (precio)
│   ├── ValidadorEntero.cs      # Valida números enteros (cantidad)
│   └── CRUD_PRODUCTOS.csproj   # Configuración del proyecto
├── database/
│   └── productosdb.sql         # Script para crear la base de datos
├── capturas/                   # Imágenes usadas en este README
└── README.md                   # Documentación del proyecto
```

## ▶️ Instrucciones de Ejecución / Uso

1. **Clonar el repositorio:**

   ```bash
   git clone https://github.com/[tu-usuario]/[nombre-del-repositorio].git
   ```

2. **Crear la base de datos.** Inicia MySQL (por ejemplo con WampServer o XAMPP) y ejecuta este script:

   ```sql
   CREATE DATABASE IF NOT EXISTS productosdb;
   USE productosdb;

   CREATE TABLE IF NOT EXISTS productos (
       id       INT AUTO_INCREMENT PRIMARY KEY,
       nombre   VARCHAR(100)   NOT NULL,
       precio   DECIMAL(10,2)  NOT NULL,
       cantidad INT            NOT NULL,
       imagen   LONGBLOB       NULL
   );
   ```

3. **Configurar la conexión.** En `Conexion.cs`, cambia el usuario y la contraseña de MySQL por los tuyos:

   ```csharp
   private static string cadenaConexion = "Server=localhost;Database=productosdb;Uid=root;Pwd=TU_CONTRASEÑA";
   ```

4. **Abrir el proyecto:** abre `CRUD_PRODUCTOS.sln` en Visual Studio. Si hace falta, instala el paquete NuGet **MySqlConnector** en *Herramientas → Administrador de paquetes NuGet*.

5. **Ejecutar:** presiona **F5** o el botón **▶ Iniciar**.

### Uso de la aplicación

| Acción | Cómo se hace |
|---|---|
| Agregar | Llena Nombre, Precio y Cantidad, elige una imagen (clic en la imagen) y presiona **Guardar**. |
| Modificar | Haz clic en una fila del grid, cambia los datos y presiona **Modificar**. |
| Eliminar | Haz clic en una fila del grid y presiona **Eliminar**. |
| Buscar | Escribe en el campo **Búsqueda**. El grid se filtra automáticamente. |
| Limpiar | Presiona **Limpiar** para vaciar el formulario y registrar un producto nuevo. |

## 👤 Autor y Contexto

- **Nombre:** [Tu nombre completo]
- **Institución:** Universidad Tecnológica de Panamá (UTP)
- **Carrera / Grupo:** [Carrera – Grupo]
- **Profesora:** Ing. Irina Fong
- **Fecha de Realización:** 24/09/2026

## 📚 Referencias

- [Video de apoyo]([enlace al video])
- [Interfaces en C# – Luis Llamas](https://www.luisllamas.es/csharp-interfaces/)
- [Documentación de MySqlConnector](https://mysqlconnector.net/)
- [Documentación de Windows Forms – Microsoft Learn](https://learn.microsoft.com/es-es/dotnet/desktop/winforms/)
- Material de clase: *CRUD C#*, *Implementación de Herencia* y *Ejemplo de Interfaz* (Ing. Irina Fong)
