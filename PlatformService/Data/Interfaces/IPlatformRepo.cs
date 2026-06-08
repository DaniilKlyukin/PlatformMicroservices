using PlatformService.Models;

namespace PlatformService.Data.Interfaces;

public interface IPlatformRepo
{
    bool SaveChanges();

    IEnumerable<Platform> GetAll();

    Platform? GetById(int id);

    void Create(Platform platform);
}
