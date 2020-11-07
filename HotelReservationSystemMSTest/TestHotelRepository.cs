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

    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class TestHotelRepository
    {
        /// <summary>
        /// UC1
        /// Adds the hotel with name and rate for regular customer.
        /// </summary>
        [TestMethod]
        public void AddHotelWithNameAndRateForRegularCustomer()
        {
            // Arrange
            HotelRepository hotelRepository = new HotelRepository();
            hotelRepository.nameToPriceMapperRegulrCustomer.Add("Lakewood", 110);
            hotelRepository.nameToPriceMapperRegulrCustomer.Add("Bridgewood", 150);
            hotelRepository.nameToPriceMapperRegulrCustomer.Add("Ridgewood", 220);
            // Act
            double actual1 = hotelRepository.nameToPriceMapperRegulrCustomer["Lakewood"];
            double expected1 = 110;
            double actual2 = hotelRepository.nameToPriceMapperRegulrCustomer["Bridgewood"];
            double expected2 = 150;
            double actual3 = hotelRepository.nameToPriceMapperRegulrCustomer["Ridgewood"];
            double expected3 = 220;
            // Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }
    }
}
