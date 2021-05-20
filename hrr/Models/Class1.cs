using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.OData.Edm;

namespace hrr.Models
{
    public class BasicInformation
    {
        public int ID { get; set; }
        public int Department { get; set; }
        public int StaffCode { get; set; }
        public string Name { get; set; }
        public DateTime OnDuty { get; set; }
        public string Position { get; set; }
        public int Supervisor { get; set; }
        
    }
    public class Departments
    {
        public int ID { get; set; }
        public string Department { get; set; }

    }
    public class Supervisors
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int Department { get; set; }

    }
    public class Experiences
    {
        public int ID { get; set; }
        public string ServiceUnit { get; set; }
        public string Title { get; set; }
        public string JobDescription { get; set; }
        public string Start { get; set; }
        public string Finish { get; set; }
        public int BasicInformationID { get; set; }

    }
    public class Educations
    {
        public int ID { get; set; }
        public string Degree { get; set; }
        public string School { get; set; }
        public string Department { get; set; }
        public int BasicInformationID { get; set; }
        
    }

    public class DBmanager
    {
        public List<BasicInformation> GetCards()
        {
            List<BasicInformation> basicInformations = new List<BasicInformation>();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM basicInformation");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
    if (reader.HasRows) {
        while (reader.Read()) {
                    BasicInformation basicInformation = new BasicInformation{
                ID = reader.GetInt32(reader.GetOrdinal("id")),
                Department = reader.GetInt32(reader.GetOrdinal("department")),
                StaffCode = reader.GetInt32(reader.GetOrdinal("staffCode")),
                Name = reader.GetString(reader.GetOrdinal("name")),
                OnDuty = reader.GetDateTime(reader.GetOrdinal("onDuty")),
                Position = reader.GetString(reader.GetOrdinal("position")),
                Supervisor = reader.GetInt32(reader.GetOrdinal("supervisor")),
                    };
                basicInformations.Add(basicInformation);
        }
    }
    else {
        Console.WriteLine("資料庫為空！");
    }
            sqlConnection.Close();
    return basicInformations;
        }
        public List<Departments> GetDepartments()
        {
            List<Departments> departments = new List<Departments>();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM department");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Departments department = new Departments
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("id")),
                        Department = reader.GetString(reader.GetOrdinal("department")),
                    };
                    departments.Add(department);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();
            return departments;
        }
        public List<Supervisors> GetSupervisors()
        {
            List<Supervisors> supervisors = new List<Supervisors>();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM supervisor");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Supervisors supervisor = new Supervisors
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("id")),
                        Department = reader.GetInt32(reader.GetOrdinal("department")),
                        Title = reader.GetString(reader.GetOrdinal("title")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                    };
                    supervisors.Add(supervisor);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();
            return supervisors;
        }
        public void NewCard(BasicInformation basicInformation)
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand(
            @"INSERT INTO basicInformation (department,staffCode,name,onDuty,position,supervisor)
              VALUES (@department,@staffCode,@name,@onDuty,@position,@supervisor)");
        sqlCommand.Connection = sqlConnection;
        sqlCommand.Parameters.Add(new SqlParameter("@department", basicInformation.Department));
        sqlCommand.Parameters.Add(new SqlParameter("@staffCode", basicInformation.StaffCode));
        sqlCommand.Parameters.Add(new SqlParameter("@name", basicInformation.Name));
        sqlCommand.Parameters.Add(new SqlParameter("@onDuty", basicInformation.OnDuty));
        sqlCommand.Parameters.Add(new SqlParameter("@position", basicInformation.Position));
        sqlCommand.Parameters.Add(new SqlParameter("@supervisor", basicInformation.Supervisor));
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
        }
    public BasicInformation GetByID(int id)
    {
        BasicInformation basicInformation = new BasicInformation();
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString);
        SqlCommand sqlCommand = new SqlCommand("SELECT * FROM basicInformation WHERE id = @id");
        sqlCommand.Connection = sqlConnection;
        sqlCommand.Parameters.Add(new SqlParameter("@id", id));
        sqlConnection.Open();
        SqlDataReader reader = sqlCommand.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                basicInformation = new BasicInformation
                {
                    ID = reader.GetInt32(reader.GetOrdinal("id")),
                    Department = reader.GetInt32(reader.GetOrdinal("department")),
                    StaffCode = reader.GetInt32(reader.GetOrdinal("staffCode")),
                    Name = reader.GetString(reader.GetOrdinal("name")),
                    OnDuty = reader.GetDateTime(reader.GetOrdinal("onDuty")),
                    Position = reader.GetString(reader.GetOrdinal("position")),
                    Supervisor = reader.GetInt32(reader.GetOrdinal("supervisor")),
                };
            }
        }
        else
        {
            basicInformation.Name = "未找到資料";
        }
        sqlConnection.Close();
        return basicInformation;
    }
        public Educations GetByEdu(int id)
        {
            Educations education = new Educations();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM education WHERE basicInformationID = @id");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@id", id));
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    education = new Educations
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("id")),
                        Degree = reader.GetString(reader.GetOrdinal("degree")),
                        School = reader.GetString(reader.GetOrdinal("school")),
                        Department = reader.GetString(reader.GetOrdinal("department")),
                        BasicInformationID = reader.GetInt32(reader.GetOrdinal("basicInformationID")),
                    };
                }
            }
            else
            {
                education.Department = "未找到資料";
            }
            sqlConnection.Close();
            return education;
        }
        public Experiences GetByExp(int id)
        {
            Experiences experience = new Experiences();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM experience WHERE basicInformationID = @id");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@id", id));
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    experience = new Experiences
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("id")),
                        ServiceUnit = reader.GetString(reader.GetOrdinal("serviceUnit")),
                        Title = reader.GetString(reader.GetOrdinal("title")),
                        JobDescription = reader.GetString(reader.GetOrdinal("jobDescription")),
                        Start = reader.GetString(reader.GetOrdinal("start")),
                        Finish = reader.GetString(reader.GetOrdinal("finish")),
                        BasicInformationID = reader.GetInt32(reader.GetOrdinal("basicInformationID")),
                    };
                }
            }
            else
            {
                experience.Title = "未找到資料";
            }
            sqlConnection.Close();
            return experience;
        }
        public void UpdateCard(BasicInformation basicInformation)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(
                @"UPDATE basicInformation SET department = @department, staffCode = @staffCode, name = @name, onDuty = @onDuty, position = @position, supervisor = @supervisor WHERE id = @id");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@id", basicInformation.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@department", basicInformation.Department));
            sqlCommand.Parameters.Add(new SqlParameter("@staffCode", basicInformation.StaffCode));
            sqlCommand.Parameters.Add(new SqlParameter("@name", basicInformation.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@onDuty", basicInformation.OnDuty));
            sqlCommand.Parameters.Add(new SqlParameter("@position", basicInformation.Position));
            sqlCommand.Parameters.Add(new SqlParameter("@supervisor", basicInformation.Supervisor));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void UpdateEducations(Educations education)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(
                @"UPDATE education SET degree = @degree, school = @school, department = @department WHERE basicInformationID = @id");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@degree", education.Degree));
            sqlCommand.Parameters.Add(new SqlParameter("@school", education.School));
            sqlCommand.Parameters.Add(new SqlParameter("@department", education.Department));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void UpdateExperiences(Experiences experience)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(
                @"UPDATE experience SET serviceUnit = @serviceUnit, title = @title, jobDescription = @jobDescription, start = @start, finish = @finish WHERE basicInformationID = @id");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@serviceUnit", experience.ServiceUnit));
            sqlCommand.Parameters.Add(new SqlParameter("@title", experience.Title));
            sqlCommand.Parameters.Add(new SqlParameter("@jobDescription", experience.JobDescription));
            sqlCommand.Parameters.Add(new SqlParameter("@start", experience.Start));
            sqlCommand.Parameters.Add(new SqlParameter("@finish", experience.Finish));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void DeleteCardById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(
                @"DELETE FROM basicInformation  WHERE id = @id");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@id", id));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public BasicInformation GetBasicInformationID()
        {
            BasicInformation basicInformation = new BasicInformation();
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("SELECT MAX(id) FROM basicInformation ");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    basicInformation = new BasicInformation
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("")),
                    };
                }
            }
            else
            {
                basicInformation.Name = "未找到資料";
            }
            sqlConnection.Close();
            return basicInformation;
        }
        public void CreateExperience(Experiences basicInformation)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(
                @"INSERT INTO  experience (serviceUnit,title,jobDescription,start,finish,basicInformationID)
                  VALUES(@serviceUnit,@title,@jobDescription,@start,@finish,@basicInformationID )");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@serviceUnit", basicInformation.ServiceUnit));
            sqlCommand.Parameters.Add(new SqlParameter("@title", basicInformation.Title));
            sqlCommand.Parameters.Add(new SqlParameter("@jobDescription", basicInformation.JobDescription));
            sqlCommand.Parameters.Add(new SqlParameter("@start", basicInformation.Start));
            sqlCommand.Parameters.Add(new SqlParameter("@finish", basicInformation.Finish));
            sqlCommand.Parameters.Add(new SqlParameter("@basicInformationID", basicInformation.BasicInformationID));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void CreateEducation(Educations BasicInformation)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(
                @"INSERT INTO  education (degree,school,department,basicInformationID)
                  VALUES(@degree,@school,@department,@basicInformationID)");
            sqlCommand.Connection = sqlConnection;
            sqlCommand.Parameters.Add(new SqlParameter("@degree", BasicInformation.Degree));
            sqlCommand.Parameters.Add(new SqlParameter("@school", BasicInformation.School));
            sqlCommand.Parameters.Add(new SqlParameter("@department", BasicInformation.Department));
            sqlCommand.Parameters.Add(new SqlParameter("@basicInformationID", BasicInformation.BasicInformationID));
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }


    }
}
