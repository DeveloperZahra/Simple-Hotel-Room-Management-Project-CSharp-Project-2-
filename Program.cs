using System.ComponentModel.Design;
using System.Net.NetworkInformation;
using System.Threading.Channels;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Simple_Hotel_Room_Management_Project__CSharp_Project_2__
{
   internal class Room

   {
        
        // Create the array and add the required variables...
        const int MAX_ROOMS = 100;
        static int roomCount = 0;
        static int[] roomNumbers = new int[MAX_ROOMS];
        static double[] roomRates = new double[MAX_ROOMS];
        static bool[] isReserved = new bool[MAX_ROOMS];
        static string[] guestNames = new string[MAX_ROOMS];
        static int[] nights = new int[MAX_ROOMS];
        static DateTime[] bookingDates = new DateTime[MAX_ROOMS];
        static double[] totalCosts = new double[MAX_ROOMS];

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

                    if (roomCount >= MAX_ROOMS)
                    {
                        Console.Clear();
                        Console.WriteLine("Maximum capacity reached!");
                        return;

                        // add room number...
                        Console.Write("Enter room number: \n");
                        if (!int.TryParse(Console.ReadLine(), out int roomNumber))

                        {
                            Console.WriteLine("Error: Room number must be unique.");
                            return;
                        }
                        // Check if the room number is unique
                        bool exists = false;
                        for (int i = 0; i < roomCount; i++)
                        {
                            if (roomNumbers[i] == roomNumber)
                            {
                                exists = true;
                                break;
                            }
                        }

                        if (exists)
                        {
                            Console.WriteLine("Room number already exists.");
                            return;
                        }

                        Console.Write("Enter daily rate: ");
                        if (!double.TryParse(Console.ReadLine(), out double dailyRate))
                        {
                            Console.WriteLine("Invalid daily rate.");
                            return;
                        }

                        // Validate rate
                        while (dailyRate < 100)
                        {
                            Console.WriteLine("Error: Rate must be >= 100.");
                            return;
                        }
                        // Storing details 
                        roomNumbers[roomCount] = roomNumber;
                        roomRates[roomCount] = dailyRate;
                        isReserved[roomCount] = false;
                        guestNames[roomCount] = string.Empty;
                        roomCount++;
                        Console.WriteLine($"Room {roomNumber} added with a daily rate of {dailyRate:C}.");

                        Console.WriteLine("Do you want to add anther Room? Yes / No ");
                        choice = Console.ReadKey().KeyChar;
                    }

                    else
                    {
                        Console.WriteLine();
                        choice = 'n';
                    }


                } while (choice == 'y' || choice == 'Y');

            }

            catch (Exception e)
            {
                Console.WriteLine($"Invalid to add another Room!" + e.Message);
            }

        }    

         //2. View all rooms (Available and Reserved) _______
            static void ViewAllRooms()

        {
            try
            {

                Console.WriteLine("\nAll Rooms:");
                for (int i = 0; i < roomCount; i++) // make a loop to looping in  through all rooms 
                {
                    if (isReserved[i])
                    {
                        double totalCost = roomRates[i] * nights[i];// Show guest name and total cost 
                        Console.WriteLine($"Room {roomNumbers[i]} - Rate: {roomRates[i]:C} - Reserved by: {guestNames[i]} - Total Cost: {totalCost:C}");
                    }
                    else
                    {
                        Console.WriteLine($"Room {roomNumbers[i]} - Rate: {roomRates[i]:C} - Available");
                    }
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

            //try
            //{
            //    // Step 1: Get guest input
            //    Console.WriteLine("Enter your name:");
            //    string guestName = Console.ReadLine();

            //    Console.WriteLine("Enter room number (e.g., 101, 102, 103, 104):");
            //    int roomNumber = int.Parse(Console.ReadLine());

            //    Console.WriteLine("Enter number of nights:");
            //    int numberOfNights = int.Parse(Console.ReadLine());

            //    // Step 2: Validate inputs
            //    if (IsRoomValid(roomNumber) && !IsRoomReserved(roomNumber) && numberOfNights > 0)
            //    {
            //        ReserveRoom(guestName, roomNumber, numberOfNights);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Reservation failed. Please check your inputs.");
            //    }


            //    // Check if the room exists in the system
            //    static bool IsRoomValid(int roomNumber)
            //    {
            //        if (!rooms.ContainsKey(roomNumber))
            //        {
            //            Console.WriteLine("Room number does not exist.");
            //            return false;
            //        }
            //        return true;
            //    }

            //    // Check if the room is already reserved
            //    static bool IsRoomReserved(int roomNumber)
            //    {
            //        if (room[roomNumber])
            //        {
            //            Console.WriteLine("Room is already reserved.");
            //            return true;
            //        }
            //        return false;
            //    }

            //    // Reserve the room and update the system
            //    static void ReserveRoom(string guestName, int roomNumber, int nights)
            //    {
                    
            //        Console.WriteLine($"Reservation successful! Guest: {guestName}, Room: {roomNumber}, Nights: {nights}");
            //    }
            //}  

            //catch (Exception ex)
            //{
            //    Console.WriteLine($"An error occurred: {ex.Message}");
            //}

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
