using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DockAcme.Data;
using DockAcme.Models;
using Microsoft.EntityFrameworkCore;

namespace DockAcme.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnvioController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EnvioController(AppDbContext context)
        {
            _context = context;  // Asignar el DbContext en el constructor
        }

        // GET: api/Envios para ver Json
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Envio>>> GetEnvios()
        {
            return await _context.Envios.ToListAsync();
        }

        // GET: api/Envios/codigo Envio para obtener un solo Envio
        [HttpGet("{id}")]
        public async Task<ActionResult<Envio>> GetEnvio(long id)
        {
            var envio = await _context.Envios.FindAsync(id);

            if (envio == null)
            {
                return NotFound();
            }

            return envio;
        }
    }
}
