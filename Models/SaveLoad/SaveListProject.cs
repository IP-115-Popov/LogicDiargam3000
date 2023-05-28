using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicDiagram3000.Models.SaveLoad;

namespace LogicDiagram3000.Models.SaveLoad
{
    public class SaveListProject
    {
        public static void Save(string path)
        {
            List<string> list = LoadListProject.load();
            list.Add(path);
            string? jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            if (jsonData != null)
            {
                using (StreamWriter file = new StreamWriter("ListProject.json", false))
                {
                    file.Write(jsonData);
                }
            }
        }
    }
}
