using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicDiagram3000.Models.SaveLoad
{
    public class LoadListProject
    {
        public static List<string> load()
        {
            List<string> rez = null;
            using (StreamReader file = new StreamReader("ListProject.json"))
            {
                rez = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(file.ReadToEnd());
                bool flag = false;
                while (rez != null) 
                {
                    foreach (string path in rez)
                    {
                        if (!File.Exists(path))
                        {
                            rez.Remove(path);
                            break;
                        }
                        if (path == rez[rez.Count - 1])
                            flag = true;
                    }
                    if (flag) break;
                }               
            }
            if (rez != null)
            {
                return rez;
            }
            else return new List<string>();
        }
    }
}
