namespace CRUD_PRODUCTOS
{
    public interface IValidadorCampo
    {
        bool EsValido(string? valor);
        string MensajeError { get; }
    }
}
