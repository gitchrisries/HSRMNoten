using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace HSRMNoten.Classes
{
    public class UserDataIO
    {
        static string path = Environment.CurrentDirectory + "\\userdata.txt";

        public static void appendUserData(string[] data)
        {
            using (StreamWriter sr = File.AppendText(path))
            {
                for (int i = 0; i < data.Length; i++)
                {
                    sr.WriteLine(data[i]);
                }
            }
        }

        public static void writeNewUserData(string[] data)
        {
            using (StreamWriter sr = new StreamWriter(path))
            {
                for (int i = 0; i < data.Length; i++)
                {
                    sr.WriteLine(data[i]);
                }
            }
        }

        public static Dictionary<string,string> readUserData()
        {
            var map = new Dictionary<string,string>();
            
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var split = line.Split(':');
                    map.Add(split[0], split[1]);
                }
            }
            return map;
        }

        public static void updateUserData(string[] data)
        {
            string[] config = File.ReadAllLines(path);
            for (int i = 0; i < config.Length; i++)
            {
                for (int j = 0; j < data.Length; j++)
                {
                    if (config[i].Substring(0, config[i].IndexOf(':')).Equals(data[j].Substring(0, data[j].IndexOf(':')))){
                        config[i] = data[j];
                    }
                }
            }
            using (StreamWriter sr = new StreamWriter(path))
            {
                for (int i = 0; i < config.Length; i++)
                {
                    sr.WriteLine(config[i]);
                }
            }
        }

    }
}
