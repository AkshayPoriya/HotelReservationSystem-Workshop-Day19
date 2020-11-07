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
        /// UC3
        /// Test  GetCheapestHotel of HotelRepository Class
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
        /// UC2
        /// Returns the cheapest hotel for given date range.
        /// Assert Compare two list objects reference wise, thats why list is converted to string first
        /// </summary>
        [TestMethod]
        public void ReturnCheapestHotelForGivenDateRange()
        {
            // Arrange
            HotelRepository hotelRepository = PopulateHotelRepository();
            // Act
            string startDate = "11/09/2020";
            string endDate = "12/09/2020";
            List<Tuple<string, double>> actualListOfNameAndPrice = hotelRepository.GetCheapestHotels(startDate, endDate);
            List<Tuple<string, double>> expectedListOfNameAndPrice = new List<Tuple<string, double>>();
            expectedListOfNameAndPrice.Add(new Tuple<string, double>("Lakewood", 200));
            expectedListOfNameAndPrice.Add(new Tuple<string, double>("Bridgewood", 200));
            string actual = ListOfTupleToString(actualListOfNameAndPrice);
            string expected = ListOfTupleToString(expectedListOfNameAndPrice);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        private HotelRepository PopulateHotelRepository()
        {
            HotelRepository hotelRepository = new HotelRepository();
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

        private string ListOfTupleToString(List<Tuple<string, double>> listOfNameAndPrice)
        {
            string s = "";
            foreach(Tuple<string, double> tuple in listOfNameAndPrice)
            {
                s += (tuple.Item1 + " " + tuple.Item2 + "\n");
            }
            return s;
        }
    }
}
