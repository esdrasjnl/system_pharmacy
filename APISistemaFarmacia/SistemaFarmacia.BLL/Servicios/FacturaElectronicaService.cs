using Tekra.FEL; // Este namespace es el que generó el WSDL
using System.Text;
using System.Xml;
using System.IO;
using System.Threading.Tasks;
using SistemaFarmacia.BLL.Servicios.Contrato;
using SistemaFarmacia.DTO;
using Tekra.FEL;
using Microsoft.EntityFrameworkCore;
using SistemaFarmacia.DAL.DBContext;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaFarmacia.BLL.Servicios
{
    public class FacturaElectronicaService : IFacturaElectronicaService
    {
        private readonly DbfarmaciaContext _dbContext;

        public FacturaElectronicaService(DbfarmaciaContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<CertificacionResultado> CertificarVenta(int idVenta)
        {
            // 1. Simulación de recuperación de venta (sin acceso a base de datos)
            var venta = new SistemaFarmacia.Model.Venta
            {
                IdVenta = idVenta,
                DetalleVenta = new List<SistemaFarmacia.Model.DetalleVenta>() // Si tienes detalles, agrégalos aquí
            };

            // 2. Generar XML del DTE
            string xmlGenerado = GenerarXmlDesdeVenta(venta);

            // 3. Preparar solicitud
            var certificacionDocumento = new CertificacionDocumento
            {
                Autenticacion = new AutenticacionCertificacion
                {
                    pn_usuario = "tekra_api",
                    pn_clave = "123456789",
                    pn_cliente = 2121010001,
                    pn_contrato = 2122010001,
                    pn_id_origen = "TEKRA_PRUEBA",
                    pn_ip_origen = "192.168.0.100",
                    pn_firmar_emisor = "SI"
                },
                Documento = xmlGenerado
            };

            // 4. Consumir el servicio
            var cliente = new KTFCertificadorClient(KTFCertificadorClient.EndpointConfiguration.KTFCertificadorSOAP);
            var respuesta = await cliente.CertificacionDocumentoAsync(certificacionDocumento);
            var resultado = respuesta.CertificacionDocumentoResponse;

            // 5. Retornar el resultado directamente
            return new CertificacionResultado
            {
                Exito = true,
                NumeroAutorizacion = resultado.NumeroAutorizacion,
                Serie = resultado.SerieDocumento,
                Numero = resultado.NumeroDocumento,
                FechaCertificacion = DateTime.TryParse(resultado.FechaHoraCertificacion, out var fecha) ? fecha : default,
                PdfBase64 = resultado.RepresentacionGrafica,
                XmlCertificado = resultado.ResultadoCertificacion,
                MensajeError = resultado.EstadoDocumento

            };
            
        }


        private string GenerarXmlDesdeVenta(SistemaFarmacia.Model.Venta venta)
        {
            string xmlDTE = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<dte:GTDocumento Version=""0.1"" xmlns:dte=""http://www.sat.gob.gt/dte/fel/0.2.0"" xmlns:cfc=""http://www.sat.gob.gt/dte/fel/CompCambiaria/0.1.0""
    xmlns:cex=""http://www.sat.gob.gt/face2/ComplementoExportaciones/0.1.0"" xmlns:cfe=""http://www.sat.gob.gt/face2/ComplementoFacturaEspecial/0.1.0""
    xmlns:cno=""http://www.sat.gob.gt/face2/ComplementoReferenciaNota/0.1.0"" xmlns:ds=""http://www.w3.org/2000/09/xmldsig#""
    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <dte:SAT ClaseDocumento=""dte"">
    <dte:DTE ID=""DatosCertificados"">
      <dte:DatosEmision ID=""DatosEmision"">
        <dte:DatosGenerales Tipo=""FACT"" FechaHoraEmision=""{DateTime.Now:yyyy-MM-ddTHH:mm:ss-06:00}"" CodigoMoneda=""GTQ"" />
        <dte:Emisor NITEmisor=""107346834"" NombreEmisor=""TEKRA SOCIEDAD ANONIMA"" CodigoEstablecimiento=""1"" NombreComercial=""TEKRA SOCIEDAD ANONIMA"" CorreoEmisor="""" AfiliacionIVA=""GEN"">
          <dte:DireccionEmisor>
            <dte:Direccion>19 CALLE 18-48</dte:Direccion>
            <dte:CodigoPostal>01010</dte:CodigoPostal>
            <dte:Municipio>GUATEMALA</dte:Municipio>
            <dte:Departamento>GUATEMALA</dte:Departamento>
            <dte:Pais>GT</dte:Pais>
          </dte:DireccionEmisor>
        </dte:Emisor>
        <dte:Receptor IDReceptor=""12345671"" NombreReceptor=""Juan Perez"" CorreoReceptor=""perez@gmail.com"">
          <dte:DireccionReceptor>
            <dte:Direccion>GUATEMALA</dte:Direccion>
            <dte:CodigoPostal>0</dte:CodigoPostal>
            <dte:Municipio></dte:Municipio>
            <dte:Departamento></dte:Departamento>
            <dte:Pais>GT</dte:Pais>
          </dte:DireccionReceptor>
        </dte:Receptor>
        <dte:Frases>
          <dte:Frase TipoFrase=""1"" CodigoEscenario=""1"" />
        </dte:Frases>
        <dte:Items>";

            int linea = 1;
            foreach (var item in venta.DetalleVenta)
            {
                xmlDTE += $@"
          <dte:Item NumeroLinea=""{linea++}"" BienOServicio=""B"">
            <dte:Cantidad>{item.CantidadReporte:0.0000}</dte:Cantidad>
            <dte:Descripcion>{item.IdProducto}</dte:Descripcion>
            <dte:PrecioUnitario>{item.Precio:0.0000}</dte:PrecioUnitario>
            <dte:Precio>{item.Total:0.0000}</dte:Precio>
            <dte:Descuento>0.0000</dte:Descuento>
            <dte:Impuestos>
              <dte:Impuesto>
                <dte:NombreCorto>IVA</dte:NombreCorto>
                <dte:CodigoUnidadGravable>1</dte:CodigoUnidadGravable>
                <dte:MontoGravable>{item.Precio:0.0000}</dte:MontoGravable>
                <dte:MontoImpuesto>{item.Precio:0.0000}</dte:MontoImpuesto>
              </dte:Impuesto>
            </dte:Impuestos>
            <dte:Total>{item.Total:0.0000}</dte:Total>
          </dte:Item>";
            }

            xmlDTE += $@"

          <dte:Item NumeroLinea=""2"" BienOServicio=""S"">
            <dte:Cantidad>10.0000</dte:Cantidad>
            <dte:Descripcion>Descripción del servicio</dte:Descripcion>
            <dte:PrecioUnitario>25.0000</dte:PrecioUnitario>
            <dte:Precio>250.0000</dte:Precio>
            <dte:Descuento>0.0000</dte:Descuento>
            <dte:Impuestos>
              <dte:Impuesto>
                <dte:NombreCorto>IVA</dte:NombreCorto>
                <dte:CodigoUnidadGravable>1</dte:CodigoUnidadGravable>
                <dte:MontoGravable>223.2143</dte:MontoGravable>
                <dte:MontoImpuesto>26.7857</dte:MontoImpuesto>
              </dte:Impuesto>
            </dte:Impuestos>
            <dte:Total>250.0000</dte:Total>
          </dte:Item>
        </dte:Items>
        <dte:Totales>
          <dte:TotalImpuestos>
            <dte:TotalImpuesto NombreCorto=""IVA"" TotalMontoImpuesto=""53.5714"" />
          </dte:TotalImpuestos>
          <dte:GranTotal>500.0000</dte:GranTotal>
        </dte:Totales>
      </dte:DatosEmision>
    </dte:DTE>
    <dte:Adenda>
      <DECertificador>88884</DECertificador>
    </dte:Adenda>
  </dte:SAT>
</dte:GTDocumento>";

            return xmlDTE.Trim();
        }

    }
    }

