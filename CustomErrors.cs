using System;

namespace CustomErrors
{
	public class LibraryNotFoundException : Exception
	{
		public LibraryNotFoundException()
		{
		}

		public LibraryNotFoundException(string message)
		: base(message)
		{
		}
	}

	public class BookNotFoundException : Exception
	{
		public BookNotFoundException()
		{
		}
		public BookNotFoundException(string message)
		: base(message)
		{
		}
	}
}
