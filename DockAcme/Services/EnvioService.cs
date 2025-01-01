using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DockAcme.Data;
using DockAcme.Models;
using Microsoft.EntityFrameworkCore;

namespace DockAcme.Services
{
    public class EnvioService : IEnvioService
    {
        private readonly AppDbContext _context;

        public EnvioService(AppDbContext context)
        {
            _context = context;
        }

        // Método para obtener todos los Envios
        public async Task<List<Envio>> GetEnvios()
        {
            return await _context.Envios.ToListAsync();  // Obtener todos los Envios
        }
        public async Task<Envio> GetEnvio(long idEnvio)
        {
            return await _context.Envios.FindAsync(idEnvio);// Retorna Envio segun su id
        }
    }
}
