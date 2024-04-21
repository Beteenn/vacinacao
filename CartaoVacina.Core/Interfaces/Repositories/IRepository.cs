﻿using CartaoVacina.Core.Entities;

namespace CartaoVacina.Core.Interfaces.Repositories;

public interface IRepository<TEntidade> where TEntidade : Entity
{
    Task AddAsync(TEntidade entidade);
    Task UpdateAsync(TEntidade entidade);
    Task DeleteAsync(TEntidade entidade);
}
