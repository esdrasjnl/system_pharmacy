using System;
using System.Collections.Generic;

namespace SistemaFarmacia.Model;

public partial class NumeroDocumentoCotizacion
{
    public int IdNumeroDocumentoCompra { get; set; }

    public int UltimoNumero { get; set; }

    public DateTime? FechaRegistro { get; set; }
}
