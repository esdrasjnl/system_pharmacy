using SistemaFarmacia.BLL.Servicios.Contrato;
using SistemaFarmacia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SistemaFarmacia.BLL.Servicios
{
    public class XmlCertificacionBuilder : IXmlCertificacionBuilder
    {
        public string GenerarXmlDesdeVenta(VentaDTO venta)
        {
            
            // Aquí armarías el XML usando XmlDocument, XDocument o StringBuilder.
            // Por ejemplo:
            var xmlDoc = new XDocument(
                new XElement("Factura",
                   // new XElement("Cliente", venta.ClienteNombre),
                    new XElement("Total", venta.Total)
                // Completa el resto del XML de acuerdo con el formato esperado por Tekra.
                )
            );

            return xmlDoc.ToString();
        }
    }
    
}
