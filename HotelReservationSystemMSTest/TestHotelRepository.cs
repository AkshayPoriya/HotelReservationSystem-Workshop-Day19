// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HotelRepository.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akshay Poriya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace HotelReservationSystemMSTest
{
    using HotelReservationSystem;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class TestHotelRepository
    {
        /// <summary>
        /// Adds the hotel with name and rate for regular customer.
        /// </summary>
        [TestMethod]
        public void AddHotelWithNameAndRateForRegularCustomer()
        {
            // Arrange
            HotelRepository hotelRepository = PopulateHotelRepository();
            // Act
            double actual1 = hotelRepository.nameToPriceMapperRegulrCustomer["Lakewood"][DayType.Weekday];
            double expected1 = 110;
            double actual2 = hotelRepository.nameToPriceMapperRegulrCustomer["Bridgewood"][DayType.Weekend];
            double expected2 = 50;
            double actual3 = hotelRepository.nameToPriceMapperRegulrCustomer["Ridgewood"][DayType.Weekend];
            double expected3 = 150;
            // Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }

        /// <summary>
        /// Adds the rating to hotels.
        /// UC5
        /// </summary>
        [TestMethod]
        public void AddRatingToHotels()
        {
            // Arrange
            HotelRepository hotelRepository = PopulateHotelRepository();
            // Act
            int actual1 = hotelRepository.nameToRatingMapper["Lakewood"];
            int expected1 = 3;
            int actual2 = hotelRepository.nameToRatingMapper["Bridgewood"];
            int expected2 = 4;
            int actual3 = hotelRepository.nameToRatingMapper["Ridgewood"];
            int expected3 = 5;
            // Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }

        /// <summary>
        /// UC6
        /// Returns the cheapest hotel for given date range.
        /// Assert Compare two list objects reference wise, thats why list is converted to string first
        /// </summary>
        [TestMethod]
        public void ReturnCheapestHotelWithBestRatingForGivenDateRange()
        {
            // Arrange
            HotelRepository hotelRepository = PopulateHotelRepository();
            // Act
            string startDate = "11/09/2020";
            string endDate = "12/09/2020";
            List<Tuple<string, int, double>> actualListOfNameAndPrice = hotelRepository.GetCheapestBestRatedHotels(startDate, endDate);
            List<Tuple<string, int, double>> expectedListOfNameAndPrice = new List<Tuple<string, int, double>>();
            expectedListOfNameAndPrice.Add(new Tuple<string, int, double>("Bridgewood", 4, 200));
            string actual = ListOfTupleToString(actualListOfNameAndPrice);
            string expected = ListOfTupleToString(expectedListOfNameAndPrice);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// UC7
        /// Returns the hotels with best rating for given date range.
        /// </summary>
        [TestMethod]
        public void ReturnHotelsWithBestRatingForGivenDateRange()
        {
            // Arrange
            HotelRepository hotelRepository = PopulateHotelRepository();
            // Act
            string startDate = "11/09/2020";
            string endDate = "12/09/2020";
            List<Tuple<string, int, double>> actualListOfNameAndPrice = hotelRepository.GetBestRatedHotels(startDate, endDate);
            List<Tuple<string, int, double>> expectedListOfNameAndPrice = new List<Tuple<string, int, double>>();
            expectedListOfNameAndPrice.Add(new Tuple<string, int, double>("Ridgewood", 5, 370));
            string actual = ListOfTupleToString(actualListOfNameAndPrice);
            string expected = ListOfTupleToString(expectedListOfNameAndPrice);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        private HotelRepository PopulateHotelRepository()
        {
            HotelRepository hotelRepository = new HotelRepository();
            hotelRepository.nameToRatingMapper.Add("Lakewood", 3);
            hotelRepository.nameToRatingMapper.Add("Bridgewood", 4);
            hotelRepository.nameToRatingMapper.Add("Ridgewood", 5);
            Dictionary<DayType, double> lakeWood = new Dictionary<DayType, double>();
            lakeWood.Add(DayType.Weekday, 110);
            lakeWood.Add(DayType.Weekend, 90);
            hotelRepository.nameToPriceMapperRegulrCustomer.Add("Lakewood", lakeWood);
            Dictionary<DayType, double> bridgeWood = new Dictionary<DayType, double>();
            bridgeWood.Add(DayType.Weekday, 150);
            bridgeWood.Add(DayType.Weekend, 50);
            hotelRepository.nameToPriceMapperRegulrCustomer.Add("Bridgewood", bridgeWood);
            Dictionary<DayType, double> ridgeWood = new Dictionary<DayType, double>();
            ridgeWood.Add(DayType.Weekday, 220);
            ridgeWood.Add(DayType.Weekend, 150);
            hotelRepository.nameToPriceMapperRegulrCustomer.Add("Ridgewood", ridgeWood);
            return hotelRepository;
        }

        private string ListOfTupleToString(List<Tuple<string, int, double>> listOfNameAndPrice)
        {
            string s = "";
            foreach(Tuple<string, int, double> tuple in listOfNameAndPrice)
            {
                s += (tuple.Item1 + " " + tuple.Item2 + tuple.Item3 +"\n");
            }
            return s;
        }
    }
}