using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

// Class Import(s)
using Book;
using CustomErrors;

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
			lib_copy.books.Add(b);
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

		// Overrides printing to display library 
        public override string ToString()
        {
			String temp = "Library: " + this.libraryId.ToString() + " - " + this.address + "\n-----------------------------------------------\n";
			List<Book.Book> booksSorted = this.sortBooks();

			for (int i = 0; i < booksSorted.Count(); i++)
            {
				temp += booksSorted.ElementAt(i).ToString();
            }

			return temp;
	    }

		// Print list of books in library
		public void PrintBooks()
        {
			Console.WriteLine("Book LIST\n --------------------------------------------------");

			// Print list of books in library
			foreach (Book.Book book in this.books)
			{
				Console.WriteLine(book + "\n");
			}

			Console.WriteLine("--------------------------------------------------------------");
		}

		// Prompt user to select book from library
		public int SelectBook()
        {
			this.PrintBooks();

			// Prompt user to choose book by id
			Console.Write("Choose book by id: ");
			string bookSelected = Console.ReadLine();

			int index = books.FindIndex(b => b.BookId.ToString() == bookSelected.ToString());

			return index;
		}

		// Prompt user to remove book from library
		public int RemoveBook()
        {
			int index = this.SelectBook();
			int bookIndex = this.books[index].BookId;

			if (index == -1) throw new CustomErrors.BookNotFoundException("ERROR: Book not found. Returning to main menu. \n");

            // Remove book from library
            try
            {
				this.books.RemoveAt(index);
            } catch(Exception ex)
            {
				throw ex;
            }

			return bookIndex;
		}

		// Prompt user to add book to library
		public Book.Book AddBook()
        {
			// Add init values for new book
			Book.Book bookTemp = new Book.Book();
			bookTemp.BookId = (this.books.Count) + 1;
			bookTemp.Library = this;
			bookTemp.LibraryId = this.LibraryId;

			// Prompt User to add book details
			Console.WriteLine("Add a book by adding the following details (press enter to go onto next question): ");
			Console.Write("Enter book title: ");
			bookTemp.Title = Console.ReadLine();
			Console.Write("Enter book summary: ");
			bookTemp.Summary = Console.ReadLine();

			// Add books to book list and corresponding library
			bookTemp.Library += bookTemp;

			return bookTemp;
		}

		public Book.Book UpdateBook()
        {
			int index = this.SelectBook();

			if (index == -1) throw new CustomErrors.BookNotFoundException("ERROR: Book not found. Returning to main menu. \n");

			// Promot User to Enter new Book details
			Console.Write("Enter new title: ");
			this.books[index].Title = Console.ReadLine();
			Console.Write("Enter new summary: ");
			this.books[index].Summary = Console.ReadLine();

			return this.books[index];
		}

        ~Library()
		{

		}

	}
}
