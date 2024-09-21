using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using RegistroTecnicos.DAL;
using RegistroTecnicos.Models;


namespace RegistroTecnicos.Services;

public class PrioridadService
{

    private readonly Contexto _context;
    public PrioridadService(Contexto contexto)
    {
        _context = contexto;
    }

    public async Task<bool> Guardar(Prioridades prioridad)
    {
        //Busca la prioridad, si no existe la inserta, si existe la modifica
        if (!await Existe(prioridad.PrioridadId))
            return await Insertar(prioridad);
        else
            return await Modificar(prioridad);
    }

    public async Task<bool> Insertar(Prioridades prioridad)
    {
        _context.Prioridad.Add(prioridad);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Prioridades prioridad)
    {
        _context.Update(prioridad);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int PrioridadId)
    {
        return await _context.Prioridad
            .AnyAsync(p => p.PrioridadId == PrioridadId);

    }

    public async Task<bool> Existe(string? descripcion, int? prioridadId = null)
    {
        return await _context.Prioridad
            .AnyAsync(p => p.Descripcion.Equals(descripcion));
    }


    public async Task<bool> Existe(int prioridadId, string? descripcion)
    {
        //TODO: Unir los dos existe en uno solo para reducir duplicidad de codigo.
        return await _context.Prioridad
            .AnyAsync(p => p.PrioridadId != prioridadId && p.Descripcion.Equals(descripcion));
    }

    public async Task<bool> Eliminar(int Id)
    {
        var prioridades = await _context.Prioridad
            .Where(p => p.PrioridadId == Id)
            .ExecuteDeleteAsync();
        return prioridades > 0;
    }

    public async Task<Prioridades?> Buscar(int Id)
    {
        return await _context.Prioridad
            .AsNoTracking()
            .FirstOrDefaultAsync(P => P.PrioridadId == Id);
    }

    public async Task<List<Prioridades>> Listar(Expression<Func<Prioridades, bool>> criterio)
    {
        return await _context.Prioridad
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();

    }
}