﻿using CartaoVacina.Core.Entities;
using CartaoVacina.Core.Interfaces.Repositories;
using CartaoVacina.DataAccess.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CartaoVacina.DataAccess.Repositories;

public sealed class PessoaRepository : Repository<Pessoa>, IPessoaRepository
{
    
    public PessoaRepository(CartaoVacinaContext context) : base(context) { }

    public async Task<IEnumerable<Pessoa>> ListarPessoas()
    {
        return await _context.Pessoas.ToListAsync();
    }
}
