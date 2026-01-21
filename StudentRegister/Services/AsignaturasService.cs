using Microsoft.EntityFrameworkCore;
using StudentRegister.DAL;
using StudentRegister.Models;
using System.Linq.Expressions;
namespace StudentRegister.Services;

public class AsignaturasService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Asignaturas asignaturas)
    {
        if (!await Existe(asignaturas.AsignaturaID))
            return await Insertar(asignaturas);
        else
            return await Modificar(asignaturas);
    }

    private async Task<bool> Existe(int asignaturaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Asignaturas.AnyAsync(a => a.AsignaturaID == asignaturaId);
    }

    private async Task<bool> Insertar(Asignaturas asignatura)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Asignaturas.Add(asignatura);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> ExisteDuplicado(Asignaturas asignatura)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Asignaturas.AnyAsync(a => a.Nombre == asignatura.Nombre && a.AsignaturaID != asignatura.AsignaturaID);
    }

    private async Task<bool> Modificar(Asignaturas asignatura)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Asignaturas.Update(asignatura);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int asignaturaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Asignaturas.AsNoTracking().Where(a => a.AsignaturaID == asignaturaId).ExecuteDeleteAsync() > 0;
    }

    public async Task<Asignaturas?> Buscar(int asignaturaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Asignaturas.FirstOrDefaultAsync(a => a.AsignaturaID == asignaturaId);
    }

    public async Task<List<Asignaturas>> Listar(Expression<Func<Asignaturas, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Asignaturas.Where(criterio).AsNoTracking().ToListAsync();
    }
}