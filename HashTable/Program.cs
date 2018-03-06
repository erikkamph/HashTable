﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cities = System.IO.File.ReadAllLines("cities100000.txt");
            HashDictionary<GeoLocation<double>, City> hashDictionary = new HashDictionary<GeoLocation<double>, City>(10007);
            KeyValuePair<GeoLocation<double>, City> key = new KeyValuePair<GeoLocation<double>, City>(new GeoLocation<double>(10,10), new City("Tjenarey", 10,10,500000));
            KeyValuePair<GeoLocation<double>, City> valuePair = new KeyValuePair<GeoLocation<double>, City>(new GeoLocation<double>(10.503287498, 20.324453168413547355465138541354653), new City("Hejsan", 10.503287498, 20.324453168413547355465138541354653, 500000));
            KeyValuePair<GeoLocation<double>, City> keyValue = new KeyValuePair<GeoLocation<double>, City>(new GeoLocation<double>(115, 10), new City("Svensson", 115, 10, 500000));
            KeyValuePair<GeoLocation<double>, City> valueKey = new KeyValuePair<GeoLocation<double>, City>(new GeoLocation<double>(20, -115), new City("Lundsson", 20, -115, 500000));

            foreach (var city in cities)
            {
                string[] city_info = city.Split('\t');

                string cityName = city_info[0];
                double cityLongitude = Double.Parse(city_info[1]);
                double cityLatitude = Double.Parse(city_info[2]);
                int cityPopulation = Int32.Parse(city_info[3]);

                KeyValuePair<GeoLocation<double>,City> cityKeyValuePair =

                hashDictionary.Add(new KeyValuePair<GeoLocation<double>, City>(new GeoLocation<double>(Double.Parse(city_info[1].ToString(), System.Globalization.CultureInfo.CreateSpecificCulture("en-EN")), Double.Parse(city_info[2].ToString(), System.Globalization.CultureInfo.CreateSpecificCulture("en-EN"))), new City(city_info[0], Double.Parse(city_info[1].ToString(), System.Globalization.CultureInfo.CreateSpecificCulture("en-EN")), Double.Parse(city_info[2].ToString(), System.Globalization.CultureInfo.CreateSpecificCulture("en-EN")), int.Parse(city_info[3].ToString()))));
            }

            hashDictionary.Add(key);
            hashDictionary.Add(valuePair);
            hashDictionary.Add(keyValue);
            hashDictionary.Add(valueKey);

            foreach (var city in hashDictionary)
            {
                Console.WriteLine(city.Value.ToString());
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Count: " + hashDictionary.Count);
            Console.WriteLine(hashDictionary.Contains(key));

            City city1;
            Console.WriteLine(hashDictionary.TryGetValue(key.Key, out city1));
            //Console.WriteLine(hashDictionary.Find(new GeoLocation<double>(101.05, 35.45)));

            hashDictionary.Clear();

            foreach (var city in cities)
            {
                string[] city_info = city.Split('\t');

                hashDictionary[new GeoLocation<double>(Double.Parse(city_info[1], System.Globalization.CultureInfo.CreateSpecificCulture("en-EN")), Double.Parse(city_info[2], System.Globalization.CultureInfo.CreateSpecificCulture("en-EN")))] = new City(city_info[0], Double.Parse(city_info[1], System.Globalization.CultureInfo.CreateSpecificCulture("en-EN")), Double.Parse(city_info[2], System.Globalization.CultureInfo.CreateSpecificCulture("en-EN")), int.Parse(city_info[3]));
            }

            GeoLocation<double> location = new GeoLocation<double>(100.45123, 50.5648);
            hashDictionary[location] = new City("Test city", Double.Parse("100.45123", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN")), Double.Parse("50.5648", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN")), 500000);

            Thread.Sleep(3000);
            Console.Clear();

            foreach (var city in hashDictionary)
            {
                Console.WriteLine(city.Value.ToString());
            }

            Console.WriteLine(hashDictionary.Count);

            Console.WriteLine(hashDictionary[new GeoLocation<double>(Double.Parse("100.45123", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN")), Double.Parse("50.5648", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN")))]);
            
            hashDictionary[location] = new City("Test city", Double.Parse("100.45123", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN")), Double.Parse("50.5648", System.Globalization.CultureInfo.CreateSpecificCulture("en-EN")), 750000);

            Console.WriteLine(hashDictionary[location]);
        }
    }
}
