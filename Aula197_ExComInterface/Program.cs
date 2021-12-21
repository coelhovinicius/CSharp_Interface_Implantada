/* >>> PROGRAMA PRINCIPAL <<< */
using System;
using System.Globalization;
using Aula197_ExComInterface.Entities;
using Aula197_ExComInterface.Services;

namespace Aula197_ExComInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rental data: ");
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Rental date (dd/MM/yyyy hh:mm): ");
            DateTime rentalDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return date (dd/MM/yyyy hh:mm): ");
            DateTime returnDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            // Instancia o objeto tipo CarRental com os argumentos entre parenteses
            CarRental carRental = new CarRental(rentalDate, returnDate, new Vehicle(model));

            // Instancia o RentalService
            RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());

            rentalService.ProcessInvoice(carRental); // Gera o objeto "Invoice" associado ao aluguel do CarRental

            Console.WriteLine("Invoice:");
            Console.WriteLine(carRental.Invoice);

        }
    }
}