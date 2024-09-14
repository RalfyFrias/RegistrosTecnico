using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
    public class TrabajoService
    {
        private readonly Contexto _contexto;

        public TrabajoService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Existe(int trabajoId)
        {
            return await _contexto.Trabajos.AnyAsync(t => t.TrabajoId == trabajoId);
        }

        private async Task<bool> Insertar(Trabajos trabajo)
        {
            _contexto.Trabajos.Add(trabajo);
            return await _contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Trabajos trabajo)
        {
            _contexto.Trabajos.Update(trabajo);
            var modificado = await _contexto.SaveChangesAsync() > 0;
            _contexto.Entry(trabajo).State = EntityState.Detached;
            return modificado;
        }

        public async Task<bool> Guardar(Trabajos trabajo)
        {
            if (!await Existe(trabajo.ClienteId))
            {
                return await Insertar(trabajo);
            }
            else
            {
                return await Modificar(trabajo);
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            var eliminado = await _contexto.Trabajos.Where(t => t.TrabajoId == id).ExecuteDeleteAsync();
            return eliminado > 0;
        }

        public async Task<Trabajos?> Buscar(int id)
        {
            return await _contexto.Trabajos
                .AsNoTracking()
                .Include(t => t.Clientes)
                .FirstOrDefaultAsync(t => t.TrabajoId == id);
        }

        public async Task<List<Trabajos>> Listar(Expression<Func<Trabajos, bool>> Criterio)
        {
            return await _contexto.Trabajos
              .AsNoTracking()
              .Include(t => t.Clientes)
              .Include(t => t.Tecnicos)
            .Where(Criterio)
            .ToListAsync();
        }
    }
}
