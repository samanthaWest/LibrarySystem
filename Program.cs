using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.IO;

// Class Import(s)
using Library;
using Book;
using Utils;
using Menu;
using CustomErrors;

namespace Assignment_01_PRO670
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean decision = true;
            String userInput;

            // Declare list of objects type library and book to store incoming csv data
            List<Book.Book> books = new List<Book.Book>();
            List<Library.Library> libraries = new List<Library.Library>();

            // Declare csv reader object to read and set library and book objects
            Utils.LibraryReader file_libraries = new Utils.LibraryReader("Libraries.txt");
            Utils.BookReader file_books = new Utils.BookReader("LibraryBooks.txt");

            // Read data from csv files
            file_libraries.ReadFile(libraries);
            file_books.ReadFile(books);

            // Add books to their corresponding libraries
            foreach (Library.Library library in libraries)
            {
                foreach (Book.Book book in books)
                {
                    // Add book to library if matches library id & assign library to book
                    if (book.LibraryId == library.LibraryId)
                    {
                        library.AddBook(book);
                    }
                }
            }

            // Init Menu
            Menu.Menu menu = new Menu.Menu();

            while (decision)
            {
                userInput = menu.MenuPrompt();
                switch (userInput)
                {
                    // List Books
                    case "0":
                        menu.PrintLibraries(libraries);
                        break;
                    // Add Book
                    case "1":
                        try
                        {
                            menu.AddBook(libraries, books);
                        }
                        catch (CustomErrors.BookNotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    // Update Book
                    case "2":
                        try
                        {
                            menu.UpdateBook(libraries, books);
                        }
                        catch (CustomErrors.BookNotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    // Remove Book
                    case "3":
                        try
                        {
                            menu.RemoveBook(libraries, books);
                        } catch (CustomErrors.BookNotFoundException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    // Exit Program
                    case "4":
                        // Break Loop & Exit Program
                        decision = menu.ExitMenu(file_libraries, file_books, books, libraries);
                        break;
                    // Default selection
                    default:
                        menu.DefaultSelectionMessage();
                        break;
                }
            }

        }
    }
}
