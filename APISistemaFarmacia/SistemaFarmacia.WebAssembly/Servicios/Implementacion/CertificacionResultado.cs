namespace SistemaFarmacia.WebAssembly.Servicios.Implementacion
{
    public class CertificacionResultado
    {
        public bool Exito { get; set; }
        public string NumeroAutorizacion { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public DateTime FechaCertificacion { get; set; }
        public string PdfBase64 { get; set; }
        public string XmlCertificado { get; set; }
        public string MensajeError { get; set; }
    }
}
