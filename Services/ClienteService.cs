using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services;

    public class ClienteService
    {
    private readonly Contexto _contexto;

    public ClienteService(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int ClienteId)
    {
        return await _contexto.Cliente.AnyAsync(t => t.ClienteId ==  ClienteId);
    }

    private async Task<bool> Insertar(Clientes cliente)
    {
        _contexto.Cliente.Add(cliente);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Clientes cliente)
    {
        _contexto.Cliente.Update(cliente);
        var modificado = await _contexto.SaveChangesAsync() > 0;
        _contexto.Entry(cliente).State = EntityState.Detached;
        return modificado;
    }

    public async Task<bool> Guardar(Clientes cliente)
    {
        if (!await Existe(cliente.ClienteId))
        {
            return await Insertar(cliente);
        }
        else
        {
            return await Modificar(cliente);
        }
    }

    public async Task<bool> Eliminar(int id)
    {
        var eliminado = await _contexto.Cliente.Where(t => t.ClienteId == id).ExecuteDeleteAsync();
        return eliminado > 0;
    }

    public async Task<Clientes?> Buscar(int id)
    {
        return await _contexto.Cliente.AsNoTracking().FirstOrDefaultAsync(t => t.ClienteId == id);
    }

    public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> Criterio)
    {
        return await _contexto.Cliente
        .Where(Criterio)
        .ToListAsync();
    }
}