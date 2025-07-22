using System;
using System.Collections.Generic;

namespace SistemaFarmacia.Model;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string? Nombre { get; set; }

    public string? Nit { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Celular { get; set; }

    public string? Cuenta { get; set; }

    public bool? EsActivo { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
