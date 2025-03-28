using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;
using WebAppMVC.Models;

namespace WebAppMVC.Dal
{
	public class Studal
	{
        private string connectionString = ConfigurationManager.ConnectionStrings["add"].ToString();

        // READ (Get all students)
        public List<Registration> GetAllStudents()
        {
            List<Registration> studentlist = new List<Registration>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM webform", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    studentlist.Add(new Registration
                    {
                        userID = Convert.ToInt32(rdr["userID"]),
                        name = rdr["Uname"].ToString(),
                        contact = rdr["Ucontact"].ToString(),
                        address= rdr["Uaddress"].ToString(),
                        password= rdr["UPassword"].ToString(),
                    });
                }
            }
            return studentlist;
        }

        // CREATE
        public void AddStudents(Registration registration)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO webform (userID, Uname, Ucontact, Uaddress, UPassword  ) VALUES (@userID, @Uname, @Ucontact, @Uaddress, @UPassword )";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userID", registration.userID);
                cmd.Parameters.AddWithValue("@Uname", registration.name);
                cmd.Parameters.AddWithValue("@Ucontact", registration.contact);
                cmd.Parameters.AddWithValue("@Uaddress", registration.address);
                cmd.Parameters.AddWithValue("@UPassword", registration.password);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // UPDATE
        public void UpdateStudent(Registration registration)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE webform SET Uname = @Uname, Ucontact = @Ucontact ,Uaddress = @Uaddress , UPassword = @UPassword  WHERE userID = @userID";
                SqlCommand cmd = new SqlCommand(query, con);
           ;
                cmd.Parameters.AddWithValue("@userID", registration.userID);
                cmd.Parameters.AddWithValue("@Uname", registration.name);
                cmd.Parameters.AddWithValue("@Ucontact", registration.contact);
                cmd.Parameters.AddWithValue("@Uaddress", registration.address);
                cmd.Parameters.AddWithValue("@UPassword", registration.password);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void DeleteStudent(int userID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM webform  WHERE userID = @userID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userID", userID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // GET Product by ID
        public Registration GetStudentById(int userID)
        {
            Registration student = new Registration();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM webform WHERE userID = @userID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@userID", userID);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    student.userID = Convert.ToInt32(rdr["userID"]);
                    student.name = rdr["Uname"].ToString();
                    student.contact = rdr["Ucontact"].ToString();
                    student.address = rdr["Uaddress"].ToString();
                    student.password = rdr["UPassword"].ToString();
                }
            }
            return student;
        }
    }
}
