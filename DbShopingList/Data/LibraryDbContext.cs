﻿using DbShopingList.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbShopingList.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
