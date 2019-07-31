// This is an independent project of an individual developer. Dear PVS-Studio, please check it.

// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseApp
{
    abstract class Vehicle
    {
        public string RegNo { get; set; }
        public DateTime ParkingTime { get; set; }
        public abstract void ParkingFee();
        public double BillAmount { get; protected set; }
    }

    class Car : Vehicle
    {
        //Cars will have 60 Rs for 2 hr parking...and +20 for every additional
        public override void ParkingFee()
        {
            TimeSpan span = DateTime.Now - ParkingTime;//get the parking Time
            int hrs = span.Hours + 1;
            if (hrs <= 2)
                BillAmount = 60;
            else if (hrs > 2)
            {
                BillAmount = 60 + ((hrs - 2) * 20);
            }
        }
    }
    //To create Bike and SUV: Bike: 20 + 5 for every hr... SUV: 100 + 30 for hr
    class SampleCodeForToolTesting3
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Car();
            vehicle.RegNo = "KA41 MG 9460";
            vehicle.ParkingTime = DateTime.Now.AddMinutes(-123);
            vehicle.ParkingFee();
            Console.WriteLine("The Current Parking Bill: " + vehicle.BillAmount);
        }
    }
}

