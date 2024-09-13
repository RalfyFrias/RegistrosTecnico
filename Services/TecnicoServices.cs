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

            public async Task<bool> Existe(int TecnicoId)
            {
                return await _contexto.Tecnicos.AnyAsync(t => t.TecnicoId == TecnicoId );
            }

            private async Task<bool> Insertar(Tecnicos tecnico)
            {
                _contexto.Tecnicos.Add(tecnico);
                return await _contexto.SaveChangesAsync() > 0;
            }

            private async Task<bool> Modificar(Tecnicos tecnico)
            {
                _contexto.Tecnicos.Update(tecnico);
                var modificado = await _contexto.SaveChangesAsync() > 0;
                _contexto.Entry(tecnico).State = EntityState.Detached;
                return modificado;
            }

            public async Task<bool> Guardar(Tecnicos tecnico)
            {
                if (!await Existe(tecnico.TecnicoId))
                {
                    return await Insertar(tecnico);
                }
                else
                {
                    return await Modificar(tecnico);
                }
            }

            public async Task<bool> Eliminar(int id)
            {
                var eliminado = await _contexto.Tecnicos.Where(t => t.TecnicoId == id).ExecuteDeleteAsync();
                return eliminado > 0;
            }

            public async Task<Tecnicos?> Buscar(int id)
            {
                return await _contexto.Tecnicos.AsNoTracking().FirstOrDefaultAsync(t => t.TecnicoId == id);
            }

            public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> Criterio)
            {
                return await _contexto.Tecnicos
                .Where(Criterio)
                .ToListAsync();
            }
        }

    }

