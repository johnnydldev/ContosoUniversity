using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Models;
using DAOControllers.ManagerControllers;

namespace DAOControllers
{
    public class DAOStudent : IGenericRepository<Student>
    {

        private readonly string _connection = string.Empty;

        public DAOStudent(IConfiguration configuration)
        {
            _connection = configuration.GetConnectionString("universityConnection");
        }

        public async Task<List<Student>> getAll()
        {
            List<Student> studentList = new List<Student>();

            using (var objConnection = new SqlConnection(_connection))
            {
                SqlDataReader reader;
                try
                {

                    SqlCommand cmd = new SqlCommand("sp_list_all_students", objConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    await objConnection.OpenAsync();

                    using (reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            studentList.Add(new Student()
                            {
                                idStudent = Convert.ToInt32(reader["idStudent"]),
                                lastName = reader["lastName"].ToString(),
                                firstMidName = reader["firstMidName"].ToString(),
                                genre = reader["genre"].ToString(),
                                img = (byte[])reader["img"],
                                enrollmentDate = Convert.ToDateTime(reader["enrollmentDate"].ToString())

                            });//End employees listing

                        }
                    }//End information reading

                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    studentList = new List<Student>();
                }


            }//End using of stringConnection


            return studentList;
        }//End listing students

        public async Task<Student> getById(int idStudent)
        {
            Student student = new Student();

            return student;
        }//End get student by id

        public async Task<List<Student>> getAllMatches(int course, string name)
        {
            List<Student> studentList = new List<Student>();

            return studentList;
        }//End listing students matches with

        public async Task<List<Student>> getAllMatchedBy(int course)
        {
            List<Student> studentList = new List<Student>();

            return studentList;
        }//End listing students matches by course

        public async Task<List<Student>> getAllMatchesWith(string name)
        {
            List<Student> studentList = new List<Student>();

            return studentList;
        }//End listing students matches with name

        public async Task<int> getMaxId()
        {
            int id = 0;

            using (var objConnection = new SqlConnection(_connection))
            {
                try
                {
                    string consult = "SELECT MAX(idStudent) as idResult FROM Student";

                    SqlCommand cmd = new SqlCommand(consult, objConnection)
                    {
                        CommandType = CommandType.Text
                    };

                    await objConnection.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            id = Convert.ToInt32(reader["idResult"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    id = 0;

                }
            }

            id++;

            return id;
        }//End getting max id student

        public async Task<int> create(Student student)
        {
            int studentGenerated = 0;

            string message = string.Empty;

            try
            {
                using (var objConnection = new SqlConnection(_connection))
                {
                    SqlCommand cmd = new SqlCommand("sp_create_student", objConnection);
                    cmd.Parameters.AddWithValue("lastName", student.lastName);
                    cmd.Parameters.AddWithValue("firstMidName", student.firstMidName);
                    cmd.Parameters.AddWithValue("genre", student.genre);
                    cmd.Parameters.AddWithValue("img", student.img);
                    cmd.Parameters.Add("idResult", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("message", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    await objConnection.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    studentGenerated = Convert.ToInt32(cmd.Parameters["idResult"].Value);
                    message = cmd.Parameters["message"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                studentGenerated = 0;
                message = ex.ToString();
            }

            Console.WriteLine(message);

            return studentGenerated;
        }//End create student

        public async Task<bool> edit(Student student)
        {
            bool studentEdited = false;

            return studentEdited;
        }//End edit student

        public async Task<bool> delete(int idStudent)
        {
            bool studentDeleted = false;

            return studentDeleted;
        }//End edit student

    }//End DAO student class
}//End namespace DAOControllers