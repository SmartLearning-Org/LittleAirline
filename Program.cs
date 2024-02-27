using LittleAirline.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Z.EntityFramework.Plus;

using var context = new AppDbContext();
var sw = new Stopwatch();




// Object vs foreign key reference


// Object reference
// Her er 3 kald til Db

//Flight flight = context.Flights.Find(1);
//Aircraft aircraft = context.Aircrafts.Find(1);
//flight.Aircraft = aircraft;
//context.SaveChanges();


// Foreign key reference
// Her er 2 kald til Db

//Flight flight = context.Flights.Find(1);
//flight.AircraftId = 1;
//context.SaveChanges();



// Bulk operationer


// Single delete
// Her bliver de 2000 ændringer gemt hver gang.
//sw.Start();
//int total = 0;
//var flights = context.Flights.Where(x => x.FlightId > 0).ToList();
//foreach (var flight in flights)
//{
//    context.Flights.Remove(flight);
//    var count = context.SaveChanges();
//    total += count;
//}
//sw.Stop();
//Console.WriteLine("Number of DELETE statements: " + total);
//Console.WriteLine("Duration: " + sw.ElapsedMilliseconds);


// Batch delete
// Her bliver de 2000 ændringer gemt en enkelt gang til sidst.

//sw.Start();
//int total = 0;
//var flights = context.Flights.Where(x => x.FlightId > 0).ToList();

//foreach (var flight in flights)
//{
//    context.Flights.Remove(flight);
//}
//total = context.SaveChanges();
//sw.Stop();
//Console.WriteLine("Number of DELETE statements: " + total);
//Console.WriteLine("Duration: " + sw.ElapsedMilliseconds);


// Pseudo object
// Her loader vi ikke de 2000 objekter fra Db, men laver 2000 nye og
// sætter et Remove parameter på.

//sw.Start();
//int total = 0;
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

//sw.Start();
//var total = context.Database.ExecuteSqlRaw("DELETE FROM Flights WHERE FlightId > 0");
//sw.Stop();
//Console.WriteLine(total);
//Console.WriteLine("Duration: " + sw.ElapsedMilliseconds);



// Entity Framework Plus

//sw.Start();
//int total = 0;
//var count = context.Flights.Where(f => f.FlightId > 0).Delete();
//Console.WriteLine("Number of DELETE statements: " + count);
//sw.Stop();
//Console.WriteLine("Duration:" + sw.ElapsedMilliseconds);



// ExecuteDelete

//sw.Start();
//int total = 0;
//var count = context.Flights.Where(f => f.FlightId > 0).ExecuteDelete();
//Console.WriteLine("Number of DELETE statements: " + count);
//sw.Stop();
//Console.WriteLine("Duration:" + sw.ElapsedMilliseconds);


