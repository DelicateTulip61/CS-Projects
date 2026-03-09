using Ex03.GarageLogic;
using Ex03.GarageLogic.Exceptions;
using Ex03.GarageLogic.Vehicle_Categories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;


namespace Ex03.GarageLogic
{
	public class GarageManager
	{
		private readonly Dictionary<string, VehicleInGarage> r_VehiclesAndLicenses = new Dictionary<string, VehicleInGarage>();

		public bool Contains(string i_LicenseNumber)
		{
			return r_VehiclesAndLicenses.ContainsKey(i_LicenseNumber);
		}

        public void LoadVehiclesFromFile(GarageManager i_GarageManager, string i_FilePath) 
        {
            string[] lines = File.ReadAllLines(i_FilePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                try
                {
                    string[] parts = line.Split(',');

                    string type = parts[0];
                    string license = parts[1];
                    string model = parts[2];
                    float energyAmount = float.Parse(parts[3]);
                    string wheelManufacturer = parts[4];
                    float wheelAir = float.Parse(parts[5]);
                    string ownerName = parts[6];
                    string ownerPhone = parts[7];

                    Vehicle vehicle = VehicleCreator.CreateVehicle(type, license, model);

                    
                    vehicle.SetWheelsDetails(wheelManufacturer, wheelAir);

                    
                    if (vehicle is Motorcycle moto)
                    {
                        moto.LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), parts[8]);
                        moto.EngineVolume = int.Parse(parts[9]);
                    }
                    else if (vehicle is Car car)
                    {
                        car.Color = (eCarColor)Enum.Parse(typeof(eCarColor), parts[8]);
                        car.NumberOfDoors = (eNumberOfDoors)int.Parse(parts[9]);
                    }
                    else if (vehicle is Truck truck)
                    {
                        truck.IsDangerous = bool.Parse(parts[8]);
                        truck.CargoVolume = float.Parse(parts[9]);
                    }

                    i_GarageManager.InsertOrRepair(vehicle, ownerName, ownerPhone);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load vehicle from line: {line}");
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void InsertNewVehicle(GarageManager i_GarageManager) 
        {
            Console.Write("Enter license number: ");
            string license = Console.ReadLine();

            if (i_GarageManager.Contains(license))
            {
                Console.WriteLine("Vehicle already exists! Changing status to InRepair.");
                i_GarageManager.ChangeStatus(license, eVehicleStatus.InRepair);
            }

            else
            { 
                Console.WriteLine("Choose vehicle type:");
                for (int i = 0; i < VehicleCreator.SupportedTypes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {VehicleCreator.SupportedTypes[i]}");
                }
                int typeIndex = int.Parse(Console.ReadLine()) - 1;
                if (typeIndex < 0 || typeIndex >= VehicleCreator.SupportedTypes.Count)
                {
                    throw new ValueRangeException(VehicleCreator.SupportedTypes.Count - 1, 0, "Invalid vehicle type selected.");
                }
                string type = VehicleCreator.SupportedTypes[typeIndex];

                Console.Write("Enter model name: ");
                string model = Console.ReadLine();

                Vehicle vehicle = VehicleCreator.CreateVehicle(type, license, model);

            
                Console.Write("Enter wheel manufacturer: ");
                string manufacturer = Console.ReadLine();
                Console.Write("Enter current air pressure for wheels: "); 
                float airPressure = float.Parse(Console.ReadLine());
                if (airPressure < 0 || airPressure > vehicle.Wheels[0].MaxAirPressure)
                {
                    throw new ValueRangeException(vehicle.Wheels[0].MaxAirPressure, 0, $"Air pressure must be between 0 and {vehicle.Wheels[0].MaxAirPressure}.");
                }
                vehicle.SetWheelsDetails(manufacturer, airPressure);

            
                if (vehicle.EnergySource is FuelTank fuelTank)
                {
                    Console.WriteLine($"Enter current fuel amount (Max: {fuelTank.MaxAmount}): "); 
                    float amount = float.Parse(Console.ReadLine());
                    if (amount < 0 || amount > fuelTank.MaxAmount)
                    {
                        throw new ValueRangeException(fuelTank.MaxAmount, 0, $"Fuel amount must be between 0 and {fuelTank.MaxAmount}.");
                    }
                    fuelTank.Fill(amount);
                }
                else if (vehicle.EnergySource is Battery battery)
                {
                    Console.WriteLine($"Enter current battery charge (Max: {battery.MaxAmount}): "); 
                    float amount = float.Parse(Console.ReadLine());
                    if (amount < 0 || amount > battery.MaxAmount)
                    {
                        throw new ValueRangeException(battery.MaxAmount, 0, $"Battery charge must be between 0 and {battery.MaxAmount}.");
                    }
                        battery.Recharge(amount);
                }

                if (vehicle is Car car)
                {
                    Console.WriteLine("Choose color: 0-Blue, 1-Green, 2-White, 3-Black");
                    car.Color = (eCarColor)int.Parse(Console.ReadLine());
                    if (car.Color < eCarColor.Blue || car.Color > eCarColor.Black)
                    {
                        throw new ValueRangeException(3, 0, "Invalid color selected.");
                    }

                    Console.WriteLine("Choose number of doors (2-5): "); 
                    eNumberOfDoors doors = (eNumberOfDoors)int.Parse(Console.ReadLine());
                    if (doors < eNumberOfDoors.Two || doors > eNumberOfDoors.Five)
                    {
                        throw new ValueRangeException(5, 2, "Number of doors must be between 2 and 5.");
                    }
                    car.NumberOfDoors = doors;
                }
                else if (vehicle is Motorcycle moto)
                {
                    Console.WriteLine("Choose license type: 0-A1, 1-A2, 2-AA, 3-B");
                    moto.LicenseType = (eLicenseType)int.Parse(Console.ReadLine());
                    if (moto.LicenseType < eLicenseType.A1 || moto.LicenseType > eLicenseType.B)
                    {
                        throw new ValueRangeException(3, 0, "Invalid license type selected.");
                    }

                    Console.Write("Enter engine volume: ");
                    moto.EngineVolume = int.Parse(Console.ReadLine());
                }
                else if (vehicle is Truck truck)
                {
                    Console.Write("Is carrying dangerous material? (true/false): ");
                    truck.IsDangerous = bool.Parse(Console.ReadLine());

                    Console.Write("Enter cargo volume: ");
                    truck.CargoVolume = float.Parse(Console.ReadLine());
                }

                Console.Write("Enter owner name: ");
                string ownerName = Console.ReadLine();

                Console.Write("Enter owner phone: ");
                string ownerPhone = Console.ReadLine();

                i_GarageManager.InsertOrRepair(vehicle, ownerName, ownerPhone);

                Console.WriteLine("Vehicle successfully added!");
            }
        }



        public void InsertOrRepair(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhone)
		{
			string license = i_Vehicle.LicenseID;
			if (r_VehiclesAndLicenses.ContainsKey(license))
			{
				r_VehiclesAndLicenses[license].VehicleStatus = eVehicleStatus.InRepair;
			}
			else
			{
				r_VehiclesAndLicenses.Add(license, new VehicleInGarage(i_Vehicle, i_OwnerName, i_OwnerPhone));
			}
		}

		public List<string> GetAllVehicles()
		{
			return r_VehiclesAndLicenses.Keys.ToList();
		}

		public List<string> GetAllVehicles(eVehicleStatus i_Status) 
		{
            if (i_Status < eVehicleStatus.InRepair || i_Status > eVehicleStatus.Paid)
            {
                throw new ValueRangeException(2, 0, "Invalid vehicle status provided.");
            }

            List<string> vehicles = new List<string>();

			foreach (var pair in r_VehiclesAndLicenses)
			{
				if(pair.Value.VehicleStatus == i_Status)
				{
					vehicles.Add(pair.Key);
				}
			}
			return vehicles;
		}

		private VehicleInGarage checkLicense(string i_LicenseNumber)
		{

			if(!r_VehiclesAndLicenses.TryGetValue(i_LicenseNumber, out VehicleInGarage license))
			{
				throw new ArgumentException("Can't find a matching vehicle to this License Number!");
			}
			return license;
		}


		public void ChangeStatus(string i_LicenseNumber, eVehicleStatus i_NewStatus) 
		{
            if (i_NewStatus < eVehicleStatus.InRepair || i_NewStatus > eVehicleStatus.Paid)
            {
                throw new ValueRangeException(2, 0, "Invalid vehicle status provided.");
            }

			VehicleInGarage license = checkLicense(i_LicenseNumber);
			license.VehicleStatus = i_NewStatus;
		}

		public void InflateAllWheels(string i_LicenseNumber)
		{
			VehicleInGarage vehiclesInGarageRecord = checkLicense(i_LicenseNumber);
			vehiclesInGarageRecord.Vehicle.InflateAllWheelsToMax();
		}

		public void Refuel(string i_LicenseNumber, eFuelType i_FuelType, float i_Amount)
		{
			VehicleInGarage license = checkLicense(i_LicenseNumber);
			if (license.Vehicle.EnergySource is FuelTank fuelTank)
			{
				fuelTank.Refuel(i_Amount, i_FuelType);
			}
			else
			{
				throw new ArgumentException("The vehicle's Energy Source is not fuel");
			}
		}

		public void Recharge(string i_LicenseNumber, float i_Minutes)
		{
			VehicleInGarage license = checkLicense(i_LicenseNumber);
			if (license.Vehicle.EnergySource is Battery battery)
			{
				battery.Recharge(i_Minutes / 60);
			}
			else
			{
				throw new ArgumentException("The vehicle's Energy Source is not battery");
			}
        }

        public VehicleInGarage GetVehicleDetails(string i_LicensePlate)
        {
            if (r_VehiclesAndLicenses.TryGetValue(i_LicensePlate, out VehicleInGarage garageVehicle))
            {
                Console.WriteLine("\n=== VEHICLE DETAILS ===");
                Console.WriteLine($"License Plate: {garageVehicle.Vehicle.LicenseID}");
                Console.WriteLine($"Model Name: {garageVehicle.Vehicle.ModelName}");
                Console.WriteLine($"Owner Name: {garageVehicle.OwnerName}");
                Console.WriteLine($"Status: {garageVehicle.VehicleStatus}");
                Console.WriteLine($"Energy Percentage: {garageVehicle.Vehicle.EnergyPercentage:F1}%");

                garageVehicle.Vehicle.GetAllDetails(); 

                return garageVehicle;
            }
            throw new KeyNotFoundException($"Vehicle with license plate {i_LicensePlate} not found");
        }

        public string GetFuelStatus(string i_LicenseNumber)
        {
            VehicleInGarage vehicleInGarage = checkLicense(i_LicenseNumber);
            Vehicle vehicle = vehicleInGarage.Vehicle;

            if (vehicle.EnergySource is FuelTank fuelTank)
            {
                return $"{fuelTank.CurrentAmount}/{fuelTank.MaxAmount}";
            }

            throw new ArgumentException("Vehicle is not fuel-based");
        }



    }
}