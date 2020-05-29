using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class SqliteDataSetBuild : IDataSetBuilder
{
    private string connectionString;

    public SqliteDataSetBuild(string databaseFileAbsoluteLocation)
    {
//        connectionString = "URI=file:" + databaseFileAbsoluteLocation;
        connectionString = "Data Source=" + databaseFileAbsoluteLocation;
    }

    public DataSet BuildDataSet()
    {
        var dataSet = new DataSet();
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            // Open the connection and fill the DataSet.
            try
            {
                connection.Open();
                var tables = connection.GetSchema("Tables");

                foreach (DataRow row in tables.Rows)
                {
                    var query = $"SELECT * FROM {row[2].ToString()}";
                    SqliteDataAdapter adapter = new SqliteDataAdapter(query, connection);
                    DataTable table = new DataTable(row[2].ToString());
                    adapter.Fill(table);
                    dataSet.Tables.Add(table);
                }
            }
            catch (Exception ex)
            {
                Debug.LogWarning(ex);
            }
        }


        return dataSet;
    }
}