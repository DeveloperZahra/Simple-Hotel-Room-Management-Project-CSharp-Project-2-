using System.Net.NetworkInformation;
using System.Threading.Channels;
using System.Xml.Linq;

namespace Simple_Hotel_Room_Management_Project__CSharp_Project_2__
{
    internal class Program
    {

        // Create the array and add the required variables...
        static int[] roomNumbers = new int[3];
        static double[] roomRates = new double[3];
        static bool[] isReserved = new bool[3];
        static string[] guestNames = new string[3];
        static int[] nights = new int[3];
        static DateTime[] bookingDates = new DateTime[3];
        static int roomCount = 0;
        static void Main(string[] args)
        {

            while (true) //addition the  function types  of the project...
            {
                Console.Clear();
                Console.WriteLine("\nChoose an Array Exercise:");
                Console.WriteLine("1. Add a new room (Room Number, Daily Rate)");
                Console.WriteLine("2. View all rooms (Available and Reserved) ");
                Console.WriteLine("3. Reserve a room for a guest (Guest Name, Room Number, Nights) ");
                Console.WriteLine("4. View all reservations with total cost");
                Console.WriteLine("5. Search reservation by guest name (case-insensitive)  ");
                Console.WriteLine("6. Find the highest-paying guest");
                Console.WriteLine("7. Cancel a reservation by room number ");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                try
                {

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: AddaNewRoom(); break;
                        case 2: ViewAllRooms(); break;
                        case 3: ReserveARoom(); break;
                        case 4: ViewAllReservations(); break;
                        case 5: SearchReservationByGuestName(); break;
                        case 6: HighestPayingGuest(); break;
                        case 7: CancelReservationByRoomNumber(); break;
                        case 0: return;
                        default: Console.WriteLine("Invalid choice! Try again."); break;
                    }
                }
                catch (Exception ex)

                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }


                Console.ReadLine();
            }
        }
        // 1. Add a new room (Room Number, Daily Rate)______
        static void AddaNewRoom()
        {
            try
            {
                char choice;
                do
                {
                   


                } while (choice == 'y' || choice == 'Y');

            }
            catch (Exception e)

            {
                Console.WriteLine($"Invalid to add another student!" + e.Message);

            }

        }

        //2. View all rooms (Available and Reserved) _______
        static void ViewAllRooms()

        {
            try
            {

                if (roomCount == 0)
                {
                    Console.WriteLine("No students available.");
                    return;
                }

                for (int i = 0; i < roomCount; i++)
                {
                    Console.WriteLine($"room: {i + 1}:");
                    Console.WriteLine($"room number: {roomNumbers[i]}");
                    Console.WriteLine($"room rates: {roomRates[i]}");
                    Console.WriteLine($"Reserved: {isReserved[i]}");
                    Console.WriteLine($"guest Names: {guestNames[i]}");
                    Console.WriteLine($"nights: {nights[i]}");
                    Console.WriteLine($"Date of Enrollment: {bookingDates[i]:yyyy-MM-dd HH:mm:ss}\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
        // 3. Reserve a room for a guest (Guest Name, Room Number, Nights)________

        static void ReserveARoom()
        {
            try
            {
            
            
            
            
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        // 4. View all reservations with total cost______

        static void ViewAllReservations()
        {
            try
            {




            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        // 5. Search reservation by guest name (case-insensitive)_____
        static void SearchReservationByGuestName()
        {
            try
            {




            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        // 6. Find the highest-paying guest________
        static void HighestPayingGuest()
        {
            try
            {




            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }































    }

}
