﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ToDo_Data
{
    public partial class ReactAPIContext : DbContext
    {
        public ReactAPIContext()
        {
        }

        public ReactAPIContext(DbContextOptions<ReactAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoryId> CategoryIds { get; set; }
        public virtual DbSet<ToDoItem> ToDoItems { get; set; }
        public virtual DbSet<UserId> UserIds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}