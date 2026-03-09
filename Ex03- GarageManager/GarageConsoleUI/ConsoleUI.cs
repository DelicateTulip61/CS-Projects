using System;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Vehicle_Categories;

namespace Ex03.ConsoleUI
{
    public static class GarageUI
    {
        private static GarageManager s_GarageManager = new GarageManager();

        public static void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Garage Management System ===");
                Console.WriteLine("1. Load vehicles from file");
                Console.WriteLine("2. Insert a new vehicle");
                Console.WriteLine("3. List all vehicles");
                Console.WriteLine("4. Change vehicle status");
                Console.WriteLine("5. Inflate all wheels to max");
                Console.WriteLine("6. Refuel vehicle");
                Console.WriteLine("7. Recharge vehicle");
                Console.WriteLine("8. Show full vehicle details");
                Console.WriteLine("9. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();

                try
                {
                    switch (input)
                    {
                        case "1":
                            LoadVehiclesFromFileUI();
                            break;
                        case "2":
                            InsertNewVehicleUI();
                            break;
                        case "3":
                            ListVehiclesUI();
                            break;
                        case "4":
                            ChangeVehicleStatusUI();
                            break;
                        case "5":
                            InflateWheelsUI();
                            break;
                        case "6":
                            RefuelVehicleUI();
                            break;
                        case "7":
                            RechargeVehicleUI();
                            break;
                        case "8":
                            ShowVehicleDetailsUI();
                            break;
                        case "9":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option, try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }

                if (!exit)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void LoadVehiclesFromFileUI()
        {
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();
            s_GarageManager.LoadVehiclesFromFile(s_GarageManager, path);
            Console.WriteLine("Vehicles loaded successfully!");
        }

        private static void InsertNewVehicleUI()
        {
            s_GarageManager.InsertNewVehicle(s_GarageManager);
        }

        private static void ListVehiclesUI()
        {
            Console.Write("Filter by status? (0-no / 1-yes): ");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter status (0-InRepair, 1-Fixed, 2-Paid): ");
                eVehicleStatus status = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), Console.ReadLine());
                var filtered = s_GarageManager.GetAllVehicles(status);
                Console.WriteLine("\nVehicles with status " + status + ":");
                foreach (string license in filtered)
                {
                    Console.WriteLine(license);
                }
            }
            else
            {
                var all = s_GarageManager.GetAllVehicles();
                Console.WriteLine("\nAll vehicles:");
                foreach (string license in all)
                {
                    Console.WriteLine(license);
                }
            }
        }

        private static void ChangeVehicleStatusUI()
        {
            Console.Write("Enter license plate: ");
            string license = Console.ReadLine();

            Console.Write("Enter new status (0-InRepair, 1-Fixed, 2-Paid): ");
            eVehicleStatus newStatus = (eVehicleStatus)Enum.Parse(typeof(eVehicleStatus), Console.ReadLine());

            s_GarageManager.ChangeStatus(license, newStatus);
            Console.WriteLine("Vehicle status updated successfully!");
        }

        private static void InflateWheelsUI()
        {
            Console.Write("Enter license plate: ");
            string license = Console.ReadLine();

            s_GarageManager.InflateAllWheels(license);
            Console.WriteLine("All wheels inflated to max!");
        }

        private static void RefuelVehicleUI()
        {
            Console.Write("Enter license plate: ");
            string license = Console.ReadLine();

            Console.WriteLine("Enter fuel type (0-Soler, 1-Octan95, 2-Octan96, 3-Octan98): ");
            eFuelType fuelType = (eFuelType)Enum.Parse(typeof(eFuelType), Console.ReadLine());

            Console.Write("Enter amount to refuel: ");
            Console.WriteLine($"Current fuel status: {s_GarageManager.GetFuelStatus(license)}");
            float amount = float.Parse(Console.ReadLine());

            s_GarageManager.Refuel(license, fuelType, amount);
            Console.WriteLine("Vehicle refueled successfully!");
        }

        private static void RechargeVehicleUI()
        {
            Console.Write("Enter license plate: ");
            string license = Console.ReadLine();

            Console.Write("Enter minutes to recharge: ");
            float minutes = float.Parse(Console.ReadLine());

            s_GarageManager.Recharge(license, minutes);
            Console.WriteLine("Vehicle recharged successfully!");
        }

        private static void ShowVehicleDetailsUI()
        {
            Console.Write("Enter license plate: ");
            string license = Console.ReadLine();

            s_GarageManager.GetVehicleDetails(license);
        }
    }
}