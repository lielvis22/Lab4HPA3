namespace CRUD_PRODUCTOS
{
    public partial class Form1 : Form
    {
        private List<Producto> listaProductos;
        private Dictionary<string, object> myProducto = new Dictionary<string, object>();
        private int idSeleccionado = 0;
        private ErrorProvider errorValidacion = new ErrorProvider();

        private List<(TextBox txt, IValidadorCampo validador)> camposValidar
            = new List<(TextBox txt, IValidadorCampo validador)>();
        public Form1()
        {
            InitializeComponent();
            listaProductos = new List<Producto>();
            camposValidar.Add((txtNombre, new ValidadorTexto()));
            camposValidar.Add((txtPrecio, new ValidadorDecimal()));
            camposValidar.Add((txtCantidad, new ValidadorEntero()));

            // RESTRICCIÓN: el nombre se escribe siempre en MAYÚSCULAS,
            // aunque el usuario teclee en minúscula (también al pegar texto)
            txtNombre.CharacterCasing = CharacterCasing.Upper;

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            cargarProductos();
        }
        private void cargarProductos(string filtro = "")
        {
            dgvProductos.Rows.Clear();
            dgvProductos.Refresh();

            listaProductos = Conexion.GetProductos(filtro);

            foreach (var prod in listaProductos)
            {
                Image img = null;

                if (prod.Imagen != null && prod.Imagen.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(prod.Imagen))
                    {
                        using (Bitmap bmp = new Bitmap(ms))
                        {
                            img = new Bitmap(bmp);
                        }
                    }
                }

                dgvProductos.Rows.Add(prod.Id, prod.Nombre, prod.Precio, prod.Cantidad, img);
            }
        } // fin de cargarProductos


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar imagen del producto";
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }

                    byte[] bytes = File.ReadAllBytes(openFileDialog.FileName);
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        using (Bitmap bmpTemporal = new Bitmap(ms))
                        {
                            pictureBox1.Image = new Bitmap(bmpTemporal); // clona la imagen, independiente del stream
                        }
                    }

                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }
        private bool datosCorrectos()
        {
            bool todoOk = true;
            TextBox? primerError = null;

            foreach (var item in camposValidar)
            {
                if (!item.validador.EsValido(item.txt.Text))
                {
                    errorValidacion.SetError(item.txt, item.validador.MensajeError);
                    todoOk = false;
                    primerError ??= item.txt;   // recuerda el primer campo con error
                }
                else
                {
                    errorValidacion.SetError(item.txt, string.Empty); // limpia si está bien
                }
            } // fin del foreach

            primerError?.Focus();   // lleva el cursor al primer campo con error
            return todoOk;
        } // fin de datosCorrectos

        // Quita todos los iconos de error
        private void limpiarErrores()
        {
            foreach (var item in camposValidar)
                errorValidacion.SetError(item.txt, string.Empty);
        }
        
        private void CargarDatosProductos()
        {
            myProducto["Cantidad"] = int.Parse(txtCantidad.Text.Trim());
            myProducto["Precio"] = decimal.Parse(txtPrecio.Text.Trim());
            myProducto["Nombre"] = txtNombre.Text.Trim();
            myProducto["Imagen"] = ImageToByteArray(pictureBox1.Image);
        }

        // ---------------------------------------------------
        // Convierte una imagen a arreglo de bytes usando MemoryStream
        // ---------------------------------------------------
        private byte[] ImageToByteArray(Image image)
        {
            if (image == null)
                return null;

            using (MemoryStream mMemoryStream = new MemoryStream())
            {
                // Usamos PNG fijo en vez de image.RawFormat (evita el error con MemoryBmp)
                image.Save(mMemoryStream, System.Drawing.Imaging.ImageFormat.Png);
                return mMemoryStream.ToArray();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (datosCorrectos())
            {
                CargarDatosProductos();

                if (Conexion.InsertSeguro("productos", myProducto))
                {
                    MessageBox.Show("Se ha guardado satisfactoriamente el registro");
                    // Refrescamos el grid volviendo a consultar la base de datos
                    cargarProductos();
                    limpiarFormulario();
                }
            }
        }
        // ---------------------------------------------------
        // Limpiar campos del formulario
        // ---------------------------------------------------
        private void limpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            pictureBox1.Image = null;
            myProducto.Clear();
            limpiarErrores();     
            idSeleccionado = 0;   
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un producto de la lista para eliminar");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que deseas eliminar este producto?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                if (Conexion.DeleteSeguro("productos", idSeleccionado))
                {
                    MessageBox.Show("Se ha eliminado el registro");
                    cargarProductos();
                    limpiarFormulario();
                    idSeleccionado = 0;
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al eliminar el registro");
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un producto de la lista para modificar");
                return;
            }

            if (!datosCorrectos())
            {
                return;
            }

            CargarDatosProductos();

            if (Conexion.UpdateSeguro("productos", myProducto, idSeleccionado))
            {
                MessageBox.Show("Se ha modificado satisfactoriamente el registro");
                cargarProductos();
                limpiarFormulario();
                idSeleccionado = 0;
            }
            else
            {
                MessageBox.Show("Ocurrió un error al modificar el registro");
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Evita error si se hace clic en el encabezado
            limpiarErrores();
            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];
            if (fila.IsNewRow) return;
            idSeleccionado = Convert.ToInt32(fila.Cells["ID"].Value);
            txtFolio.Text = fila.Cells["ID"].Value.ToString();
            txtNombre.Text = fila.Cells["Nombre"].Value.ToString();
            txtPrecio.Text = fila.Cells["Precio"].Value.ToString();
            txtCantidad.Text = fila.Cells["Cantidad"].Value.ToString();

            if (fila.Cells["colImagen"].Value != null && fila.Cells["colImagen"].Value != DBNull.Value)
            {
                pictureBox1.Image = new Bitmap((Image)fila.Cells["colImagen"].Value);
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void txtBusqueda_TextChanged_1(object sender, EventArgs e)
        {
            cargarProductos(txtBusqueda.Text.Trim());
        }
    }
}
