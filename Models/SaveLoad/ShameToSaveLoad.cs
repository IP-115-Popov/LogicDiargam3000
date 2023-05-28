using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicDiagram3000.Models.SaveLoad
{
    [Serializable]
    public class ShameToSaveLoad
    {
        public int Id { get; set; }
        public string Tupe { get; set; }
        public string Margin { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int IdIn1 { get; set; }
        public int IdOut1 { get; set; }
        public int IdIn2 { get; set; }
        public int IdOut2 { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public List<ShameToSaveLoad> ShameToSaveLoads { get; set; }
    }
}
