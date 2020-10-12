using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lesson3.Part1
{

    public interface ICarFactory
    {
        ICar CreateInstance(string description, string wheelsSize,
                            string engineCapacity, string engineTorque);
    }
    public interface ICar
    {
        string WheelsSize { get; }
        string EngineCapacity { get; }
        string EngineTorque { get; }
        string Name { get; }
    }
    public class Truck : ICar
    {
        private string wheelsSize;
        private string engineCapacity;
        private string engineTorque;
        public Truck(string wheelsSize, string engineCapacity,
                     string engineTorque)
        {
            this.wheelsSize = wheelsSize;
            this.engineCapacity = engineCapacity;
            this.engineTorque = engineTorque;
        }
        public string WheelsSize => this.wheelsSize;
        public string EngineCapacity => this.engineCapacity;
        public string EngineTorque => this.engineTorque;

        public override string ToString() => $"{Name},  " +
            $"Диаметр колеса = { this.WheelsSize }, " +
            $"объем двигателя= {this.EngineCapacity },  " +
            $"крутящий момент = { this.EngineTorque }";

        public string Name => "Грузовик";
    }

    public class Bus : ICar
    {
        private string wheelsSize;
        private string engineCapacity;
        private string engineTorque;

        public Bus(string wheelsSize, string engineCapacity,
                   string engineTorque)
        {
            this.wheelsSize = wheelsSize;
            this.engineCapacity = engineCapacity;
            this.engineTorque = engineTorque;
        }
        public string WheelsSize => this.wheelsSize;
        public string EngineCapacity => this.engineCapacity;
        public string EngineTorque => this.engineTorque;
        public override string ToString() => $"{Name}, Диаметр колеса = { this.WheelsSize }, объем двигателя={this.EngineCapacity},  крутящий момент = { this.EngineTorque }";
        public string Name => "Автобус";
    }

    public class UnknownCar : ICar
    {
        public UnknownCar()
        {
        }
        public string WheelsSize => string.Empty;
        public string EngineCapacity => string.Empty;
        public string EngineTorque => string.Empty;
        public override string ToString() => $"{Name}, Диаметр колеса = { this.WheelsSize }, объем двигателя={this.EngineCapacity},  крутящий момент = { this.EngineTorque }";
        public string Name => "Неизвестный автобоиль";
    }
    public class CarFactory : ICarFactory
    {
        Dictionary<string, Type> cars;

        public CarFactory()
        {
            LoadTypes();
        }

        public ICar CreateInstance(string description, string wheelsSize,
                                 string engineCapacity, string engineTorque)
        {
            Type t = GetTypeToCreate(description);

            if (t == null)
                return new UnknownCar();

            return Activator.CreateInstance(t, wheelsSize, engineCapacity,
                                            engineTorque) as ICar;
        }

        private Type GetTypeToCreate(string carType)
        {
            foreach (var car in cars)
            {
                if (car.Key.Contains(carType))
                {
                    return cars[car.Key];
                }
            }
            return null;
        }

        private void LoadTypes()
        {
            cars = new Dictionary<string, Type>();

            Type[] typesInThisAssembly =
                             Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in typesInThisAssembly)
            {
                if (type.GetInterface(typeof(ICar).ToString()) != null)
                {
                    cars.Add(type.Name, type);

                }
            }
        }
    }



    //------------------------------------

    public static class Part1
    {
        public static void ExecuteCode()
        {
            ICarFactory carFactory = LoadFactory();
            ICar[] cars = {  carFactory.CreateInstance("Bus", "275",
                                                       "7000", "1100"),
                            carFactory.CreateInstance("Truck", "385",
                                                      "16000", "3500"),
                            carFactory.CreateInstance("Beetle", "155",
                                                      "1600", "500")
                          };

            foreach (ICar car in cars)
            {
                Console.WriteLine($"Автомобиль: {car.GetType()}, {car}");
            }
        }
        private static ICarFactory LoadFactory()
        {
            string factoryName =
                             Properties.Settings.Default.DefaultCarFactory;
            return
                Assembly.GetExecutingAssembly().CreateInstance(factoryName)
                as ICarFactory;
        }
    }
}
