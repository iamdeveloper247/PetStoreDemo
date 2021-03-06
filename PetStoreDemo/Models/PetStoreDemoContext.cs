﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStoreDemo.Models
{
    public class PetStoreDemoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PetStoreDemoContext() : base("name=PetStoreDemoContext")
        {
        }

        public DbSet<PetStoreDemo.Models.Pet> Pets { get; set; }
        public DbSet<PetStoreDemo.Models.Status> Status { get; set; }
        public DbSet<PetStoreDemo.Models.User> Users { get; set; }
        public DbSet<FilePath> FilePaths { get; set; }

    }
}
