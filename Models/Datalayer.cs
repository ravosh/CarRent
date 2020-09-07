
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CarRent.Helpers;
using CarRent.Models;

namespace CarRent.Models
{
    public class Datalayer
    {
        public static byte[] pImage;
        EncryptDecrypt enc = new EncryptDecrypt();
       private string con = "Data Source = DESKTOP-4CS6DNR; Initial Catalog = CarRent; User ID = sa; Password=sql@2019";



        public string Con
        {
            get
            {
                return con;
            }
        }
        public int Int_Process(String Storp, string[] parametername, string[] parametervalue)
        {
            int a = 0;
            try
            {
                SqlConnection con = new SqlConnection(Con);
                SqlCommand cmd = new SqlCommand(Storp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                for (int i = 0; i < parametername.Length; i++)
                {
                    if (parametername[i] == "@img")
                    {
                        cmd.Parameters.AddWithValue(parametername[i], pImage);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                    }
                }
                con.Open();
                a = cmd.ExecuteNonQuery();
                con.Dispose();
            }
            catch (Exception ex)
            {


            }
            return a;
        }
        public DataSet Ds_Process(String Storp, string[] parametername, string[] parametervalue)
        {
            try
            {

                SqlConnection con = new SqlConnection(Con);
                SqlCommand cmd = new SqlCommand(Storp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                for (int i = 0; i < parametername.Length; i++)
                {
                    cmd.Parameters.AddWithValue(parametername[i], parametervalue[i]);
                }
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                da.Dispose();
                con.Dispose();
                return ds;
            }
            catch (Exception ex)
            {
                DataSet ds = null;
                return ds;
            }

        }
        public DataSet MyDs_Process(String Storp)
        {
            SqlConnection con = new SqlConnection(Con);
            SqlCommand cmd = new SqlCommand(Storp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            da.Dispose();
            con.Dispose();
            return ds;

        }
        public DataSet getData(string Query)
        {

            DataSet AdvList = new DataSet();
            SqlConnection cn = new SqlConnection(Con);
            cn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(Query, cn);
            sda.Fill(AdvList);
            cn.Dispose();
            cn.Close();
            return AdvList;
        }

        public string runQuery(string cmd)
        {

            SqlDataAdapter dab = new SqlDataAdapter(cmd, Con);
            DataSet dsb = new DataSet();
            dsb.Clear();
            dab.Fill(dsb);
            GC.SuppressFinalize(dab);
            if (dsb.Tables[0].Rows.Count > 0)
            {
                return dsb.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                return "0";
            }
        }
        public int runQrydt(string cmd)
        {

            int result;
            SqlConnection con = new SqlConnection(Con);
            SqlCommand cmd1 = new SqlCommand(cmd, con);
            cmd1.CommandType = CommandType.Text;
            if (con.State == ConnectionState.Open)
            { con.Close(); }

            con.Open();
            result = cmd1.ExecuteNonQuery();
            con.Dispose();
            con.Close();
            return result;
        }

        public void runQry(string cmd)
        {

            SqlConnection con = new SqlConnection(Con);
            SqlCommand cmd1 = new SqlCommand(cmd, con);
            cmd1.CommandType = CommandType.Text;
            if (con.State == ConnectionState.Open)
            { con.Close(); }

            con.Open();
            cmd1.ExecuteNonQuery();
            con.Dispose();
            con.Close();
        }

        public DataSet runQueryDs(string cmd)
        {

            SqlDataAdapter dab = new SqlDataAdapter(cmd, Con);
            DataSet ds = new DataSet();
            ds.Clear();
            dab.Fill(ds);
            //GC.SuppressFinalize(p);
            GC.SuppressFinalize(dab);

            return ds;
        }


        public int SP_CAR_INFO(carinfo t)
        {
            try
            {
                string[] pname = { "@Id", "@image", "@carname", "@status" };
                string[] pvalue = { t.id.ToString(), t.carimage, t.carname, t.status };
                return Int_Process("SP_CAR_INFO", pname, pvalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int SP_USERSTORY1_INFO(userstory1 t)
        {
            try
            {
                string[] pname = { "@Id", "@carid", "@hourlyrate" };
                string[] pvalue = { t.id.ToString(), t.carid.ToString(), t.hourlyrate };
                return Int_Process("SP_USERSTORY1_INFO", pname, pvalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet SP_USERSTORY2_INFO(userstory2 t)
        {
            try
            {
                string[] pname = { "@Id", "@carid", "@customername" };
                string[] pvalue = { t.id.ToString(), t.carid.ToString(), t.Customername };
                return Ds_Process("SP_USERSTORY2_INFO", pname, pvalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DataSet SP_USERSTORY3_INFO(userstory3 t)
        {
            try
            {
                string[] pname = { "@Id", "@carid", "@status" };
                string[] pvalue = { t.id.ToString(), t.carid.ToString(), t.chkstatus.ToString() };
                return Ds_Process("SP_USERSTORY3_INFO", pname, pvalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int SP_USERSTORY4_INFO(userstory3 t)
        {
            try
            {
                string[] pname = { "@Id", "@carid" };
                string[] pvalue = { t.id.ToString(), t.carid.ToString() };
                return Int_Process("SP_USERSTORY4_INFO", pname, pvalue);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}

