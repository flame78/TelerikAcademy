
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System;

static public class MySqlTransfer
{
    static public void DatFile(string server, string dBName, string table, string user, string pass, string fileName)
    {
        MySqlConnection conn;
        StreamReader reader = new StreamReader(fileName);
        Queue<string> lines = new Queue<string>();

        using (reader)
        {
            while (reader.EndOfStream != true)
            {
                lines.Enqueue(reader.ReadLine());
            }
        }


        conn = OpenConnection(server, dBName, user, pass);

        while (lines.Count > 0)
        {
            string[] tokens = new string[8];
            tokens = lines.Dequeue().Split('|');
            
            for (int i = 0; i < 8; i++)
            {
                tokens[i] = tokens[i].Trim();
            }

            MySqlCommand cmd = new MySqlCommand(string.Format
                ("insert into {0} (GameEnd,GameType,Price,Discount,GameTime,Operator,GameTable,Comments) values('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", table, tokens[0], tokens[1], tokens[2], tokens[3], tokens[4], tokens[5], tokens[6], tokens[7]), conn);

            cmd.ExecuteNonQuery();
        }

        conn.Close();
    }

    private static MySqlConnection OpenConnection(string server, string dBName, string user, string pass)
    {
        MySqlConnection result = new MySqlConnection();

        string connStr = String.Format("server={0}; database={1}; user id={2}; password={3}; pooling=false",
             server, dBName, user, pass);

        try
        {
            result = new MySqlConnection(connStr);
            result.Open();
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error connecting to the server: " + ex.Message);
        }

        return result;
    }

    static public void CreateMyDbTbl(string server, string user, string pass)
    {
        MySqlConnection conn;
        conn = OpenConnection(server, "", user, pass);

        MySqlCommand cmd = new MySqlCommand(@"CREATE DATABASE `test` /*!40100 DEFAULT CHARACTER SET latin1 */;
            CREATE TABLE  `test`.`tbl` (
             `GameEnd` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
             `GameType` text,
             `Price` decimal(3,2) DEFAULT '0.00',
             `Discount` tinyint(4) DEFAULT NULL,
             `GameTime` smallint(6) DEFAULT NULL,
             `Operator` text,
             `GameTable` text,
             `Comments` text,
             PRIMARY KEY (`GameEnd`)
           ) ENGINE=MyISAM DEFAULT CHARSET=utf8 COMMENT='Events';", conn);

        cmd.ExecuteNonQuery();

        conn.Close();

    }
}
