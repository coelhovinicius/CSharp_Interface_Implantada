/* >>> CAMADA DE SERVICOS - CLASSE BRAZILTAXSERVICE - PASTA SERVICES <<< */

namespace Aula197_ExComInterface.Services
{
    class BrazilTaxService : ITaxService
    {
        public double Tax(double amount)
        {
            if (amount <= 100.0)
            {
                return amount * 0.2;
            }
            else
            {
                return amount * 0.15;
            }
        }
    }
}