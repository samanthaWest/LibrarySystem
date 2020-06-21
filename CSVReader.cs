using System;
using System.Collections.Generic;
using System.IO;

// Class Import(s)
using Library;
using Book;

namespace Utils
{
	public class CSVReader
	{
		protected string fileName;

		protected StreamReader reader;
		protected StreamWriter writer;

		public CSVReader()
		{
		}

		public CSVReader(string fileName)
		{
			this.fileName = fileName;
		}

		public string FileName
		{
			get { return fileName; }
			set { fileName = value; }
		}

		~CSVReader()
		{
			this.reader.Close();
			this.writer.Close();
		}
	}

	public class LibraryReader : CSVReader
	{
        public LibraryReader(string fileName) : base(fileName)
        {
        }

        LibraryReader()
        {

        }

		public List<Library.Library> ReadFile(List<Library.Library> libraries)
		{
			List<Library.Library> libs = libraries;

			try
			{
				this.reader = new StreamReader(@"C:\Users\Samantha\source\repos\Assignment_01_PRO670\Assignment_01_PRO670\" + this.fileName);
			} catch (Exception e)
            {
				Console.WriteLine(e);
            }

			using (reader)
			{
				while (!reader.EndOfStream)
				{
					Library.Library tempLib = new Library.Library();

					var line = reader.ReadLine();
					var values = line.Split(',');

					tempLib.LibraryId = Int16.Parse(values[0]);
					tempLib.Address = values[1];

					libs.Add(tempLib);
				}
			}
			return libs;
		}
		public void updateFile(List<Library.Library> libraries)
		{
			try
			{
				this.writer = new StreamWriter(@"C:\Users\Samantha\source\repos\Assignment_01_PRO670\Assignment_01_PRO670\" + this.fileName);
			} catch (Exception e)
            {
				Console.WriteLine(e);
            }

			using (writer)
			{
				foreach (Library.Library library in libraries)
				{
					writer.WriteLine(library.LibraryId + "," + library.Address);
				}
			}
		}
	}

	public class BookReader : CSVReader
    {
		BookReader()
		{

		}

		public BookReader(string fileName) : base(fileName)
        {
        }

		public List<Book.Book> ReadFile(List<Book.Book> books)
		{
			List<Book.Book> bks = books;

			try
			{
				this.reader = new StreamReader(@"C:\Users\Samantha\source\repos\Assignment_01_PRO670\Assignment_01_PRO670\" + this.fileName);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			using (reader)
			{
				while (!reader.EndOfStream)
				{
					Book.Book tempBook = new Book.Book();

					var line = reader.ReadLine();
					var values = line.Split(',');

					tempBook.BookId = Int16.Parse(values[0]);
					tempBook.LibraryId = Int16.Parse(values[1]);
					tempBook.Title = values[2];
					tempBook.Summary = values[3];

					bks.Add(tempBook);
				}
			}
			return bks;
		}

		public void updateFile(List<Book.Book> books)
		{
			try
			{
				this.writer = new StreamWriter(@"C:\Users\Samantha\source\repos\Assignment_01_PRO670\Assignment_01_PRO670\" + this.fileName);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			using (writer)
			{
				foreach (Book.Book book in books)
				{
					writer.WriteLine(book.BookId + "," + book.LibraryId + "," + book.Title + "," + book.Summary);
				}
			}
		}
	}
}
