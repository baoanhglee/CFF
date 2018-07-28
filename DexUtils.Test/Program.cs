using Cyberdex.DexUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DexUtils.Test
{
    class Program
    {
        static void WriteLog(StreamWriter sw, string content="")
        {
            Console.WriteLine(content);
            sw.WriteLine(content);
        }
        static void Main(string[] args)
        {
            StreamWriter FileLog = new StreamWriter(@"TestApiList.log", false);
            foreach (PropertyInfo prop in typeof(UriInfo).GetProperties())
            {
                WriteLog(FileLog);
                WriteLog(FileLog,$"TEST API [{prop.Name}] START: ");
                try
                {
                    string url = prop.GetValue(PokeApi.ApiUri).ToString();
                    WriteLog(FileLog,$"Requesting to {url}");
                    var result = PokeApi.Call_GetList(requestUrl:url, limit:3);
                    WriteLog(FileLog,$"Response:");
                    #region
                    WriteLog(FileLog,$"\tCount:\t{result.Count}");
                    WriteLog(FileLog,$"\tNext:\t{result.Next}");
                    WriteLog(FileLog,$"\tPrev:\t{result.Previous}");
                    WriteLog(FileLog,$"\tResult:");
                    foreach (var item in result.Results)
                    {
                        WriteLog(FileLog,$"\t\tName:{item.Name}");
                        WriteLog(FileLog,$"\t\tUrl:{item.Url}");
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    WriteLog(FileLog,$"ERROR: {ex.Message}");
                }

                WriteLog(FileLog,$"TEST API [{prop.Name}] END.");
                WriteLog(FileLog);
            }
            FileLog.Close();
        }
    }
}
