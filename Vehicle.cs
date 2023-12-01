using System;

namespace SecondLab{

    abstract class Vehicle{
        public string name;
        public string type;
        public int speed;
        public double time;
        public void SetVehicle(string name, int speed, string type){
            this.name = name;
            this.speed = speed;
            this.type = type;
        }
    }

    class AirVehicle : Vehicle{
        public double acceleration_coefficient;
        public Func<double, double> AccelerationFormula { get; set; }
        public void SetVehicle(string name, int speed, Func<double, double> AccelerationFormula, int distance){
            base.SetVehicle(name, speed, "air");
            this.acceleration_coefficient = AccelerationFormula(distance);
        }
    }

    class GroundVehicle : Vehicle{
        public int time_before_rest;
        public int time_for_rest;
        public void SetVehicle(string name, int speed, int time_before_rest, int time_for_rest){
            base.SetVehicle(name, speed, "ground");
            this.time_before_rest = time_before_rest;
            this.time_for_rest = time_for_rest;
        }
    }
}
