using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using BookManager.Application;
using BookManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookManager
{
    public class BooksDbContext
        : DbContext, IBookDbContext
    {
        private const string ConnectionString = "";

        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
        //.UseLazyLoadingProxies()
                .UseSqlServer(ConnectionString);
    }
}

