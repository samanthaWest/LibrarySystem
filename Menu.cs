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

        public Menu()
        {
        }

        public string MenuPrompt()
        {
            Console.WriteLine("Welcome to the Library, choose a section and Happy Reading! :)" +
                                   " \n\n \t [0] List Books" +
                                   " \n \t [01] Add Book" +
                                   " \n \t [02] Update Book" +
                                   " \n \t [03] Remove Book" +
                                   " \n \t [04] Exit");

            this.userInput = Console.ReadLine();

            return UserInput;
        }

        public string UserInput
        {
            get { return this.userInput; }
            set { this.userInput = value; }
        }

        public void PrintLibraries(List<Library.Library> libraries)
        {
            Console.WriteLine("LIBRARY LIST\n -----------------------------------------------");

            // Print out Libraries and books
            foreach (Library.Library library in libraries)
            {
                Console.WriteLine(library + "\n\n");
            }

            Console.WriteLine("--------------------------------------------------------------");
        }

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

        public Boolean ExitMenu(Utils.LibraryReader file_libraries, Utils.BookReader file_books, List<Book.Book> books, List<Library.Library> libraries)
        {
            // Update files with any changes before closing program to persist data
            file_books.updateFile(books);
            file_libraries.updateFile(libraries);
            return false;
        }

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

        public int SelectBook(List<Book.Book> books)
        {
            PrintBooks(books);

            // Prompt user to choose book by id
            Console.Write("Choose book by id: ");
            string bookSelected = Console.ReadLine();

            int index = books.FindIndex(b => b.BookId.ToString() == bookSelected.ToString());

            return index;
        }

        public void RemoveBook(List<Library.Library> libraries, List<Book.Book> books)
        {
            int index = SelectBook(books);

            if (index == -1) throw new CustomErrors.BookNotFoundException("ERROR: Book not found. Returning to main menu. \n");
            
            int libraryIndex = libraries.FindIndex(l => l.LibraryId.ToString() == books[index].LibraryId.ToString());

            // Remove book from library
            libraries[libraryIndex] = libraries[libraryIndex] - books[index];
            books.RemoveAt(index);
            Console.WriteLine("Book successfully removed from library.");
            
        }

        public void AddBook(List<Library.Library> libraries, List<Book.Book> books)
        {
            int index = SelectLibrary(libraries);

            if (index == -1) throw new CustomErrors.BookNotFoundException("ERROR: Library not found. Returning to main menu. \n");

            // Add init values for new book
            Book.Book bookTemp = new Book.Book();
            bookTemp.BookId = (books.Count) + 1;
            bookTemp.Library = libraries[index];
            bookTemp.LibraryId = libraries[index].LibraryId;

            // Prompt User to add book details
            Console.WriteLine("Add a book by adding the following details (press enter to go onto next question):");
            Console.Write("Enter book title: ");
            bookTemp.Title = Console.ReadLine();
            Console.Write("Enter book summary");
            bookTemp.Summary = Console.ReadLine();

            // Add books to book list and corresponding library
            books.Add(bookTemp);
            bookTemp.Library = libraries[index] + bookTemp;
            Console.WriteLine("Book has been added to the library ~~ Noice ~~");
            
        }

        public void UpdateBook(List<Library.Library> libraries, List<Book.Book> books)
        {
            int index = SelectBook(books);

            if (index == -1) throw new CustomErrors.BookNotFoundException("ERROR: Book not found. Returning to main menu. \n");

            // Promot User to Enter new Book details
            Console.Write("Enter new title: ");
            books[index].Title = Console.ReadLine();
            Console.Write("Enter new summary: ");
            books[index].Summary = Console.ReadLine();

            Console.WriteLine("Book has been successfully updated :D");
        }

        public void DefaultSelectionMessage()
        {
            Console.WriteLine("Please select valid option \n");
        }

        ~Menu()
        {

        }
    }

}