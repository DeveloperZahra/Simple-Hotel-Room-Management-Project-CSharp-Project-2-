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

            Console.Clear();
            try
            {
                // Check if the array is full
                if (roomCount == MAX_ROOMS)
                {
                    Console.WriteLine("Array is Full! You can't add more Rooms.");
                }
                else
                {
                    // Ask user to enter room information
                    Console.WriteLine("\n Enter Room Information:");
                    Console.Write("Enter Room Number: ");
                    int RoomNum = int.Parse(Console.ReadLine());

                    // Check if room number already exists
                    for (int j = 0; j < roomCount; j++)
                    {
                        while (roomNumbers[j] == RoomNum)
                        {
                            Console.WriteLine("Room Number Already Taken! Try another. \n");
                            RoomNum = int.Parse(Console.ReadLine());
                        }
                    }
                    roomNumbers[roomCount] = RoomNum;

                    // Ask user to enter daily rate
                    Console.Write("Enter Room Daily Rate: ");
                    double DailyRate = double.Parse(Console.ReadLine());

                    // Validate daily rate
                    while (DailyRate < 100)
                    {
                        Console.Write("Invalid Rate! Rate should be 100 or more \n Enter Rate again: \n");
                        DailyRate = double.Parse(Console.ReadLine());
                    }
                    roomRates[roomCount] = DailyRate;

                    // Mark room as available
                    isReserved[roomCount] = false;

                    // Display added room details
                    Console.WriteLine($"Room Number: {roomNumbers[roomCount]} , Daily Rate: {roomRates[roomCount]} , Reserved: {isReserved[roomCount]}");
                    roomCount++;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter numbers where required.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("(Press Enter To Go Back To MENU !)");
            Console.ReadLine();
        }

         //2. View all rooms (Available and Reserved) _______
            static void ViewAllRooms()

        {
            try
            {
                // Display all rooms
                Console.WriteLine("\nAll Rooms:");
                for (int i = 0; i < roomCount; i++) // make a loop to looping in  through all rooms 
                {
                    if (isReserved[i])
                    {  // Display reserved room details
                        double totalCost = roomRates[i] * nights[i];// Show guest name and total cost 
                        Console.WriteLine($"Room {roomNumbers[i]} - Rate: {roomRates[i]:C} - Reserved by: {guestNames[i]} - Total Cost: {totalCost:C}");
                    }
                    else
                    {     // Display available room details
                        Console.WriteLine($"Room {roomNumbers[i]} - Rate: {roomRates[i]:C} - Available");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.WriteLine("(Press Enter To Go Back To MENU )");
            Console.ReadLine();
        }
        // 3. Reserve a room for a guest (Guest Name, Room Number, Nights)________

        static void ReserveARoom()
        {

            Console.Clear();
            try
            {
                // Check if there are any rooms available
                if (roomCount == 0)
                {
                    Console.WriteLine("No Rooms Available! Please add a room first.");
                    return;
                }

                // Ask user to enter reservation details
                Console.WriteLine("\n Enter Reservation Information ");
                Console.Write("Enter Guest Name: ");
                string guestName = Console.ReadLine().ToLower();
                Console.Write("Enter Room Number: ");
                int roomNum = int.Parse(Console.ReadLine());
                Console.Write("Enter Number of Nights: ");
                int NumNights = int.Parse(Console.ReadLine());

                // Validate number of nights
                while (NumNights < 1)
                {
                    Console.Write("Invalid Number of Nights! Please enter a valid number: ");
                    NumNights = int.Parse(Console.ReadLine());
                }

                DateTime bookingDate = DateTime.Now;

                // Check if the room exists and reserve it
                bool roomExists = false;
                for (int i = 0; i < roomCount; i++)
                {
                    if (roomNumbers[i] == roomNum)
                    {
                        roomExists = true;
                        if (isReserved[i])
                        {
                            Console.WriteLine("Room is already reserved! Please choose another room.");
                            return;
                        }
                        else
                        {
                            isReserved[i] = true;
                            guestNames[i] = guestName;
                            nights[i] = NumNights;
                            bookingDates[i] = bookingDate;
                            Console.WriteLine($"Room {roomNum} has been reserved for {guestName} for {NumNights} nights.");
                        }
                    }
                }

                if (!roomExists)
                {
                    Console.WriteLine("Room number does not exist! Please check the room number.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter numbers where required.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reserving the room: {ex.Message}");
            }

            Console.WriteLine("(Press Enter To Go Back To MENU )");
            Console.ReadLine();
        }

        // 4. View all reservations with total cost______

        static void ViewAllReservations()
        {
           
                try
            {     
                    Console.WriteLine("\nReservations:");
                // Display all reservations
                for (int i = 0; i < roomCount; i++)
                    {
                        if (isReserved[i])
                        {
                            double totalCost = roomRates[i] * nights[i];
                            Console.WriteLine($"Room {roomNumbers[i]} - Guest: {guestNames[i]} - Nights: {nights[i]} - Rate: {roomRates[i]:C} - Total Cost: {totalCost:C} - Booking Date: {bookingDates[i]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while viewing reservations: {ex.Message}");
                }

            Console.WriteLine("(Press Enter To Go Back To MENU )");
            Console.ReadLine();

        }

        // 5. Search reservation by guest name (case-insensitive)_____
        static void SearchReservationByGuestName()
        {
            Console.Clear();
            try
            {
                // Check if there are any rooms available
                if (roomCount == 0)
                {
                    Console.WriteLine("No Rooms Available! Please add a room first.");
                    return;
                }

                // Ask user to enter guest name
                Console.WriteLine("Enter Guest Name to Search: ");
                string searchName = Console.ReadLine().ToLower();
                bool found = false;

                // Search for reservations by guest name
                for (int i = 0; i < roomCount; i++)
                {
                    if (guestNames[i]?.ToLower() == searchName)
                    {
                        found = true;
                        double total = (nights[i] * roomRates[i]);
                        Console.WriteLine($"Guest Name: {guestNames[i]} , Room Number: {roomNumbers[i]} , Daily Rate: {roomRates[i]} , Total Cost: {total}   \n");
                    }
                }

                if (!found)
                {
                    Console.WriteLine("No reservation found for the given guest name.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while searching for reservations: {ex.Message}");
            }
            Console.WriteLine("(Press Enter To Go Back To MENU )");
                Console.ReadLine();
           

        }

        // 6. Find the highest-paying guest________
        static void HighestPayingGuest()
        {
            Console.Clear();
            try
            {
                // Check if there are any rooms available
                if (roomCount == 0)
                {
                    Console.WriteLine("No Rooms Available! Please add a room first.");
                    return;
                }

                // Find the highest-paying guest
                double maxCost = 0;
                string highestGuest = "";

                for (int i = 0; i < roomCount; i++)
                {
                    if (isReserved[i])
                    {
                        double total = (nights[i] * roomRates[i]);
                        if (total > maxCost)
                        {
                            maxCost = total;
                            highestGuest = guestNames[i];
                        }
                    }
                }

                if (string.IsNullOrEmpty(highestGuest))
                {
                    Console.WriteLine("No reservations found.");
                }
                else
                {
                    Console.WriteLine($"Highest Paying Guest: {highestGuest} with a total cost of {maxCost}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while finding the highest paying guest: {ex.Message}");
            }
            Console.WriteLine("(Press Enter To Go Back To MENU )");
            Console.ReadLine();
        }

        // 7. Cancel a reservation by room number______
        static void CancelReservationByRoomNumber()
        {
            Console.Clear();
            try
            {
                // Check if there are any rooms available
                if (roomCount == 0)
                {
                    Console.WriteLine("No Rooms Available! Please add a room first.");
                    return;
                }

                // Ask user to enter room number to cancel
                Console.Write("Enter Room Number to Cancel Reservation: ");
                int roomNum = int.Parse(Console.ReadLine());
                bool roomFound = false;

                // Cancel the reservation
                for (int i = 0; i < roomCount; i++)
                {
                    if (roomNumbers[i] == roomNum)
                    {
                        roomFound = true;
                        if (isReserved[i])
                        {
                            isReserved[i] = false;
                            guestNames[i] = null;
                            nights[i] = 0;
                            bookingDates[i] = DateTime.MinValue;
                            Console.WriteLine($"Reservation for Room {roomNum} has been canceled.");
                        }
                        else
                        {
                            Console.WriteLine("Room is not reserved! No reservation to cancel.");
                        }
                    }
                }

                if (!roomFound)
                {
                    Console.WriteLine("Room number not found! Please check the room number.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid room number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while canceling the reservation: {ex.Message}");
            }

            Console.WriteLine("(Press Enter To Go Back To MENU )");
            Console.ReadLine();
        }
   }

}
