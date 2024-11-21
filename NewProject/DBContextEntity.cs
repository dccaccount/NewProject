using NewProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace NewProject
{
    public class DBContextEntity
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;
        DataTable dt;

        public DBContextEntity()
        {
            con = new SqlConnection("initial catalog= Employee; data source=DESKTOP-JCP2IJ3; Integrated Security=True;");
        }

        public DataTable Insert_User_Details(List<ProfileModel> user)
        {
            dt = new DataTable();
            foreach (var res in user)
            {
                da = new SqlDataAdapter("SP_Insert_User_Details", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@fname", SqlDbType.NVarChar).Value = res.Name;
                da.SelectCommand.Parameters.Add("@dob", SqlDbType.NVarChar).Value = res.DOB;
                da.SelectCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = res.Email;
                da.SelectCommand.Parameters.Add("@phone", SqlDbType.NVarChar).Value = res.Phone;
                da.SelectCommand.Parameters.Add("@address", SqlDbType.NVarChar).Value = res.Address;
                con.Open();
                da.Fill(dt);
                con.Close();
            }
            return dt;
        }

        public object User_email_validate(string email)
        {            
                cmd = new SqlCommand("SP_Insert_User_email_Validate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
                con.Open();
            var result = cmd.ExecuteScalar();
                con.Close();

                    
                return result;            
        }


        public DataTable Validte_User_Login(string userid,string password)
        {
            dt = new DataTable();
            try
            {
                
                    da = new SqlDataAdapter("SP_Insert_User_Login_Validate", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@ulogin", SqlDbType.NVarChar).Value = userid;
                    da.SelectCommand.Parameters.Add("@upwd", SqlDbType.NVarChar).Value = password;
                    con.Open();
                    da.Fill(dt);
                    con.Close();                
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
                return dt;
        }
    }
}