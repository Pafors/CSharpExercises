using Exercise_5_Garage.Vehicles;
using Exercise_5_Garage.VehicleStorageFacilities;
namespace Övning_5___Garage_test

{
    public class Garage
    {
        [Fact]
        public void NewGarage_gotExpectedSize()
        {
            // Arrange
            var garageSize = 12;
            var expectedGarageSize = garageSize;

            // Act
            var garage = new Garage<IVehicle>(expectedGarageSize);
            var actualGarageSize = garage.GetSize();

            // Assert
            Assert.Equal(expectedGarageSize, actualGarageSize);
        }

        [Fact]
        public void ParkingVehicle_worksInAnEmptyGarage()
        {
            var garageSize = 12;
            var newCar = new Car("Honda CRV", "Silver", 4, "Petrol", "QWE123", convertible: false);

            // Act
            var garage = new Garage<IVehicle>(garageSize);
            (bool actualParkingResult, string actualReason) = garage.ParkVehicle(newCar);

            // Assert
            Assert.True(actualParkingResult, "Parking must work in an empty garage");
        }

        [Fact]
        public void ParkVehicle_decreasesAvailableParkingSlots()
        {
            // Arrange
            var garageSize = 12;
            var newCar = new Car("Honda CRV", "Silver", 4, "Petrol", "QWE123", convertible: false);
            var expectedNumberOfParklingSlots = garageSize - 1;

            // Act
            var garage = new Garage<IVehicle>(garageSize);
            (bool _, string _) = garage.ParkVehicle(newCar);
            var actualNumberOfParklingSlots = garage.GetNumberOfAvailableParkingSpots();

            // Assert
            Assert.Equal(expectedNumberOfParklingSlots, actualNumberOfParklingSlots);
        }

        [Fact]
        public void ParkVehicle_increasesNumberOfParkedVehicles()
        {
            // Arrange
            var garageSize = 12;
            var newCar = new Car("Honda CRV", "Silver", 4, "Petrol", "QWE123", convertible: false);
            var expectedNumberOfParkedVehicles = 1;

            // Act
            var garage = new Garage<IVehicle>(garageSize);
            (bool _, string _) = garage.ParkVehicle(newCar);
            var actualNumberOfParkedVehicle = garage.NumberOfParkedVehicles();

            // Assert
            Assert.Equal(expectedNumberOfParkedVehicles, actualNumberOfParkedVehicle);
        }

        [Fact]
        public void ParkVehicle_failsToPark_duplicate_regNumber()
        {
            // Arrange
            var garageSize = 12;
            var newCar = new Car("Honda CRV", "Silver", 4, "Petrol", "QWE123", convertible: false);

            // Act
            var garage = new Garage<IVehicle>(garageSize);
            (bool _, string _) = garage.ParkVehicle(newCar);
            (bool actualResult, string actualReason) = garage.ParkVehicle(newCar);

            // Assert
            Assert.False(actualResult, "Parking vehicle with same registration number should not work");
        }

        [Fact]
        public void ParkVehicle_failsToPark_full_garage()
        {
            // Arrange
            var garageSize = 1;
            var newCar = new Car("Honda CRV", "Silver", 4, "Petrol", "QWE123", convertible: false);
            var otherCar = new Car("Land Rover", "Green", 4, "Diesel", "WLD700", convertible: true);
            var expectedReason = "GARAGET FULLT";
            // Act
            var garage = new Garage<IVehicle>(garageSize);
            (bool _, string _) = garage.ParkVehicle(newCar);
            (bool actualResult, string actualReason) = garage.ParkVehicle(otherCar);

            // Assert
            Assert.False(actualResult, "Parking vehicle with same registration number should not work");
            Assert.Equal(actualReason, expectedReason);
        }

        [Fact]
        public void UnParkVehicle_removesVehicle()
        {
            var garageSize = 12;
            var newCar = new Car("Honda CRV", "Silver", 4, "Petrol", "QWE123", convertible: false);

            // Act
            var garage = new Garage<IVehicle>(garageSize);
            (bool _, string _) = garage.ParkVehicle(newCar);
            bool actualUnParkingResult = garage.UnParkVehicle("QWE123");

            // Assert
            Assert.True(actualUnParkingResult, "Unparking must work for a parked vehicle");
        }

        [Fact]
        public void UnParkVehicle_failsForUnavailableVehicle()
        {
            var garageSize = 12;
            var newCar = new Car("Honda CRV", "Silver", 4, "Petrol", "QWE123", convertible: false);

            // Act
            var garage = new Garage<IVehicle>(garageSize);
            bool actualUnParkingResult = garage.UnParkVehicle("ZZZZZZ");

            // Assert
            Assert.False(actualUnParkingResult, "Unparking must not work for unavailable vehicles");
        }


        [Fact]
        public void UnParkVehicle_increasesAvailableParkingSlots()
        {
            // Arrange
            var garageSize = 12;
            var newCar = new Car("Honda CRV", "Silver", 4, "Petrol", "QWE123", convertible: false);
            var expectedNumberOfParklingSlots = garageSize;

            // Act
            var garage = new Garage<IVehicle>(garageSize);
            (bool _, string _) = garage.ParkVehicle(newCar);
            bool _ = garage.UnParkVehicle("QWE123");
            var actualNumberOfParklingSlots = garage.GetNumberOfAvailableParkingSpots();

            // Assert
            Assert.Equal(expectedNumberOfParklingSlots, actualNumberOfParklingSlots);
        }

        [Fact]
        public void UnParkVehicle_decreasesNumberOfParkedVehicles()
        {
            // Arrange
            var garageSize = 12;
            var newCar = new Car("Honda CRV", "Silver", 4, "Petrol", "QWE123", convertible: false);
            var expectedNumberOfParkedVehicles = 0;

            // Act
            var garage = new Garage<IVehicle>(garageSize);
            (bool _, string _) = garage.ParkVehicle(newCar);
            bool _ = garage.UnParkVehicle("QWE123");
            var actualNumberOfParkedVehicle = garage.NumberOfParkedVehicles();

            // Assert
            Assert.Equal(expectedNumberOfParkedVehicles, actualNumberOfParkedVehicle);
        }


        [Fact]
        public void ListVehicles_givesListOfVehicles()
        {
            // Arrange
            var garageSize = 12;
            var firstVehicle = new Car("Honda CRV", "Silver", 4, "Petrol", "QWE123", convertible: false);
            var secondVehicle = new Car("Volvo 240", "Blue", 4, "Diesel", "JAC495", convertible: false);
            var thirdVehicle = new Boat("Vindö 32", "White", 0, "Diesel", "WNDPWR42x", 9, 1.3);
            var expectedNumberOfVehicles = 3;

            // Act
            var garage = new Garage<IVehicle>(garageSize);
            (bool _, string _) = garage.ParkVehicle(firstVehicle);
            (bool _, string _) = garage.ParkVehicle(secondVehicle);
            (bool _, string _) = garage.ParkVehicle(thirdVehicle);
            var actualNumberOfVehicles = garage.Count();

            // Assert
            Assert.Equal(expectedNumberOfVehicles, actualNumberOfVehicles);
        }

        [Fact]
        public void GetAllRegistrationNumbers_matchesInput()
        {
            // Arrange
            var garageSize = 12;
            var firstVehicle = new Car("Honda CRV", "Silver", 4, "Petrol", "QWE123", convertible: false);
            var secondVehicle = new Car("Volvo 240", "Blue", 4, "Diesel", "JAC495", convertible: false);
            var thirdVehicle = new Boat("Vindö 32", "White", 0, "Diesel", "WNDPWR42x", 9, 1.3);
            var expectedListOfRegistrationNumbers = new List<string>()
            {
                "QWE123", "JAC495", "WNDPWR42x"
            };

            // Act
            var garage = new Garage<IVehicle>(garageSize);
            (bool _, string _) = garage.ParkVehicle(firstVehicle);
            (bool _, string _) = garage.ParkVehicle(secondVehicle);
            (bool _, string _) = garage.ParkVehicle(thirdVehicle);
            var actualListOfRegistrationNumbers = garage.GetAllRegistrationNumbers();

            // Assert
            Assert.Equal(expectedListOfRegistrationNumbers, actualListOfRegistrationNumbers);
        }

        [Fact]
        public void FindAny_findsParkedVehicles()
        {
            // Arrange
            var garageSize = 12;
            var firstVehicle = new Car("Honda CRV", "Silver", 4, "Petrol", "QWE123", convertible: false);
            var secondVehicle = new Car("Volvo 240", "Blue", 4, "Diesel", "JAC495", convertible: false);
            var thirdVehicle = new Boat("Vindö 32", "White", 0, "Diesel", "WNDPWR42x", 9, 1.3);
            var expectedNumberOfDieselMatches = 2;
            var expectedNumberOfBoats = 1;

            // Act
            var garage = new Garage<IVehicle>(garageSize);
            (bool _, string _) = garage.ParkVehicle(firstVehicle);
            (bool _, string _) = garage.ParkVehicle(secondVehicle);
            (bool _, string _) = garage.ParkVehicle(thirdVehicle);
            var actualNumberOfDieselMatches = garage.FindAny("diesel").Count();
            var actualNumberOfBoats = garage.FindAny("boat").Count();

            // Assert
            Assert.Equal(expectedNumberOfDieselMatches, actualNumberOfDieselMatches);
            Assert.Equal(expectedNumberOfBoats, actualNumberOfBoats);
        }

        [Fact]
        public void FindByProp_findsParkedVehicles()
        {
            // Arrange
            var garageSize = 12;
            var firstVehicle = new Car("Honda CRV", "Silver", 4, "Petrol", "QWE123", convertible: false);
            var secondVehicle = new Car("Volvo 240", "Blue", 4, "Diesel", "JAC495", convertible: false);
            var thirdVehicle = new Boat("Vindö 32", "White", 0, "Diesel", "WNDPWR42x", 9, 1.3);
            var expectedNumberOfDieselMatches = 2;
            var expectedNumberOfBoats = 1;

            // Act
            var garage = new Garage<IVehicle>(garageSize);
            (bool _, string _) = garage.ParkVehicle(firstVehicle);
            (bool _, string _) = garage.ParkVehicle(secondVehicle);
            (bool _, string _) = garage.ParkVehicle(thirdVehicle);
            var actualNumberOfDieselMatches = garage.FindByProp("ps", "diesel").Count();
            var actualNumberOfBoats = garage.FindByProp("type", "boat").Count();

            // Assert
            Assert.Equal(expectedNumberOfDieselMatches, actualNumberOfDieselMatches);
            Assert.Equal(expectedNumberOfBoats, actualNumberOfBoats);
        }

    }
}