using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TazeCase.Form.Data.Context
{
    public class FormDataContext: DbContext
    {
        public FormDataContext(DbContextOptions<FormDataContext> options) : base(options)
        {

        }

        public DbSet<Core.Entities.Form> Forms { get; set; }
        public DbSet<Core.Entities.FormData> FormData { get; set; }
        public DbSet<Core.Entities.FormField> FormFields { get; set; }
        public DbSet<Core.Entities.FormData> FormDatas { get; set; }
        public DbSet<Core.Entities.FormDataValue> FormDataValues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Core.Entities.Form>(entity =>
            {
                entity.HasQueryFilter(e => !e.IsDeleted);
            });

            modelBuilder.Entity<Core.Entities.FormData>(entity =>
            {
                entity.HasQueryFilter(e => !e.IsDeleted);
            });
            modelBuilder.Entity<Core.Entities.FormField>(entity =>
            {
                entity.HasQueryFilter(e => !e.IsDeleted);
            });
            modelBuilder.Entity<Core.Entities.FormData>(entity =>
            {
                entity.HasQueryFilter(e => !e.IsDeleted);
            });
            modelBuilder.Entity<Core.Entities.FormDataValue>(entity =>
            {
                entity.HasQueryFilter(e => !e.IsDeleted);
            });
        }
    }
}
