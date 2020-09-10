
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.DTO
{
    public class DB:DbContext
    {
        public DB(DbContextOptions<DB> options)
          : base(options)
        { }

        public DbSet<MonHoc> MonHocs { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
