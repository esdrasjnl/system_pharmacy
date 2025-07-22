using SistemaFarmacia.DTO;
using SistemaFarmacia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.BLL.Servicios.Contrato
{
    public interface IRolRepositorio
    {
        Task<List<Rol>> Lista();
    }
}
