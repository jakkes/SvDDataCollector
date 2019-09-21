using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Collection.Models;
using System;

namespace Collection.DbContexts
{
    public class ArticleContext : DbContext {
        public DbSet<Summary> Summaries { get; set; }

        private static string ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (string.IsNullOrEmpty(ConnectionString)) {
                optionsBuilder.UseNpgsql("Host=;Database=;Username=;Password=");
            } else {
                optionsBuilder.UseNpgsql(ConnectionString);
            }
        }
    }
}