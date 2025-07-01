using System;
using System.Collections.Generic;
using System.IO;

namespace CarConnectApp.Util
{
    public class DBPropertyUtil
    {
        public static Dictionary<string, string> GetProperties(string filePath)
        {
            var properties = new Dictionary<string, string>();

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Property file not found: " + filePath);

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    var parts = line.Split('=', 2);
                    properties[parts[0].Trim()] = parts[1].Trim();
                }
            }

            return properties;
        }
    }
}
