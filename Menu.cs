using System;
using System.Collections.Generic;

// Class Import(s)
using Library;
using Book;
using CustomErrors;

namespace Menu
{
    public class Menu
    {
        private string userInput;

        // Default constructor
        public Menu()
        {
        }

        // Print menu prompt ofr user selection
        public string MenuPrompt()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nWelcome to the Library. Choose a selection to begin, Happy Reading! :)" +
                                   " \n\n \t [0] List Books" +
                                   " \n \t [1] Add Book" +
                                   " \n \t [2] Update Book" +
                                   " \n \t [3] Remove Book" +
                                   " \n \t [4] Exit");

            Console.Write("\nUser selection:\n");
            this.userInput = Console.ReadLine();

            return UserInput;
        }

        // Prompt user input for menu selection
        public string UserInput
        {
            get { return this.userInput; }
            set { this.userInput = value; }
        }

        // Print a list of libraries
        public void PrintLibraries(List<Library.Library> libraries)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("LIBRARIES\n-----------------------------------------------");

            // Print out Libraries and books
            foreach (Library.Library library in libraries)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(library);
            }

            Console.WriteLine("--------------------------------------------------------------");
        }

        // Print a list of books
        public void PrintBooks(List<Book.Book> books)
        {
            Console.WriteLine("Book LIST\n --------------------------------------------------");

            // Print out Libraries and books
            foreach (Book.Book book in books)
            {
                Console.WriteLine(book + "\n");
            }

            Console.WriteLine("--------------------------------------------------------------");
        }

        // Update files with user changes and exit program
        public Boolean ExitMenu(Utils.LibraryReader file_libraries, Utils.BookReader file_books, List<Book.Book> books, List<Library.Library> libraries)
        {
            // Update files with any changes before closing program to persist data
            file_books.updateFile(books);
            file_libraries.updateFile(libraries);
            return false;
        }

        // Prompt user to select library form list of availible libraries
        public int SelectLibrary(List<Library.Library> libraries)
        {
            String libraryIdSelected;

            // Prompt user to choose library by id
            Console.WriteLine("Choose a library");
            foreach (Library.Library library in libraries)
            {
                Console.WriteLine(library.LibraryId + ": " + library.Address + "\n");
            }

            libraryIdSelected = Console.ReadLine();

            int index = libraries.FindIndex(l => l.LibraryId.ToString() == libraryIdSelected);

            return index;
        }

        // Prompt user to select book from list of availible books
        public int SelectBook(List<Book.Book> books)
        {
            PrintBooks(books);

            // Prompt user to choose book by id
            Console.Write("Choose book by id: ");
            string bookSelected = Console.ReadLine();

            int index = books.FindIndex(b => b.BookId.ToString() == bookSelected.ToString());

            return index;
        }

        // Prompt user to remove book from library
        public void RemoveBook(List<Library.Library> libraries, List<Book.Book> books)
        {
            int libraryIndex = SelectLibrary(libraries);
            int bookId = libraries[libraryIndex].RemoveBook();

            int bookIndex = books.FindIndex(b => b.BookId.ToString() == bookId.ToString());
            books.RemoveAt(bookIndex);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SUCCESS: Book remove from library.");
        }

        // Prompts user to add book to library
        public void AddBook(List<Library.Library> libraries, List<Book.Book> books)
        {
            int index = SelectLibrary(libraries);

            if (index == -1) throw new CustomErrors.BookNotFoundException("ERROR: Library not found. Returning to main menu. \n");

            Book.Book bookTemp = libraries[index].AddBook();
            books.Add(bookTemp);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SUCCESS: Book added to library.");
        }

        // Prompts user to update book from library
        public void UpdateBook(List<Library.Library> libraries, List<Book.Book> books)
        {
            int index = SelectLibrary(libraries);

            if (index == -1) throw new CustomErrors.BookNotFoundException("ERROR: Library not found. Returning to main menu. \n");

            Book.Book tempBook = libraries[index].UpdateBook();
            int bookIndex = books.FindIndex(b => b.BookId.ToString() == tempBook.BookId.ToString());
            

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("SUCCESS: Book has been updated.");
        }

        // Default message if valid selection not made by user
        public void DefaultSelectionMessage()
        {
            Console.WriteLine("Please select valid option \n");
        }

        ~Menu()
        {

        }
    }

}