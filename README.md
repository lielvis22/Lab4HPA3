# Laboratorio # 4 – CRUD de Productos en C#

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

<img width="812" height="861" alt="image" src="https://github.com/user-attachments/assets/e098bd36-bb24-43ca-a98b-a7c581c5b4a6" />


### Problemas / Ejercicios resueltos

- **Ejercicio 1 – Guardar producto:** valida los campos, convierte la imagen a un arreglo de bytes y guarda el registro con `InsertSeguro`. Después refresca el grid y limpia el formulario.

<img width="960" height="857" alt="image" src="https://github.com/user-attachments/assets/7d22d802-5287-4b8d-97ab-8272965e7feb" />

<img width="822" height="862" alt="image" src="https://github.com/user-attachments/assets/e9cc3408-4e1f-49f4-a10c-335c14659400" />

<img width="813" height="855" alt="image" src="https://github.com/user-attachments/assets/ad4c7f71-7e17-4410-adbe-9827f4e0a54b" />

- **Ejercicio 2 – Seleccionar y modificar producto:** con el evento `CellClick` del `DataGridView`, los datos de la fila se cargan en el formulario. Al presionar **Modificar** se actualiza el registro por su `id` con `UpdateSeguro`.

<img width="811" height="851" alt="image" src="https://github.com/user-attachments/assets/0f740ff9-a5fd-43f0-aa0c-f694630c6302" />

<img width="601" height="221" alt="image" src="https://github.com/user-attachments/assets/f9caa34b-c6c9-4b20-9a5c-81f2555207ed" />


- **Ejercicio 3 – Eliminar producto:** pide confirmación y elimina el registro seleccionado con `DeleteSeguro`.

<img width="815" height="862" alt="image" src="https://github.com/user-attachments/assets/4c4722f2-a54a-4035-aba1-af07b4ba667b" />

<img width="807" height="851" alt="image" src="https://github.com/user-attachments/assets/82f09214-8029-40a2-904c-89b32a0e2f13" />

<img width="591" height="237" alt="image" src="https://github.com/user-attachments/assets/f3e09c16-0ed8-4e36-ac96-873bf098b1e4" />

- **Ejercicio 4 – Búsqueda en vivo:** mientras se escribe en el campo de búsqueda, el grid se filtra por id, nombre, precio o cantidad.

  <img width="817" height="853" alt="image" src="https://github.com/user-attachments/assets/15de3dd9-92b7-4c1e-95d3-750a75a41659" />

  <img width="817" height="867" alt="image" src="https://github.com/user-attachments/assets/471bafa8-b93b-4d22-800c-eaafdb108a04" />

- **Ejercicio 5 – Validación con interfaces:** cada campo tiene su validador y los errores se muestran con un `ErrorProvider` junto al campo. Estas son las reglas:
  - **Nombre:** obligatorio. Se escribe siempre en **MAYÚSCULAS**, aunque el usuario teclee en minúscula.
  - **Precio:** número decimal válido, mayor o igual a 0.
  - **Cantidad:** número entero válido, mayor o igual a 0.
<img width="935" height="857" alt="image" src="https://github.com/user-attachments/assets/ac0872f2-59f9-4623-a405-3570de88768c" />
<img width="967" height="862" alt="image" src="https://github.com/user-attachments/assets/0b457ce0-764e-4048-8237-aa272c025386" />

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

- **Nombre:** Elvis Li
- **Institución:** Universidad Tecnológica de Panamá (UTP)
- **Carrera / Grupo:** Lic. Ing. de Sistema y Computacional / 1IL133
- **Profesora:** Ing. Irina Fong
- **Fecha de Realización:** 24/09/2026

## 📚 Referencias

- [Interfaces en C# – Luis Llamas](https://www.luisllamas.es/csharp-interfaces/)
- [Documentación de MySqlConnector](https://mysqlconnector.net/)
- [Documentación de Windows Forms – Microsoft Learn](https://learn.microsoft.com/es-es/dotnet/desktop/winforms/)
- Material de clase: *CRUD C#*, *Implementación de Herencia* y *Ejemplo de Interfaz* (Ing. Irina Fong)
