using Microsoft.EntityFrameworkCore;
using StudentRegister.DAL;
using StudentRegister.Models;
using System.Linq.Expressions;

namespace StudentRegister.Services;
public class TiposPuntosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(TiposPuntos tipoPunto)
    {
        if (!await Existe(tipoPunto.TipoId))
            return await Insertar(tipoPunto);
        else
            return await Modificar(tipoPunto);
    }
    private async Task<bool> Existe(int tipoPuntoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposPuntos.AnyAsync(p => p.TipoId == tipoPuntoId);
    }
    public async Task<bool> ExisteDuplicado(TiposPuntos tipoPunto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposPuntos.AnyAsync(p => p.Nombre == tipoPunto.Nombre && p.TipoId != tipoPunto.TipoId);
    }
    private async Task<bool> Insertar(TiposPuntos tipoPunto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.TiposPuntos.Add(tipoPunto);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(TiposPuntos tipoPunto)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.TiposPuntos.Update(tipoPunto);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<TiposPuntos?> Buscar(int tipoPuntoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposPuntos.AsNoTracking().FirstOrDefaultAsync(p => p.TipoId == tipoPuntoId);
    }
    public async Task<List<TiposPuntos>> Listar(Expression<Func<TiposPuntos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposPuntos.Where(criterio).AsNoTracking().ToListAsync();
    }
}