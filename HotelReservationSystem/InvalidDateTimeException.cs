// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvalidDateTimeException.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Akshay Poriya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace HotelReservationSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class InvalidDateTimeException:Exception
    {
        public InvalidDateTimeException(string message) : base(message)
        {
            
        }
    }
}
