﻿using System;
using Microsoft.EntityFrameworkCore;
using Olbrasoft.Dispatching.Abstractions;
using Olbrasoft.Mapping;
using System.Linq;

namespace Olbrasoft.Data.Cqrs.EntityFrameworkCore
{
    public abstract class DbQueryHandler<TQuery, TResult, TContext, TEntity> : QueryHandler<TQuery, TResult> where TQuery : IRequest<TResult> where TContext : DbContext where TEntity : class
    {
        private readonly IDbContextFactory<TContext> _contextFactory;
        private TContext _context;
        private IQueryable<TEntity> _entities;

        protected TContext Context => _context ??= _contextFactory.CreateDbContext();
        protected IQueryable<TEntity> Entities => _entities ??= Context.Set<TEntity>();

        protected DbQueryHandler(IProjector projector, IDbContextFactory<TContext> factory) : base(projector)
        {
            _contextFactory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
    }

    public abstract class DbQueryHandler<TQuery, TContext, TEntity> : QueryHandler<TQuery> where TQuery : IRequest<bool> where TContext : DbContext where TEntity : class
    {
        private readonly IDbContextFactory<TContext> _contextFactory;
        private TContext _context;
        private IQueryable<TEntity> _entities;

        protected TContext Context => _context ??= _contextFactory.CreateDbContext();
        protected IQueryable<TEntity> Entities => _entities ??= Context.Set<TEntity>();

        protected DbQueryHandler(IDbContextFactory<TContext> factory)
        {
            _contextFactory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
    }
}