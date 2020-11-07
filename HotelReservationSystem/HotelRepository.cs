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
    using System.Text;

    public class HotelRepository
    {
        public Dictionary<string, double> nameToPriceMapperRegulrCustomer;

        public HotelRepository()
        {
            this.nameToPriceMapperRegulrCustomer = new Dictionary<string, double>();
        }
    }
}
