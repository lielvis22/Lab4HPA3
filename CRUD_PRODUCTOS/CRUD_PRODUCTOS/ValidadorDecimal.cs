namespace CRUD_PRODUCTOS
{
    // La clase ValidadorDecimal implementa la interfaz IValidadorCampo
    public class ValidadorDecimal : IValidadorCampo
    {
        public string MensajeError { get; private set; } = string.Empty;

        public bool EsValido(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor) ||
                !decimal.TryParse(valor.Trim(), out decimal resultado) ||
                resultado < 0)
            {
                MensajeError = "Debe ingresar un número decimal válido (mayor o igual a 0).";
                return false;
            }

            MensajeError = string.Empty;
            return true;
        } // Fin del método EsValido
    }
}