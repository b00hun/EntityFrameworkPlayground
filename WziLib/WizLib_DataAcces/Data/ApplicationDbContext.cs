﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizLib_Models.Models;

namespace WizLib_DataAcces.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        //Fluent Sets
        public DbSet<Fluent_BookDetail> Fluent_BookDetails { get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.Author_Id, ba.Book_Id });
            
            //BookDetails
            modelBuilder.Entity<Fluent_BookDetail>().HasKey(b=>b.BookDetail_Id);
            modelBuilder.Entity<Fluent_BookDetail>().Property(b=> b.NumberOfChapters).IsRequired();
           
            

            //Book
            modelBuilder.Entity<Fluent_Book>().HasKey(b=>b.Book_Id);
            modelBuilder.Entity<Fluent_Book>().Property(b=>b.ISBN).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<Fluent_Book>().Property(b => b.Title).IsRequired();
            modelBuilder.Entity<Fluent_Book>().Property(b => b.Price).IsRequired();
            //One to one Relation Book-bookDetail
            modelBuilder.Entity<Fluent_Book>()
                .HasOne(b => b.Fluent_BookDetail).WithOne(b => b.Fluent_Book).HasForeignKey<Fluent_Book>("BookDetail_Id");

            //Author
            modelBuilder.Entity<Fluent_Author>().HasKey(b => b.Author_Id);
            modelBuilder.Entity<Fluent_Author>().Property(b => b.LastName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(b => b.FirstName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Ignore(b => b.FullName);

            //Publisher
            modelBuilder.Entity<Fluent_Publisher>().HasKey(b => b.Publisher_Id);
            modelBuilder.Entity<Fluent_Publisher>().Property(b=>b.Name).IsRequired();
            modelBuilder.Entity<Fluent_Publisher>().Property(b => b.Location).IsRequired();

            //Category table name and coilumn name
            modelBuilder.Entity<Category>().ToTable("Tbl_Category");
            modelBuilder.Entity<Category>().Property(b => b.Name).HasColumnName("CategoryName");

            //One to one Relation Book-bookDetail
            


        }
    }
}
