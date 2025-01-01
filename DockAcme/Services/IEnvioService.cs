using DockAcme.Models;
using System.ServiceModel;


namespace DockAcme.Services
{
    [ServiceContract]
    public interface IEnvioService
    {
        //Obtner los valores de los envios a la base de datos por medio de soap
        [OperationContract]
        Task<List<Envio>> GetEnvios();  // Método para devolver todos los envios


        //Obtner los valores de un solo envios por medio de soap
        [OperationContract]
        Task<Envio> GetEnvio(long id);
    }
}
