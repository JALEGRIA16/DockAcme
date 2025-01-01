using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace DockAcme.Models
{
    [DataContract]
    public class Envio
    {
        [Key]
        [DataMember(Name = "ID")]
        public long idenvio { get; set; }
        [DataMember(Name = "Codigo")]
        public string codigoEnvio { get; set; }
        [DataMember(Name = "estado")]
        public string  Mensaje { get; set; }
    }
}
