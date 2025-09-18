using System.Resources;
using System.Text;
using HostingSystem.Models;

Console.OutputEncoding = Encoding.UTF8;

List<Reservation> reservations = new List<Reservation>();

while (true)
{
  Console.Clear();
  Console.WriteLine("╔══════════════════════════════════╗");
  Console.WriteLine("║         Hosting System           ║");
  Console.WriteLine("╠══════════════════════════════════╣");
  Console.WriteLine("║ 1. New reservation               ║");
  Console.WriteLine("║ 2. List reservations             ║");
  Console.WriteLine("║ 3. Exit                          ║");
  Console.WriteLine("╚══════════════════════════════════╝");
  Console.Write("\nType your option: ");

  string option = Console.ReadLine();

  switch (option)
  {
    case "1":
      Console.Clear();
      Console.WriteLine("--- Doing a new reservation ---");

      List<Person> people = new List<Person>();
      Console.Write("How many hostages are? ");
      if (int.TryParse(Console.ReadLine(), out int peopleCount) && peopleCount > 0)
      {
        for (int i = 0; i < peopleCount; i++)
        {
          Console.Write($"Type hostage name #{i + 1}: ");
          people.Add(new Person(name: Console.ReadLine()));
        }
      }
      else
      {
        Console.WriteLine("\nInvalid hostage quantity. Returning to main menu.");
        Console.ReadKey();
        break;
      }

      Console.Write("\nType your suite type (Ex: Standard, Premium): ");
      string suiteType = Console.ReadLine();

      Console.Write("Type suite diary value: ");
      if (!decimal.TryParse(Console.ReadLine(), out decimal suiteValue))
      {
        Console.WriteLine("\nInvalid diary value. Returning to main menu.");
        Console.ReadKey();
        break;
      }

      Suite suite = new Suite(suiteType: suiteType, capacity: peopleCount, diaryValue: suiteValue);

      Console.Write("Type reserved days quantity: ");
      if (int.TryParse(Console.ReadLine(), out int reservedDays) && reservedDays > 0)
      {
        Reservation newReservation = new Reservation(reservedDays: reservedDays);
        newReservation.AddSuite(suite);
        newReservation.AddPeople(people);

        reservations.Add(newReservation);

        Console.WriteLine("\nReservation created successfully!");
        Console.WriteLine($"  - Hostages: {newReservation.GetPeopleQuantity()}");
        Console.WriteLine($"  - Reservation Total Value: {newReservation.CalculateDiaryValue():C}"); 
      }
      else
      {
        Console.WriteLine("\nInvalid days quantity. Returning to main menu.");
      }

      Console.WriteLine("\nPress any key to continue...");
      Console.Read();
      break;

    case "2":
      Console.Clear();
      Console.WriteLine("--- Reservation's List ---");
      Console.WriteLine("---------------------");

      if (reservations.Count == 0)
      {
        Console.WriteLine("No reservation founded.");
      }
      else
      {
        int reservationCount = 1;
        foreach (var res in reservations)
        {
          Console.WriteLine($"\nReservation #{reservationCount}:");
          Console.WriteLine($"  - Hostages: {res.GetPeopleQuantity()}");
          Console.WriteLine($"  - Total Diary Value: {res.CalculateDiaryValue():C}");
          reservationCount++;
        }
      }

      Console.WriteLine("\nPress any key to continue...");
      Console.Read();
      break;

    case "3":
      Console.WriteLine("Exiting program...");
      return;

    default:
      Console.WriteLine("Invalid Option! Try again.");
      System.Threading.Thread.Sleep(1500);
      break;
  }
}
