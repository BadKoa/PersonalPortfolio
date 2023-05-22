using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;

namespace firsttrywebsite.Models
{
    public class UserContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }


        public string DbPath { get;}

        public UserContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "mails.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
    }
    
    public class User
    {
        [Key, Required]
        public string ?Name { get; set; }
        [Required]
        public string ?Email { get; set; }

    }


}
