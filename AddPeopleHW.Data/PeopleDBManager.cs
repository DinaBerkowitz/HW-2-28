using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPeopleHW.Data
{
    public class PeopleDBManager
    {

        private string _connectionString;

        public PeopleDBManager(string cs)
        {
            _connectionString = cs;
        }

        public void Add(Person p)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = "INSERT INTO PEOPLE(FirstName,LastName,Age)" +
                              " VALUES(@firstName,@lastName,@age)";

            cmd.Parameters.AddWithValue("@firstName", p.FirstName);
            cmd.Parameters.AddWithValue("@lastName", p.LastName);
            cmd.Parameters.AddWithValue("@age", p.Age);
            connection.Open();
            cmd.ExecuteNonQuery();

        }

        public void AddManyPeople(List<Person> p)
        {
            foreach (Person person in p)
            {
                Add(person);
            }
        }

        public List<Person> GetAllPeople()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM PEOPLE";

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Person> p = new();
            while (reader.Read())
            {
                p.Add(new Person
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            return p;
        }


    }
}
