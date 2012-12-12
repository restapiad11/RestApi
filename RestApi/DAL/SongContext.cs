using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using RestApi.Models;

namespace RestApi.DAL
{
    public class SongContext : DbContext
    {
        public DbSet<Company> Companys { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DbLog> DbLogs { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Statement> Statements { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tags> Tags { get; set; }

        public SongContext()
            : base("context")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SongContext, Configuration>());
        }
    }
}