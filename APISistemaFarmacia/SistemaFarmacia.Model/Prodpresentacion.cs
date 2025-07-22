using System;
using System.Collections.Generic;

namespace SistemaFarmacia.Model;

public partial class Prodpresentacion
{
    public int IdProdpresentacion { get; set; }

    public int? IdProducto { get; set; }

    public int? IdPresentacion { get; set; }

    public int? Cantidad { get; set; }

    public virtual Presentacion? IdPresentacionNavigation { get; set; }
}
