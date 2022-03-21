using System;
using System.Collections.Generic;
using System.IO;

namespace getcrmTest_Perelygina
{
    class Program
    {
        public static double all_time = 32;
        public class Place
        {
            public string name;
            public double value_of_time;
            public double importance_of_place;

            public double importance_of_time;
            public Place Get_this_place()
            {
                return this;
            }
            public void Print()
            {
                Console.WriteLine($"Название {name}, Количество времени на посещение {value_of_time}, Оценка важности {importance_of_place}, Оценка важности времени {importance_of_time}");
            }
        }
        
        public static List<Place> Get_Set_data()
        {
            List<string> lines = new List<string>();

            using (StreamReader reader = new StreamReader("data.txt"))
            {
                while (true)
                {
                    string temp = reader.ReadLine();
                    if (temp == null) break;
                    lines.Add(temp);
                }
            }

            List<Place> data = new List<Place>(lines.Count);

            for (int i = 0; i < lines.Count; i++)
            {
                data.Add(new Place());
                string[] words = lines[i].Split(';');

                data[i].name = words[0];
                data[i].value_of_time = Convert.ToDouble(words[1]);
                data[i].importance_of_place = Convert.ToDouble(words[2]);

                data[i].importance_of_time = data[i].importance_of_place / data[i].value_of_time; //посчитали важность времени (оценка места делить на затраченное время)
            }
            return data;
        }
        public static List<Place> Sort(List<Place> data)
        {
            Place temp = new Place();

            for (int i = 0; i < data.Count; i++)
            {
                for (int k = i + 1; k < data.Count; k++)
                {
                    if (data[i].importance_of_time < data[k].importance_of_time)
                    {
                        temp = data[i];
                        data[i] = data[k];
                        data[k] = temp;
                    }
                }
            }
            return data;
        }

        public static List<Place> Result(List<Place> data)
        {
            double temp_of_time = 0;
            List<Place> result = new List<Place>();

            for (int i = 0; i < data.Count; i++)
            {
                temp_of_time += data[i].value_of_time;
                result.Add(data[i]);

                if(i != data.Count - 1)
                {
                    if ((temp_of_time + data[i + 1].value_of_time) > all_time)
                        break;
                }
               
            }
            Console.WriteLine("Затраты времени на посещения = " + temp_of_time);
            return result;
        }
        static void Main(string[] args)
        {
            List<Place> data = Get_Set_data();
            data = Result(Sort(data));

            for (int i = 0; i < data.Count; i++)
            {
                data[i].Print();
            }

        }
    }
}
