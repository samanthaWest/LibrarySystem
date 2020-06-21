using System;

using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

using Book;
using Library;


namespace DB_Library
{
	public class LibraryContext : DbContext
	{
		public LibraryContext()
		{
		}
		public DbSet<Library.Library> Libraries { get; set; }
		public DbSet<Book.Book> Books { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite(@"Data Source=C:\Users\Samantha\source\repos\Assignment_01_PRO670\Assignment_01_PRO670\library.db");
	}
}

// Test Code

// Testing with SQLite
//using (var db = new DB_Library.LibraryContext())
//{
//DateTime dt = DateTime.Now;
//string keelAdress = "4700 Keele Street, M3J-1P3";
//// Create
//Console.WriteLine("Adding a new library ... " + dt);
//db.Add(new Library.Library(5, keelAdress));
//db.SaveChanges();

//Console.WriteLine("Querying for a library");
//var library = db.Libraries
//    .Where(l => l.Address == keelAdress)
//    .OrderBy(b => b.LibraryId)
//    .First();
//Console.Write(library.LibraryId);

//Console.WriteLine("Updating the library and adding a post");
//library.Address = $"{keelAdress} (verified at: {dt})";

//Book.Book bt = new Book.Book(06, "The C# Programming Language", "This book was central to the development and popularization of the C programming language and is still widely read and used today.", library);
//library += bt;

//db.SaveChanges();

// Delete
//Console.WriteLine("Delete the library");
//db.Remove(library);
//db.SaveChanges();
//}
