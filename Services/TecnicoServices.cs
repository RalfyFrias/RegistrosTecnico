using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
    public class TecnicoService
    {

        private readonly Contexto _contexto;

            public TecnicoService(Contexto contexto)
            {
                _contexto = contexto;
            }

            public async Task<bool> Existe(int TecnicoId, string Descripcion)
            {
                return await _contexto.Tecnicos.AnyAsync(t => t.TecnicoID != TecnicoId && t.Nombres.Equals(Descripcion));
            }

            private async Task<bool> Insertar(Tecnico tecnicos)
            {
                _contexto.Tecnicos.Add(tecnicos);
                return await _contexto.SaveChangesAsync() > 0;
            }

            private async Task<bool> Modificar(Tecnico tecnicos)
            {
                _contexto.Tecnicos.Update(tecnicos);
                var modificado = await _contexto.SaveChangesAsync() > 0;
                _contexto.Entry(tecnicos).State = EntityState.Detached;
                return modificado;
            }

            public async Task<bool> Guardar(Tecnico tecnicos)
            {
                if (!await Existe(tecnicos.TecnicoID, tecnicos.Nombres))
                {
                    return await Insertar(tecnicos);
                }
                else
                {
                    return await Modificar(tecnicos);
                }
            }

            public async Task<bool> Eliminar(int id)
            {
                var eliminado = await _contexto.Tecnicos.Where(t => t.TecnicoID == id).ExecuteDeleteAsync();
                return eliminado > 0;
            }

            public async Task<Tecnico?> Buscar(int id)
            {
                return await _contexto.Tecnicos.AsNoTracking().FirstOrDefaultAsync(t => t.TecnicoID == id);
            }

            public async Task<List<Tecnico>> Listar(Expression<Func<Tecnico, bool>> Criterio)
            {
                return await _contexto.Tecnicos.Where(Criterio).ToListAsync();
            }
        }

    }

