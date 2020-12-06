using System;
using FigureStorage.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FigureStorage.Repo
{
    public class RepositoryContextFactory : IRepositoryContextFactory
    {
        private DbContextOptionsBuilder _builder = new DbContextOptionsBuilder();
        private readonly Action<DbContextOptionsBuilder> _optionsBuilder;

        public RepositoryContextFactory(Action<DbContextOptionsBuilder> optionsBuilder = null)
        {
            _optionsBuilder = optionsBuilder;
        }
        public RepositoryContext CreateDbContext()
        {
            _optionsBuilder?.Invoke(_builder);
            
            return new RepositoryContext(_builder.Options);
        }
    }
}