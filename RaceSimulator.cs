using System;

namespace SecondLab
{
    class RaceSimulator
    {
        static void Main()
        {
            string race_type = "0", distance = "0", racers;
            string[] mracers;
            int idistance = 0;
            int count = 0; //Количество участников гонки
            List<Vehicle> vehicles_to_race = new List<Vehicle>(); //Участники гонки

            while (true)
            {
                //Задаем тип гонки
                while (race_type != "end" && race_type != "1" && race_type != "2" && race_type != "3")
                {
                    System.Console.WriteLine("Выберите тип гонки:\n1. только для наземного транспорта \n2. только для воздушного транспорта \n3. для всех видов транспортных средств");
                    race_type = System.Console.ReadLine();
                    if (race_type != "end" && race_type != "1" && race_type != "2" && race_type != "3")
                    {
                        System.Console.WriteLine("Введено некорректное значение!");
                    }
                }
                if (race_type == "end")
                    break;

                //Вводим длину дистанции
                while (idistance <= 0 && distance != "end")
                {
                    System.Console.Write("Введите длину дистанции: ");
                    distance = System.Console.ReadLine();

                    if (distance == "end")
                        break;

                    bool correct = int.TryParse(distance, out idistance);
                    if (!correct || idistance <= 0)
                    {
                        System.Console.WriteLine("Введено некорректное значение!");
                    }
                }

                if (distance == "end")
                    break;

                //Подготовка участников гонки
                Vehicle[] vehicles = new Vehicle[8];
                vehicles[0] = new AirVehicle();
                ((AirVehicle)vehicles[0]).SetVehicle("Ступа Бабы Яги", 10, idistance => idistance * 0.2, idistance);
                vehicles[1] = new AirVehicle();
                ((AirVehicle)vehicles[1]).SetVehicle("Метла", 20, idistance => Math.Sqrt(idistance), idistance);
                vehicles[2] = new AirVehicle();
                ((AirVehicle)vehicles[2]).SetVehicle("Ковер-самолет", 15, idistance => Math.Pow(idistance, 2), idistance);
                vehicles[3] = new AirVehicle();
                ((AirVehicle)vehicles[3]).SetVehicle("Летучий корабль", 30, idistance => idistance, idistance);
                vehicles[4] = new GroundVehicle();
                ((GroundVehicle)vehicles[4]).SetVehicle("Сапоги-скороходы", 30, 5, 10);
                vehicles[5] = new GroundVehicle();
                ((GroundVehicle)vehicles[5]).SetVehicle("Карета-тыква", 20, 10, 5);
                vehicles[6] = new GroundVehicle();
                ((GroundVehicle)vehicles[6]).SetVehicle("Избушка на курьих ножках", 40, 5, 30);
                vehicles[7] = new GroundVehicle();
                ((GroundVehicle)vehicles[7]).SetVehicle("Кентавр", 25, 15, 20);

                //Регистрируем участников гонки
                while (true)
                {
                    System.Console.WriteLine("Укажите номера участников гонки через запятую:\n1. Ступа Бабы Яги \n2. Метла \n3. Ковер-самолет \n4. Летучий корабль \n5. Сапоги-скороходы \n6. Карета-тыква \n7. Избушка на курьих ножках \n8. Кентавр");
                    racers = System.Console.ReadLine();

                    if (racers == "end")
                        break;

                    racers = racers.Trim();
                    mracers = racers.Split(",");

                    //Проверка корректности ввода участников гонки
                    bool iscorrect = true;
                    vehicles_to_race.Clear();
                    count = 0;
                    int iracer;

                    var duplicates = mracers.GroupBy(x => x)
                                    .Where(g => g.Count() > 1)
                                    .Select(y => y.Key)
                                    .ToList();
                    if (duplicates.Count != 0)
                    {
                        Console.WriteLine("Введено некорректное значение (нельзя указать одного и того же участника несколько раз)");
                        iscorrect = false;
                        continue;
                    }

                    foreach (string participant in mracers)
                    {
                        bool correct = int.TryParse(participant, out iracer);
                        if (!correct)
                        {
                            iscorrect = false;
                            break;
                        }
                        else
                        {
                            if (iracer <= 0 || iracer > 8)
                            {
                                Console.WriteLine("Введено некорректное значение");
                                iscorrect = false;
                                break;
                            }
                            if (race_type == "1" && iracer < 5)
                            {
                                Console.WriteLine("Введено некорректное значение (нельзя указать воздушный транспорт для наземной гонки)");
                                iscorrect = false;
                                break;
                            }
                            if (race_type == "2" && iracer > 4)
                            {
                                Console.WriteLine("Введено некорректное значение (нельзя указать наземный транспорт для воздушной гонки)");
                                iscorrect = false;
                                break;
                            }

                            //Заполнение участников гонки                    
                            switch (iracer)
                            {
                                case 1:
                                    vehicles_to_race.Add(vehicles[0]);
                                    break;
                                case 2:
                                    vehicles_to_race.Add(vehicles[1]);
                                    break;
                                case 3:
                                    vehicles_to_race.Add(vehicles[2]);
                                    break;
                                case 4:
                                    vehicles_to_race.Add(vehicles[3]);
                                    break;
                                case 5:
                                    vehicles_to_race.Add(vehicles[4]);
                                    break;
                                case 6:
                                    vehicles_to_race.Add(vehicles[5]);
                                    break;
                                case 7:
                                    vehicles_to_race.Add(vehicles[6]);
                                    break;
                                case 8:
                                    vehicles_to_race.Add(vehicles[7]);
                                    break;
                            }
                            count++;
                        }
                    }
                    if (iscorrect)
                        break;
                }

                if (racers == "end")
                    break;
                System.Console.WriteLine("Гонка запущена!");

                //Определение победителя гонки
                double time_without_rest, the_best_time = -1, time, count_of_rest;
                for (int i = 0; i < count; i++)
                {
                    if (vehicles_to_race[i].type == "ground")
                    {
                        time_without_rest = (double)idistance / vehicles_to_race[i].speed;
                        count_of_rest = Math.Round(time_without_rest / ((GroundVehicle)vehicles_to_race[i]).time_before_rest, 0);
                        time = Math.Round(time_without_rest + Math.Floor(count_of_rest) * ((GroundVehicle)vehicles_to_race[i]).time_for_rest, 2);
                    }
                    else
                    {
                        double a = Math.Pow(vehicles_to_race[i].speed, 2);
                        double b = 2 * idistance * ((AirVehicle)vehicles_to_race[i]).acceleration_coefficient;
                        time = Math.Round((Math.Sqrt(a + b) - vehicles_to_race[i].speed) / ((AirVehicle)vehicles_to_race[i]).acceleration_coefficient, 2);
                    }
                    vehicles_to_race[i].time = time;
                    if (the_best_time == -1 || time < the_best_time)
                    {
                        the_best_time = time;
                    }
                }

                //Сортировка прибывших участников
                IEnumerable<Vehicle> sortedVehicles =
                        from vehicle in vehicles_to_race
                        orderby vehicle.time ascending, vehicle.name ascending
                        select vehicle;

                int j = 0;
                //Вывод победителей
                Console.WriteLine($"Победители гонки с наилучшим временем {the_best_time}с:");
                foreach (Vehicle vehicle in sortedVehicles)
                {
                    if (vehicle.time > the_best_time)
                        break;
                    Console.WriteLine($"{vehicle.name}");
                    j++;
                }

                if (j == count)
                {
                    Console.WriteLine("Поздравляем наших участников, сегодня они все победители!");
                }
                else
                {
                    //Вывод остальных участников
                    Console.WriteLine("Время прибытия других участников гонки:");
                    foreach (Vehicle vehicle in sortedVehicles)
                    {
                        if (vehicle.time > the_best_time)
                            Console.WriteLine("{0}: {1}с", vehicle.name, vehicle.time);
                    }
                }

                //Начало новой гонки
                string answer;
                while (true)
                {
                    Console.Write("Хотите повторить гонку?(y/n)");
                    answer = Console.ReadLine();
                    if (answer != "y" && answer != "n")
                    {
                        Console.WriteLine("Введено некорректное значение!");
                    }
                    else
                    {
                        break;
                    }
                }
                if (answer == "n")
                {
                    break;
                }
                else
                {
                    race_type = "0"; distance = "0";
                }
            }
        }
    }
}
