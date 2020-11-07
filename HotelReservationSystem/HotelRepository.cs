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
    using System.Linq;
    using System.Text;

    public class HotelRepository
    {
        /// <summary>
        /// Each key represents hotel name and value stores a container referencing prices for each dayType
        /// The name to price mapper regulr customer
        /// </summary>
        public Dictionary<string, Dictionary<DayType, double>> nameToPriceMapperRegulrCustomer;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelRepository"/> class.
        /// </summary>
        public HotelRepository()
        {
            this.nameToPriceMapperRegulrCustomer = new Dictionary<string, Dictionary<DayType, double>>();
        }

        /// <summary>
        /// Gets the cheapest hotels.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        public List<Tuple<string, double>> GetCheapestHotels(string startDate, string endDate)
        {
            DateTime startDateTime = Convert.ToDateTime(DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture));
            DateTime endDateTime = Convert.ToDateTime(DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture));
            if (startDateTime > endDateTime)
            {
                return new List<Tuple<string, double>>();
            }
            int weekEnds = GetNumberOfWeekEndsBetweenTwoDates(startDateTime, endDateTime);
            int weekDays = (endDateTime - startDateTime).Days - weekEnds + 1;
            Dictionary<string, double> priceList = new Dictionary<string, double>();
            foreach (KeyValuePair<string, Dictionary<DayType, double>> pair in this.nameToPriceMapperRegulrCustomer)
            {
                double priceForWeekDays = pair.Value[DayType.Weekday] * weekDays;
                double priceForWeekEnds = pair.Value[DayType.Weekend] * weekEnds;
                double totalPrice = priceForWeekDays + priceForWeekEnds;
                priceList.Add(pair.Key, totalPrice);
            }
            double minPrice = priceList.Values.Min();
            List<Tuple<string, double>> listOfNameAndPrice = new List<Tuple<string, double>>();
            foreach(KeyValuePair<string,double> pair in priceList)
            {
                if (pair.Value == minPrice)
                {
                    listOfNameAndPrice.Add(new Tuple<string, double>(pair.Key, minPrice));
                }
            }
            return listOfNameAndPrice;
        }

        /// <summary>
        /// Return Numbers of week ends between two dates.
        /// </summary>
        /// <param name="startDateTime">The start date time.</param>
        /// <param name="endDateTime">The end date time.</param>
        /// <returns></returns>
        public int GetNumberOfWeekEndsBetweenTwoDates(DateTime startDateTime, DateTime endDateTime)
        {
            int numberOfWeekEnds = 0;
            if (startDateTime > endDateTime)
            {
                return numberOfWeekEnds;
            }
            for(DateTime date = startDateTime; date <= endDateTime; date = date.AddDays(1))
            {
                if(date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    numberOfWeekEnds++;
                }
            }
            return numberOfWeekEnds;
        }
    }

    public enum DayType
    {
        Weekday,
        Weekend
    }
}
