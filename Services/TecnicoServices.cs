using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
    public class TecnicoServices
    {
       
            private readonly Contexto _contexto;

            public TecnicoServices(Contexto contexto)
            {
                _contexto = contexto;
            }

            public async Task<bool> Existe(int TecnicoId, string Descripcion)
            {
                return await _contexto.Tecnicos.AnyAsync(t => t.TecnicoId != TecnicoId && t.Descripcion.Equals(Descripcion));
            }

            private async Task<bool> Insertar(Tecnicos tecnico)
            {
                _contexto.Tecnicos.Add(tecnico);
                return await _contexto.SaveChangesAsync() > 0;
            }

            private async Task<bool> Modificar(Tecnicos tecnicos)
            {
                _contexto.Tecnicos.Update(tecnicos);
                var modificado = await _contexto.SaveChangesAsync() > 0;
                _contexto.Entry(tecnicos).State = EntityState.Detached;
                return modificado;
            }

            public async Task<bool> Guardar(Tecnicos tecnicos)
            {
                if (!await Existe(tecnicos.TecnicoId, tecnicos.Descripcion))
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
                var eliminado = await _contexto.Tecnicos.Where(t => t.TecnicoId == id).ExecuteDeleteAsync();
                return eliminado > 0;
            }

            public async Task<Tecnicos?> Buscar(int id)
            {
                return await _contexto.Tecnicos.AsNoTracking().FirstOrDefaultAsync(t => t.TecnicoId == id);
            }

            public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> Criterio)
            {
                return await _contexto.Tecnicos.Where(Criterio).ToListAsync();
            }
        }

    }

