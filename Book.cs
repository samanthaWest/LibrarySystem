using System;

// Class Import(s)

namespace Book
{
	public class Book
	{
		private int bookId;
		private string title;
		private string summary;

		private int libraryId;
		private Library.Library library;

		// Default constructor
		public Book()
		{
		}

		// Constructor 
		public Book(int bookId, string title, string summary, Library.Library library)
        {
			this.bookId = bookId;
			this.title = title;
			this.summary = summary;
			this.library = library;
			this.libraryId = library.LibraryId;
        }

		// Get & Set Book ID
		public int BookId
        {
			get { return bookId; }
			set { bookId = value; }
		}

		// Get and Set Book Title
		public string Title
        {
			get { return title; }
			set { title = value; }
		}

		// Get and Set Book Summary
		public string Summary
        {
			get { return summary; }
			set { summary = value; }
		}

		// Return library object book belongs too
		public Library.Library Library
        {
			get { return library; }
			set { library = value; }
		}

		// Return library id book belongs too
		public int LibraryId
        {
			get { return libraryId; }
			set { libraryId = value; }
		}

		// Return book object
		public Book getBook()
        {
			return this;
        }

		// Override output to print Id + title + summary
		public override string ToString()
		{
			return this.bookId.ToString() + " - " + this.title + ": \n\t" + this.summary + "\n";
		}

		// Destructor 
		~Book()
        {

        }
	}
}
