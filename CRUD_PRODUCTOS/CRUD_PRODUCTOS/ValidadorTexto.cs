namespace CRUD_PRODUCTOS
{
    // La clase ValidadorTexto implementa la interfaz IValidadorCampo
    public class ValidadorTexto : IValidadorCampo
    {
        public string MensajeError { get; private set; } = string.Empty;

        public bool EsValido(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                MensajeError = "El campo de texto no puede estar vacío.";
                return false;
            }

            MensajeError = string.Empty;
            return true;
        } // Fin del método EsValido
    }
}
