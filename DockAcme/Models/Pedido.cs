using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace DockAcme.Models
{
    [DataContract]
    public class Pedido
    {
        //Modelo de tabla en la base de datos
        [Key]
        [DataMember (Name = "ID")]
        public long idpedidos { get; set; }
        [DataMember(Name = "pedido")] 
        public string numPedido { get; set; }
        [DataMember(Name = "Cantidad")]
        public int cantidadPedido { get; set; }
        [DataMember(Name = "EAN")] 
        public string codigoEAN { get; set; }
        [DataMember(Name = "Producto")] 
        public string nombreProducto { get; set; }
        [DataMember(Name = "Cedula")] 
        public string numDocumento { get; set; }
        [DataMember(Name = "Direccion")] 
        public string direccion { get; set; }
    }
}
