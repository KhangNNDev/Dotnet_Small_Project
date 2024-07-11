
public class Program
{
    public static void Menu()
    {
        System.Console.WriteLine("1. Manage Category");
        System.Console.WriteLine("2. Manage Author");
        System.Console.WriteLine("3. Manage Book");
        System.Console.WriteLine("4. Exit");
    }

    public static void subMenu(string type)
    {
        System.Console.WriteLine("1. Add " + type);
        System.Console.WriteLine("2. Update " + type);
        System.Console.WriteLine("3. Delete " + type);
        System.Console.WriteLine("4. View all " + type);
        System.Console.WriteLine("5. View detail " + type);
        System.Console.WriteLine("6. Back");
    }


    public static void Main()
    {
        System.Console.WriteLine("Welcome to book management console");
        string option = "";
        do
        {
            Menu();
            System.Console.WriteLine("Select your option (1 to 4): ");
            option = Console.ReadLine();
            string type = null;
            switch (option)
            {
                case "1":
                    type = "Category";
                    break;
                case "2":
                    type = "Author";
                    break;
                case "3":
                    type = "Book";
                    break;
            }
            string subOption = "";
            do
            {
                string action = "";
                subMenu(type);
                System.Console.WriteLine("Select your option (1 to 6): ");
                subOption = Console.ReadLine();
                int result = 0;
                if (option == "1")
                {
                    CategoryRepository categoryRepository = new CategoryRepository();
                    //Categoy
                    switch (subOption)
                    {
                        case "1":
                            action = "Add";
                            System.Console.WriteLine("Input Category Name: ");
                            CategoryAddDTO category = new CategoryAddDTO();
                            category.Name = Console.ReadLine();
                            result = categoryRepository.Add(category);
                            break;
                        case "2":
                            action = "Update";
                            break;
                        case "3":
                            action = "Delete";
                            break;
                        case "4":
                            action = "View All";
                            break;
                        case "5":
                            action = "View Detail";
                            break;
                    }
                }
                else if (option == "2")
                {
                    //Author
                    AuthorRepository authorRepository = new AuthorRepository();

                    switch (subOption)
                    {
                        case "1":
                            action = "Add";
                            System.Console.WriteLine("Input Author Name: ");
                            AuthorAddDTO authorAdd = new AuthorAddDTO();
                            authorAdd.Name = Console.ReadLine();
                            result = authorRepository.Add(authorAdd);
                            break;
                        case "2":
                            action = "Update";
                            AuthorUpdateDTO authorUpdate = new AuthorUpdateDTO();
                            System.Console.WriteLine("Input Author ID: ");
                            authorUpdate.Id = int.Parse(Console.ReadLine());
                            System.Console.WriteLine("Input Author Name: ");
                            authorUpdate.Name = Console.ReadLine();
                            result = authorRepository.Update(authorUpdate);
                            break;
                        case "3":
                            action = "Delete";
                            System.Console.WriteLine("Input Author ID: ");
                            int deleteId = int.Parse(Console.ReadLine());
                            authorRepository.Delete(deleteId);
                            break;
                        case "4":
                            action = "View All";
                            List<AuthorListingDTO> list = authorRepository.ViewAll();
                            System.Console.WriteLine("Id \t Name");
                            foreach (AuthorListingDTO item in list)
                            {
                                System.Console.WriteLine(item.Id + " \t " + item.Name);
                            }
                            break;
                        case "5":
                            action = "View Detail";
                            System.Console.WriteLine("Input Author ID: ");
                            int detailId = int.Parse(Console.ReadLine());
                            AuthorDetailDTO author = authorRepository.ViewDetail(detailId);
                            if (author != null)
                            {
                                System.Console.WriteLine("Id \t Name");
                                System.Console.WriteLine(author.Id + " \t " + author.Name);
                            }
                            else System.Console.WriteLine("No Author Found");
                            break;
                    }
                }
                else if (option == "3")
                {
                    BookRepository bookRepository = new BookRepository();
                    //Book
                    switch (subOption)
                    {
                        case "1":
                            action = "Add";
                            break;
                        case "2":
                            action = "Update";
                            break;
                        case "3":
                            action = "Delete";
                            break;
                        case "4":
                            action = "View All";
                            break;
                        case "5":
                            action = "View Detail";
                            break;
                    }
                }
                if (result > 0)
                    System.Console.WriteLine(type + " " + action + " successfully");
                else
                    System.Console.WriteLine(type + " " + action + " fail");

            } while (subOption != "6");

        }
        while (option != "4");
        System.Console.WriteLine("Program existed");
    }
}
