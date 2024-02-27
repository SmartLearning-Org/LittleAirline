using LittleAirline.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using var context = new AppDbContext();

var flightId = 1;
var aircraftId = 1;



// Object vs foreign key

//Flight flight = context.Flights.Find(flightId);
//Console.WriteLine("AircraftId: " + flight.AircraftId);

//Aircraft aircraft = context.Aircrafts.Find(aircraftId);
//flight.Aircraft = aircraft;
//Console.WriteLine("AircraftId: " + flight.Aircraft.AircraftId);



//Flight flight = context.Flights.Find(flightId);
//Console.WriteLine("AircraftId: " + flight.AircraftId);

//flight.AircraftId = aircraftId;
//Console.WriteLine("AircraftId: " + flight.AircraftId);


//var count = context.SaveChanges();
//Console.WriteLine("AircraftId: " + flight.AircraftId);

//Console.WriteLine(count);




// Bulk operationer

//var sw = new Stopwatch();
//sw.Start();

//int total = 0;
//var flights = context.Flights.Where(x => x.FlightId > 0).ToList();

//foreach (var flight in flights)
//{
//    context.Flights.Remove(flight);
//    //var count = context.SaveChanges();
//    //total += count;
//}
//total = context.SaveChanges();
//sw.Stop();
//Console.WriteLine("Number of DELETE statements: " + total);
//Console.WriteLine("Duration: " + sw.ElapsedMilliseconds);

//int total = 0;
//var sw = new Stopwatch();
//sw.Start();
//for (int i = 0; i <= 2000; i++)
//{
//    var f = new Flight() { FlightId = i };
//    context.Flights.Attach(f);
//    context.Flights.Remove(f);
//}
//total = context.SaveChanges();
//sw.Stop();
//Console.WriteLine("Number of DELETE statements: " + total);
//Console.WriteLine("Duration: " + sw.ElapsedMilliseconds);



// Rå SQL

//var sw = new Stopwatch();
//sw.Start();


//var total = context.Database.ExecuteSqlRaw("DELETE FROM Flights WHERE FlightId > 0");


//sw.Stop();
//Console.WriteLine(total);
//Console.WriteLine("Duration: " + sw.ElapsedMilliseconds);
