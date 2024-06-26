﻿namespace CartaoVacina.Core.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
