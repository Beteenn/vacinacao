using System.Security.Cryptography;

namespace CartaoVacina.Core.Entities;

public abstract class Entity
{
    public long Id { get; private set; }
    public DateTime CriadoEm { get; private set; }

    protected Entity() { }

    protected Entity(long id) => Id = id;
}
