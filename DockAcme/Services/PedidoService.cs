using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DockAcme.Data;
using DockAcme.Models;
using Microsoft.EntityFrameworkCore;

namespace DockAcme
{
    public class PedidoService : IPedidoService
    {
        private readonly AppDbContext _context;

        public PedidoService(AppDbContext context)
        {
            _context = context;
        }

        // Método para obtener todos los pedidos
        public async Task<List<Pedido>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();  // Obtener todos los pedidos
        }
        public async Task<Pedido> GetPedido(long idPedido)
        {
            return await _context.Pedidos.FindAsync(idPedido);// Retorna pedido segun su id
        }
         /*public Pedido GetPedido(long id)
        {
            return _context.Pedidos.FirstOrDefault(p => p.idpedidos == id);  // Retorna pedido segun su id
        }*/
    }
}
