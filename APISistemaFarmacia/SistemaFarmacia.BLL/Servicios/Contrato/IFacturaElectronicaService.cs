using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.BLL.Servicios.Contrato
{
    public interface IFacturaElectronicaService
    {
        Task<CertificacionResultado> CertificarVenta(int idVenta);
    }
}
