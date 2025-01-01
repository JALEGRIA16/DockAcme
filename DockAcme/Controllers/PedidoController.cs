using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DockAcme.Data;
using DockAcme.Models;
using Microsoft.EntityFrameworkCore;


namespace DockAcme.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PedidoController(AppDbContext context)
        {
            _context = context;  // Asignar el DbContext en el constructor
        }

        // GET: api/Pedidos para ver Json
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }

        // GET: api/Pedidos/codigo pedido para obtener un solo pedido y verlo en json
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(long id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return pedido;
        }
    }
}
