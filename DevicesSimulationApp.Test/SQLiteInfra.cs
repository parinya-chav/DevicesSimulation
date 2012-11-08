using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Data.SQLite;
using System.Data;
using DeviceSimulation.Domain;
using DeviceSimulation.Infrastructure;

namespace DevicesSimulationApp.Test
{
    [TestClass]
    public class SQLiteInfra
    {
        /// <summary>
        /// Test DB STD
        /// </summary>
        String dbConnection;
        SQLiteDatabase db;        
        [TestMethod]
        public void TestMethod1()
        {
            dbConnection = "Data Source=D:\\OpenSource\\SQLite\\sqliteShell\\test";

            SQLiteConnection cnn = new SQLiteConnection(dbConnection);

            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();
            try
            {
                SQLiteCommand cmd;
                cnn.Open();  //Initiate connection to the db
                cmd = cnn.CreateCommand();
                cmd.CommandText = "select * from albums join tracks using(album_id) order by album_name";
                                    //"inner join tracks as t on a.album_id  == t.album_id order by a.album_name";  //set the passed query
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource
            }
            catch (SQLiteException ex)
            {
                //Add your exception code here.
            }
            cnn.Close();            

            for (int i = 0; i < dt.Rows.Count; i++)            
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write("{0}:{1} ",dt.Columns[j].ToString(), dt.Rows[i][j].ToString());

                    if (i == 5)
                    {
                        if (dt.Columns[j].ToString().Equals("track_length"))
                        {
                            dt.Rows[i][j] = 111;
                        }
                    }
                }
                Console.WriteLine("");
            }

        }
        [TestMethod]
        public void TestSQLite()
        {
            string connStr = @"data source=""D:\Lab\LabSQLite\SQLiteDb""";
            string sql = "select * from Colors";

            SQLiteConnection conn = new SQLiteConnection(connStr);
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader rdr = null;
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();
            
            try
            {
                //rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                conn.Open();
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt); //fill the datasource                

            }
            finally
            {
                conn.Close();
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Console.WriteLine(dt.Rows[i]["name"] + " " + dt.Rows[i]["hex"]);
            }

        }
        [TestMethod]
        public void TestSQLiteDBGetData()
        {
            db = new SQLiteDatabase();
            DataTable dt;
            string sql = "select * from colors";
            dt = db.GetDataTable(sql);
            Console.WriteLine("Count: {0}", dt.Rows.Count.ToString());
        }
        [TestMethod]
        public void TestSQLiteDBInsert()
        {
            db = new SQLiteDatabase();
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("id", "3");
            data.Add("name", "Blue");
            data.Add("hex", "0000ff");
            try
            {
                db.Insert("colors", data);
            }
            catch (Exception ex)
            {
                Console.Write("Error: {0}", ex.Message);
            }
        }
        [TestMethod]
        public void TestSQLiteDBUpdate()
        {
            db = new SQLiteDatabase();
            int id = 1;

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("name", "Black");

            try
            {
                db.Update("colors", data, String.Format("colors.id = {0}", id));
            }
            catch (Exception ex)
            {
                Console.Write("Error: {0}", ex.Message);
            }
        }
        [TestMethod]
        public void TestSQLiteDBDelete()
        {
            db = new SQLiteDatabase();
            int id = 1;
            try
            {
                db.Delete("colors", String.Format("colors.id={0}", id));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        


    }
}
