using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BIC.Handler;

/// <summary>
/// Summary description for ConnectStr
/// </summary>
public class ConnectStr
{
    public ConnectStr()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static SqlConnection getConnect()
    {
        SqlConnection cn = null;
        try
        {
            string str = ConfigurationManager.AppSettings.Get("advWebsite");
            cn = new SqlConnection(str);
            cn.Open();
        }
        catch(System.Exception ex)
        {
            LogEvent.LogToEvent(ex.ToString());
            cn.Close();
        }
        finally
        {
        }
        return cn;
    }
}