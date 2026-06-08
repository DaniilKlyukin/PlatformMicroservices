using Microsoft.EntityFrameworkCore;
using PlatformService.Data.Interfaces;
using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepo : IPlatformRepo
{
    private readonly AppDbContext _context;

    public PlatformRepo(AppDbContext context)
    {
        _context = context;
    }

    public void Create(Platform platform)
    {
        ArgumentNullException.ThrowIfNull(platform);

        _context.Platforms.Add(platform);
    }

    public IEnumerable<Platform> GetAll()
    {
        return _context.Platforms.AsNoTracking().ToList();
    }

    public Platform? GetById(int id)
    {
        return _context.Platforms.Find(id);
    }

    public bool SaveChanges()
    {
        return _context.SaveChanges() >= 0;
    }
}