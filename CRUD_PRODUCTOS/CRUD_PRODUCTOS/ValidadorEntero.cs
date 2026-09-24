namespace CRUD_PRODUCTOS
{
    // La clase ValidadorEntero implementa la interfaz IValidadorCampo
    public class ValidadorEntero : IValidadorCampo
    {
        public string MensajeError { get; private set; } = string.Empty;

        public bool EsValido(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor) ||
                !int.TryParse(valor.Trim(), out int resultado) ||
                resultado < 0)
            {
                MensajeError = "Debe ingresar un número entero válido (mayor o igual a 0).";
                return false;
            }

            MensajeError = string.Empty;
            return true;
        } // Fin del método EsValido
    }
}




