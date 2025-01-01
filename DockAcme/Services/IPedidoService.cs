using DockAcme.Models;
using System.ServiceModel;

namespace DockAcme
{
    [ServiceContract]
    public interface IPedidoService
    {
        //Obtner los valores de pedidos a la base de datos por medio de soap
        [OperationContract]
        Task<List<Pedido>> GetPedidos();  // Método para devolver todos los pedidos


        //Obtner los valores de un solo pedido por medio de soap
        [OperationContract]
        Task<Pedido> GetPedido(long id);
    }
}
