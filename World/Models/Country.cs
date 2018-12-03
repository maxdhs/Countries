using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using World;

namespace World.Models
{
    public class Country
    {
        private int _id;
        private string _name;
        private string _headOfState;
        private int _population;

        public Country(string name, int population)
        {
            _name = name;
            _population = population;
        }

        public string GetCountryName()
        {
            return _name;
        }

        public int GetPopulation()
        {
            return _population;
        }
        
        public static List<Country> GetAll()
        {
            List<Country> allCountries = new List<Country> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while(rdr.Read())
            {
                string _name = rdr.GetString(1);
                int _population = rdr.GetInt32(6);
               
                Country newCountry = new Country(_name, _population);
                allCountries.Add(newCountry);
            }

            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }

            return allCountries;
        }

        public static List<Country> FilterCountryName(string name)
        {
            List<Country> allCountries = new List<Country> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country WHERE Name = '" + name + "';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                string _name = rdr.GetString(1);
                int _population = rdr.GetInt32(6);
                
                Country newCountry = new Country(_name, _population);
                allCountries.Add(newCountry);

            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return allCountries;
        }

        public static List<Country> MinPopulationSize(int minPopulation)
        {
            List<Country> allCountries = new List<Country> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country WHERE Population >= " + minPopulation + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                string _name = rdr.GetString(1);
                int _population = rdr.GetInt32(6);
                
                Country newCountry = new Country(_name, _population);
                allCountries.Add(newCountry);

            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return allCountries;
        }

        public static List<Country> MaxPopulationSize(int maxPopulation)
        {
            List<Country> allCountries = new List<Country> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country WHERE Population <= " + maxPopulation + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                string _name = rdr.GetString(1);
                int _population = rdr.GetInt32(6);
                
                Country newCountry = new Country(_name, _population);
                allCountries.Add(newCountry);

            }
            conn.Close();
            if (conn !=null)
            {
                conn.Dispose();
            }
            return allCountries;
        }





    }
}
