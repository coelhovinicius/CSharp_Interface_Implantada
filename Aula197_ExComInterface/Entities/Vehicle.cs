/* >>> CAMADA DE DOMINIO - CLASSE VEHICLE - PASTA ENTITIES <<< */
namespace Aula197_ExComInterface.Entities
{
    class Vehicle
    {
        public string Model { get; set; }

        public Vehicle(string model)
        {
            Model = model;
        }
    }
}