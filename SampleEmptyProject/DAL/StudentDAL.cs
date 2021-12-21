using Dapper;
using Microsoft.Extensions.Configuration;
using SampleEmptyProject.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace SampleEmptyProject.DAL
{
    public class StudentDAL : IStudentDAL
    {
        private IConfiguration _config;
        public StudentDAL(IConfiguration config)
        {
            _config = config;
        }

        private string getConnStr()
        {
            return _config.GetConnectionString("LocalConnection");
        }

        public void Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(getConnStr()))
            {
                string strSql = @"select * from Students order by FirstName asc";
                var results = conn.Query<Student>(strSql);
                return results;
            }
        }

        /*public IEnumerable<Student> GetAll()
        {
            List<Student> lstStudent = new List<Student>();
            using(SqlConnection conn = new SqlConnection(getConnStr()))
            {
                string sql = @"select * from Students order by FirstName asc";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lstStudent.Add(new Student
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            EnrollmentDate = Convert.ToDateTime(dr["EnrollmentDate"])
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return lstStudent;
        }*/

        public Student GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(getConnStr()))
            {
                var strSql = @"select * from Students where ID=@ID";
                var param = new { ID=id };
                var result = conn.QuerySingle<Student>(strSql, param);
                return result;
            }
        }

        public void Insert(Student student)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Student student)
        {
            throw new System.NotImplementedException();
        }
    }
}
