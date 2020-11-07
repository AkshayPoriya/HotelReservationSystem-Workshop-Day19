// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HotelRepository.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akshay Poriya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace HotelReservationSystem
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    public class HotelRepository
    {
        public Dictionary<string, double> nameToPriceMapperRegulrCustomer;

        public HotelRepository()
        {
            this.nameToPriceMapperRegulrCustomer = new Dictionary<string, double>();
        }

        /// <summary>
        /// Returns the Cheapest hotel.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        public Tuple<string, double> GetCheapestHotel(string startDate, string endDate)
        {
            DateTime startDateTime = Convert.ToDateTime(DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture));
            DateTime endDateTime = Convert.ToDateTime(DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture));
            int noOfDays = (int)(endDateTime - startDateTime).TotalDays;
            string bestHotel = "null";
            double minPrice = double.MaxValue;
            foreach(KeyValuePair<string,double> pair in nameToPriceMapperRegulrCustomer)
            {
                double price = noOfDays * pair.Value;
                if (price <= minPrice)
                {
                    bestHotel = pair.Key;
                    minPrice = price;
                }
            }
            Tuple<string, double> tuple = new Tuple<string, double>(bestHotel, minPrice);
            return tuple;
        }
    }
}
