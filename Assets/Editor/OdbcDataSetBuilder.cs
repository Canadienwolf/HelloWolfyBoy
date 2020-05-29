using System;
using System.Data;
using System.Data.Odbc;
using UnityEngine;

public class OdbcDataSetBuilder : IDataSetBuilder
{
    private string connectionString;

    public OdbcDataSetBuilder(string databaseFileAbsoluteLocation)
    {
        connectionString = "Driver={Microsoft Access Driver (*.mdb, *.accdb)};Dbq=" + databaseFileAbsoluteLocation +
                           ";";
    }

    public DataSet BuildDataSet()
    {
        DataSet dataSet = new DataSet();


        using (OdbcConnection connection = new OdbcConnection(connectionString))
        {
            OdbcDataAdapter adapter = new OdbcDataAdapter();

            // Open the connection and fill the DataSet.
            try
            {
                connection.Open();
                var tables = connection.GetSchema("Tables");
                foreach (DataRow row in tables.Rows)
                {
                    adapter.SelectCommand.Connection = connection;
                    adapter.SelectCommand.CommandText = $"SELECT * FROM {row[2].ToString()}";
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataSet.Tables.Add(table);
                }
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
            }
        }

        foreach (DataTable dataSetTable in dataSet.Tables)
        {
            Debug.Log(dataSetTable.TableName);
        }

        return dataSet;
    }
}