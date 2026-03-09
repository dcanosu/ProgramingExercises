using Backend;
public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("Welcome to the Matrix and Hourglass Generator!");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Generate a Matrix");
            Console.WriteLine("2. Generate an Hourglass");
            Console.WriteLine("3. Exit");
            Console.Write("\nChoose an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunMatrix();
                    break;
                case "2":
                    RunHourglass();
                    break;
                case "3":
                    Console.WriteLine("\nGoodbye! Thanks for using the system.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    break;
            }
        }
    }

    public static void RunMatrix()
    {
        Console.Write("What size do you want the matrix to be?: ");
        string? input = Console.ReadLine();

        try
        {
            int size = int.Parse(input ?? "");
            Matrix myMatrix = new Matrix(size);

            Console.WriteLine("\n--- Full Matrix ---");
            Console.WriteLine();
            myMatrix.Draw();

            Console.WriteLine("\n--- Lower Triangular Matrix ---");
            Console.WriteLine();
            myMatrix.Draw(onlyLower: true);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static void RunHourglass()
    {

        Console.Write("Enter hourglass size (odd): ");
        string? input = Console.ReadLine();

        try
        {
            int size = int.Parse(input ?? "");
            Hourglass myGlass = new Hourglass(size);

            Console.WriteLine("\n--- Full Reference Matrix ---");
            Console.WriteLine();
            myGlass.Draw(onlyHourglass: false);

            Console.WriteLine("\n--- Hourglass Pattern ---");
            Console.WriteLine();
            myGlass.Draw(onlyHourglass: true);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n{ex.Message}");
        }

    }
}