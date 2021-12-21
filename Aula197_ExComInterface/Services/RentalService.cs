/* >>> CAMADA DE SERVICOS - CLASSE RENTALSERVICE - PASTA SERVICES <<< */
using System;
using Aula197_ExComInterface.Entities;

namespace Aula197_ExComInterface.Services
{
    class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        private ITaxService _taxService; // Interface

        // Inversao de Controle por meio de Injecao de Dependencia
        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start); // Calcula o periodo do aluguel do carro

            double basicPayment = 0.0; // Atribuir valor a variavel garante que ela sera iniciada
            if (duration.TotalHours <= 12.0)
            {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours); // "Math.Ceiling" arredonda para cima
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _taxService.Tax(basicPayment); // Calcula o imposto baseado no pagamento basico

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}