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

		public Book()
		{
		}

		public Book(int bookId, string title, string summary, Library.Library library)
        {
			this.bookId = bookId;
			this.title = title;
			this.summary = summary;
			this.library = library;
			this.libraryId = library.LibraryId;
        }

		public int BookId
        {
			get { return bookId; }
			set { bookId = value; }
		}

		public string Title
        {
			get { return title; }
			set { title = value; }
		}

		public string Summary
        {
			get { return summary; }
			set { summary = value; }
		}

		public Library.Library Library
        {
			get { return library; }
			set { library = value; }
		}

		public int LibraryId
        {
			get { return libraryId; }
			set { libraryId = value; }
		}

		public Book getBook()
        {
			return this;
        }

		public override string ToString()
		{
			return this.bookId.ToString() + " - " + this.title + ": \n\t" + this.summary + "\n";
		}

		~Book()
        {

        }
	}
}
