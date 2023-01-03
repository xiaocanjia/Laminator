using System;
using System.Collections.Generic;
using System.IO;
using DataLogging;

namespace MeasResult
{
    public class ResultsLogger
    {
        public static string SaveResult(string rootDir, string code, List<MesResult> resList)
        {
            try
            {
                string header = "Code\t";
                string data = code + "\t";
                int failCount = 0;
                foreach (MesResult result in resList)
                {
                    if (!result.IsOutput)
                        continue;
                    header += result.ID + "\t";
                    data += result.Value.ToString() + "\t";
                    if (result.Decision == Decision.FAIL)
                        failCount++;
                }
                if (!Directory.Exists(rootDir))
                    Directory.CreateDirectory(rootDir);
                string dataDir = rootDir + $"\\{DateTime.Now.ToString("yyyy-MM-dd")}";
                if (!Directory.Exists(dataDir))
                    Directory.CreateDirectory(dataDir);
                string decision = "";
                if (failCount > 0)
                    decision = "FAIL";
                else
                    decision = "PASS";
                DataLogger.Data_Written_To_Csv($"{dataDir}\\{decision}.csv", header, data);
                return decision;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
