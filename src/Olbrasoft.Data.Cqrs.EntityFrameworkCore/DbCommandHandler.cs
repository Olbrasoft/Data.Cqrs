﻿using System;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Dispatching.Abstractions;
using Olbrasoft.Mapping;

namespace Olbrasoft.Data.Cqrs.EntityFrameworkCore
{
    public abstract class DbCommandHandler<TCommand, TResult, TContext, TEntity> : CommandHandler<TCommand, TResult>
        where TCommand : IRequest<TResult> where TContext : DbContext where TEntity : class
    {
        private readonly IDbContextFactory<TContext> _contextFactory;

        private TContext _context;
        private DbSet<TEntity> _entities;

        protected TContext Context => _context ??= _contextFactory.CreateDbContext();
        protected DbSet<TEntity> Entities => _entities ??= Context.Set<TEntity>();

        protected DbCommandHandler(IMapper mapper, IDbContextFactory<TContext> factory) : base(mapper)
        {
            _contextFactory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
    }

    public abstract class DbCommandHandler<TCommand, TContext, TEntity> : DbCommandHandler<TCommand, bool, TContext, TEntity>
        where TCommand : IRequest<bool> where TContext : DbContext where TEntity : class
    {
        protected DbCommandHandler(IMapper mapper, IDbContextFactory<TContext> factory) : base(mapper, factory)
        {
        }
    }
}