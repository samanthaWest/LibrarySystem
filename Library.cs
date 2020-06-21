using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

// Class Import(s)
using Book;

namespace Library
{
	public class Library
	{
		private int libraryId;
		private string address;
		private List<Book.Book> books;

		public Library()
		{
			this.books = new List<Book.Book>();
		}

		public Library(int libraryId, string address)
        {
			this.books = new List<Book.Book>();
			this.LibraryId = libraryId;
			this.Address = address;
        }

		public int LibraryId
		{
			get { return libraryId; }
			set { libraryId = value; }
		}

		public string Address
		{
			get { return address; }
			set { address = value; }
		}

		// Adds book to library
		public void AddBook(Book.Book book)
        {
			this.books.Add(book);
        }

		public static Library operator+(Library lib, Book.Book b)
        {
			Library lib_copy = lib;
			lib_copy.AddBook(b);
			return lib_copy;
        }

		// Removes book from library
		public void RemoveBook(Book.Book book)
		{
			int bookIndex = books.FindIndex(b => b.BookId.ToString() == book.BookId.ToString());
			books.RemoveAt(bookIndex);
		}
		public static Library operator -(Library lib, Book.Book b)
		{
			Library lib_copy = lib;
			lib_copy.RemoveBook(b);
			return lib_copy;
		}

		// Returns book if found in library
		public Book.Book SearchLibrary(int id)
        {
			return null;
        } 

		public List<Book.Book> sortBooks()
        {
			List<Book.Book> books = this.books.OrderBy(b => b.Title).ToList();
			return books;
		}

		// Returns a reference to the current library
		public Library getLibrary()
        {
			return this;
        }

        public override string ToString()
        {
			String temp = "Library: " + this.libraryId.ToString() + " - " + this.address + "\n-----------------------------------------------\n";
			List<Book.Book> test = this.sortBooks();
			for (int i = 0; i < test.Count(); i++)
            {
				temp += test.ElementAt(i).ToString();
            }

			return temp;
	    }

        ~Library()
		{

		}

	}
}
