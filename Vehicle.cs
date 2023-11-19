using System;

namespace SecondLab{

    class Vehicle{
        public string name;
        public string type;
        public int speed;
        public double time;
    }

    class AirVehicle : Vehicle{
        public int acceleration_coefficient;
        public void SetVehicle(string name, int speed, int acceleration_coefficient){
            base.name = name;
            base.type = "air";
            base.speed = speed;
            this.name = name;
            this.acceleration_coefficient = acceleration_coefficient;
        }
    }

    class GroundVehicle : Vehicle{
        public int time_before_rest;
        public int time_for_rest;
        public void SetVehicle(string name, int speed, int time_before_rest, int time_for_rest){
            base.name = name;
            base.type = "ground";
            base.speed = speed;
            this.time_before_rest = time_before_rest;
            this.time_for_rest = time_for_rest;
        }
    }
}