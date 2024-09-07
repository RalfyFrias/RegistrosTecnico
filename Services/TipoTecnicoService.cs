using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
    public class TiposTecnicosService
    {
        private readonly Contexto _contexto;

        public TiposTecnicosService(Contexto contexto)
        {
            _contexto = contexto;
        }

        // Método Existente
        public async Task<bool> Existe(int TipoId)
        {
            return await _contexto.Tipostecnicos.AnyAsync(t => t.TipoId == TipoId);
        }

        // Método Insertar
        private async Task<bool> Insertar(Tipostecnicos tipostecnicos)
        {
            _contexto.Tipostecnicos.Add(tipostecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        // Método Modificar
        private async Task<bool> Modificar(Tipostecnicos tipostecnicos)
        {
            _contexto.Tipostecnicos.Update(tipostecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        // Método guardar
        public async Task<bool> Guardar(Tipostecnicos tipostecnicos)
        {
            if (!await Existe(tipostecnicos.TipoId))
                return await Insertar(tipostecnicos);
            else
                return await Modificar(tipostecnicos);
        }

        // Método eliminar
        public async Task<bool> Eliminar(int id)
        {
            var Tecnicos = await _contexto.Tipostecnicos.FindAsync(id);
            if (Tecnicos == null)
                return false;

            _contexto.Tipostecnicos.Remove(Tecnicos);
            return await _contexto.SaveChangesAsync() > 0;
        }

        // Método buscar
        public async Task<Tipostecnicos?> Buscar(int id)
        {
            return await _contexto.Tipostecnicos
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.TipoId == id);
        }

        // Método listar
        public async Task<List<Tipostecnicos>> Listar(Expression<Func<Tipostecnicos, bool>> criterio)
        {
            return await _contexto.Tipostecnicos
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }
    }
}
