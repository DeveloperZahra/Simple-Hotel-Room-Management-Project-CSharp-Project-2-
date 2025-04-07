using System.Net.NetworkInformation;
using System.Threading.Channels;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Simple_Hotel_Room_Management_Project__CSharp_Project_2__
{
   internal class Room

   {
        static List<Room> rooms = new List<Room>();
        static Dictionary<int, bool> room = new Dictionary<int, bool>();
        // Create the array and add the required variables...
        static int[] roomNumbers = new int[3];
        static double[] roomRates = new double[3];
        static bool[] isReserved = new bool[3];
        static string[] guestNames = new string[3];
        static int[] nights = new int[3];
        static DateTime[] bookingDates = new DateTime[3];
       static decimal[] DailyRate = new decimal[3] ;
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

                        Console.Clear();
                        Console.WriteLine("Enter Room  details:  \n");

                        // add room number...
                        Console.Write("Enter room number: \n");
                        int roomNumber = int.Parse(Console.ReadLine());

                        // Validate room number uniqueness
                        if (!IsRoomNumberUnique(roomNumber))
                        {
                            Console.WriteLine("Error: Room number must be unique.");
                            return;
                        }

                        Console.Write("Enter daily rate: ");
                        decimal dailyRate = decimal.Parse(Console.ReadLine());

                        // Validate rate
                        if (dailyRate < 100)
                        {
                            Console.WriteLine("Error: Rate must be >= 100.");
                            return;
                        }

                        // Add the new room to the list
                        //rooms.Add(new Room(roomNumber, dailyRate));
                        Console.WriteLine("Room added successfully.");


                        static bool IsRoomNumberUnique(int roomNumber)
                    { 
                       

                        foreach (var room in rooms)
                            {
                                if (room.RoomNumber == roomNumber)
                                {
                                    return false; // Room number is not unique
                                }
                            }
                            return true; // Room number is unique
                        }
                        Console.WriteLine("Do you want to search for anther Room? y / n");
                        choice = Console.ReadKey().KeyChar;

                    } while (choice == 'y' || choice == 'Y') ;

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
                    Console.WriteLine("No Room available.");
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
                    
                    Console.WriteLine($"TotalCost =>: nights * roomRates ");// calculate total cost dynmaicaliy...
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
                // Step 1: Get guest input
                Console.WriteLine("Enter your name:");
                string guestName = Console.ReadLine();

                Console.WriteLine("Enter room number (e.g., 101, 102, 103, 104):");
                int roomNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter number of nights:");
                int numberOfNights = int.Parse(Console.ReadLine());

                // Step 2: Validate inputs
                if (IsRoomValid(roomNumber) && !IsRoomReserved(roomNumber) && numberOfNights > 0)
                {
                    ReserveRoom(guestName, roomNumber, numberOfNights);
                }
                else
                {
                    Console.WriteLine("Reservation failed. Please check your inputs.");
                }


                // Check if the room exists in the system
                static bool IsRoomValid(int roomNumber)
                {
                    if (!rooms.ContainsKey(roomNumber))
                    {
                        Console.WriteLine("Room number does not exist.");
                        return false;
                    }
                    return true;
                }

                // Check if the room is already reserved
                static bool IsRoomReserved(int roomNumber)
                {
                    if (room[roomNumber])
                    {
                        Console.WriteLine("Room is already reserved.");
                        return true;
                    }
                    return false;
                }

                // Reserve the room and update the system
                static void ReserveRoom(string guestName, int roomNumber, int nights)
                {
                    
                    Console.WriteLine($"Reservation successful! Guest: {guestName}, Room: {roomNumber}, Nights: {nights}");
                }
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

        // 7. Cancel a reservation by room number______
        static void CancelReservationByRoomNumber()
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
