using System.Collections.Generic;

namespace ClnOmnicell
{
    // Tipos de pago aceptados al registrar una venta o una compra.
    public static class TipoPagoCln
    {
        public const string Efectivo = "Efectivo";
        public const string Qr = "QR";
        public const string Transferencia = "Transferencia";

        public static List<string> listar()
        {
            return new List<string> { Efectivo, Qr, Transferencia };
        }
    }
}
