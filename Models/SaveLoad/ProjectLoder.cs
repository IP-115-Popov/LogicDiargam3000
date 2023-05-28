using Avalonia.Rendering.SceneGraph;
using LogicDiagram3000.Models.Connectors;
using LogicDiagram3000.Models.logicChip;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LogicDiagram3000.Models.SaveLoad
{
    public class ProjectLoder
    {
        public ObservableCollection<Scheme> Load(string path)
        {
            ObservableCollection<Scheme> ListToLoad;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ShameToSaveLoad>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {               
                List<ShameToSaveLoad> rez = xmlSerializer.Deserialize(fs) as List<ShameToSaveLoad>;
                ListToLoad = Unpacking(rez);
            }
            return ListToLoad;
        }       
        //перебор глобальных схем левых
        private ObservableCollection<Scheme> Unpacking(List<ShameToSaveLoad> shameToSaveLoads)
        {
            ObservableCollection<Scheme> rez= new ObservableCollection<Scheme>();
            foreach(ShameToSaveLoad scheme in shameToSaveLoads)
            {
                //собераем в список все глобальные схемы
                if (scheme.Tupe == "Схема")
                    rez.Add(SchameToChipList(scheme));
            }
            return rez;
        }
        //распаковка схемы
        private Scheme? SchameToChipList(ShameToSaveLoad scheme)
        {
            Scheme rez = new Scheme()
            {
                Id = scheme.Id,
                Margin = scheme.Margin,
                Width = scheme.Width,
                Height = scheme.Height,
            };
            if (scheme.ShameToSaveLoads != null) rez.CanvasList = SchameChipList(scheme.ShameToSaveLoads);
            return rez;
        }
        private ObservableCollection<object> SchameChipList(List<ShameToSaveLoad> shameToSaveLoads)
        {
            ObservableCollection<object> schameChipList = new ObservableCollection<object>();
            foreach(ShameToSaveLoad i in shameToSaveLoads)
            {
                schameChipList.Add(ChipSaveToChip(i));
            }
            return schameChipList;
        }
        private object? ChipSaveToChip(ShameToSaveLoad scheme)
        {
            object rez = null;
            if (scheme.Tupe == "AndChip")
            {
                rez = new AndChip()
                {
                    Id = scheme.Id,
                    Margin = scheme.Margin,
                    Width = scheme.Width,
                    Height = scheme.Height,
                    IdIn1= scheme.IdIn1,
                    IdIn2 = scheme.IdIn2,
                    IdOut1 = scheme.IdOut1,
                    IdOut2 = scheme.IdOut2,
                };
            }
            else if (scheme.Tupe == "DemultiplexerChip")
            {
                rez = new DemultiplexerChip()
                {
                    Id = scheme.Id,
                    Margin = scheme.Margin,
                    Width = scheme.Width,
                    Height = scheme.Height,
                    IdIn1 = scheme.IdIn1,
                    IdIn2 = scheme.IdIn2,
                    IdOut1 = scheme.IdOut1,
                    IdOut2 = scheme.IdOut2,
                };
            }
            else if (scheme.Tupe == "InChip")
            {
                rez = new InChip()
                {
                    Id = scheme.Id,
                    Margin = scheme.Margin,
                    Width = scheme.Width,
                    Height = scheme.Height,
                    IdIn1 = scheme.IdIn1,
                    IdIn2 = scheme.IdIn2,
                    IdOut1 = scheme.IdOut1,
                    IdOut2 = scheme.IdOut2,
                };
            }
            else if (scheme.Tupe == "IndicatorChip")
            {
                rez = new IndicatorChip()
                {
                    Id = scheme.Id,
                    Margin = scheme.Margin,
                    Width = scheme.Width,
                    Height = scheme.Height,
                    IdIn1 = scheme.IdIn1,
                    IdIn2 = scheme.IdIn2,
                    IdOut1 = scheme.IdOut1,
                    IdOut2 = scheme.IdOut2,
                };
            }
            else if (scheme.Tupe == "NotChip")
            {
                rez = new NotChip()
                {
                    Id = scheme.Id,
                    Margin = scheme.Margin,
                    Width = scheme.Width,
                    Height = scheme.Height,
                    IdIn1 = scheme.IdIn1,
                    IdIn2 = scheme.IdIn2,
                    IdOut1 = scheme.IdOut1,
                    IdOut2 = scheme.IdOut2,
                };
            }
            else if (scheme.Tupe == "OrChip")
            {
                rez = new OrChip()
                {
                    Id = scheme.Id,
                    Margin = scheme.Margin,
                    Width = scheme.Width,
                    Height = scheme.Height,
                    IdIn1 = scheme.IdIn1,
                    IdIn2 = scheme.IdIn2,
                    IdOut1 = scheme.IdOut1,
                    IdOut2 = scheme.IdOut2,
                };
            }
            else if (scheme.Tupe == "Схема")
            {
                rez = SchameToChipList(scheme);
            }
            else if (scheme.Tupe == "XorChip")
            {
                rez = new XorChip()
                {
                    Id = scheme.Id,
                    Margin = scheme.Margin,
                    Width = scheme.Width,
                    Height = scheme.Height,
                    IdIn1 = scheme.IdIn1,
                    IdIn2 = scheme.IdIn2,
                    IdOut1 = scheme.IdOut1,
                    IdOut2 = scheme.IdOut2,
                };
            }
            else if (scheme.Tupe == "Connector")
            {
                Connector a = new Connector()
                {
                    Id = scheme.Id,
                    IdIn1 = scheme.IdIn1,
                    IdOut1 = scheme.IdOut1,
                    
                };
                if (scheme.StartPoint != null) a.StartPoint = Avalonia.Point.Parse(scheme.StartPoint);
                if (scheme.StartPoint != null) a.EndPoint = Avalonia.Point.Parse(scheme.StartPoint);
                rez = a;
            }
            return rez;
        }
    }
}
