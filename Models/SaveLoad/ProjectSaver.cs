using LogicDiagram3000.Models.logicChip;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using LogicDiagram3000.Models.SaveLoad;
using LogicDiagram3000.Models.Connectors;
using DynamicData;

namespace LogicDiagram3000.Models.SaveLoad
{
    public class ProjectSaver
    {
        //private List<ShameToSaveLoad> shameToSaveLoads = new List<ShameToSaveLoad>();
        public void Save(string path, ObservableCollection<Scheme> ListToSave)
        {
            List<ShameToSaveLoad> shameToSaveLoads = new List<ShameToSaveLoad>();
            foreach (Scheme scheme in ListToSave)
            {
                ShameToSaveLoad seveSchame = new ShameToSaveLoad()
                {
                    Id = scheme.Id,
                    Tupe = scheme.TupeChip,
                    Margin = scheme.Margin,
                    Width = scheme.Width,
                    Height = scheme.Height,
                };
                seveSchame.ShameToSaveLoads = ToShameToSaveLoads(scheme);

                shameToSaveLoads.Add(seveSchame);
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ShameToSaveLoad>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, shameToSaveLoads);
            }
        }
        private List<ShameToSaveLoad> ToShameToSaveLoads(Scheme scheme)
        {
            List<ShameToSaveLoad> rez = new List<ShameToSaveLoad>();

            foreach (object chip in scheme.CanvasList)
            {
                if (chip is AndChip andChip)
                {
                    ShameToSaveLoad seveSchame = new ShameToSaveLoad()
                    {
                        Id = andChip.Id,
                        Tupe = andChip.TupeChip,
                        Margin = andChip.Margin,
                        Width = andChip.Width,
                        Height = andChip.Height,
                    };
                    if (andChip.TiedToIn1Chip != null) seveSchame.IdIn1 = andChip.TiedToIn1Chip.Id;
                    if (andChip.TiedToOut1Chip != null) seveSchame.IdOut1 = andChip.TiedToOut1Chip.Id;
                    if (andChip.TiedToIn2Chip != null) seveSchame.IdIn2 = andChip.TiedToIn2Chip.Id;
                    rez.Add(seveSchame);
                }
                else if (chip is InChip inChip)
                {
                    ShameToSaveLoad seveSchame = new ShameToSaveLoad()
                    {
                        Id = inChip.Id,
                        Tupe = inChip.TupeChip,
                        Margin = inChip.Margin,
                        Width = inChip.Width,
                        Height = inChip.Height,
                    };
                    if (inChip.TiedToIn1Chip != null) seveSchame.IdIn1 = inChip.TiedToIn1Chip.Id;
                    if (inChip.TiedToOut1Chip != null) seveSchame.IdOut1 = inChip.TiedToOut1Chip.Id;
                    if (inChip.TiedToIn2Chip != null) seveSchame.IdIn2 = inChip.TiedToIn2Chip.Id;
                    rez.Add(seveSchame);
                }
                else if (chip is IndicatorChip indicatorChip)
                {
                    ShameToSaveLoad seveSchame = new ShameToSaveLoad()
                    {
                        Id = indicatorChip.Id,
                        Tupe = indicatorChip.TupeChip,
                        Margin = indicatorChip.Margin,
                        Width = indicatorChip.Width,
                        Height = indicatorChip.Height,
                    };                     
                    if (indicatorChip.TiedToIn1Chip != null) seveSchame.IdIn1 = indicatorChip.TiedToIn1Chip.Id;
                    if (indicatorChip.TiedToOut1Chip != null) seveSchame.IdOut1 = indicatorChip.TiedToOut1Chip.Id;
                    if (indicatorChip.TiedToIn2Chip != null) seveSchame.IdIn2 = indicatorChip.TiedToIn2Chip.Id;
                    rez.Add(seveSchame);
                }
                else if (chip is NotChip notChip)
                {
                    ShameToSaveLoad seveSchame = new ShameToSaveLoad()
                    {
                        Id = notChip.Id,
                        Tupe = notChip.TupeChip,
                        Margin = notChip.Margin,
                        Width = notChip.Width,
                        Height = notChip.Height,
                    };
                    if (notChip.TiedToIn1Chip != null) seveSchame.IdIn1 = notChip.TiedToIn1Chip.Id;
                    if (notChip.TiedToOut1Chip != null) seveSchame.IdOut1 = notChip.TiedToOut1Chip.Id;
                    if (notChip.TiedToIn2Chip != null) seveSchame.IdIn2 = notChip.TiedToIn2Chip.Id;
                    rez.Add(seveSchame);
                }
                else if (chip is OrChip orChip)
                {
                    ShameToSaveLoad seveSchame = new ShameToSaveLoad()
                    {
                        Id = orChip.Id,
                        Tupe = orChip.TupeChip,
                        Margin = orChip.Margin,
                        Width = orChip.Width,
                        Height = orChip.Height,
                    };
                    if (orChip.TiedToIn1Chip != null) seveSchame.IdIn1 = orChip.TiedToIn1Chip.Id;
                    if (orChip.TiedToOut1Chip != null) seveSchame.IdOut1 = orChip.TiedToOut1Chip.Id;
                    if (orChip.TiedToIn2Chip != null) seveSchame.IdIn2 = orChip.TiedToIn2Chip.Id;
                    rez.Add(seveSchame);
                }
                else if (chip is XorChip xorChip)
                {
                    ShameToSaveLoad seveSchame = new ShameToSaveLoad()
                    {
                        Id = xorChip.Id,
                        Tupe = xorChip.TupeChip,
                        Margin = xorChip.Margin,
                        Width = xorChip.Width,
                        Height = xorChip.Height,
                    };
                    if (xorChip.TiedToIn1Chip != null) seveSchame.IdIn1 = xorChip.TiedToIn1Chip.Id;
                    if (xorChip.TiedToOut1Chip != null) seveSchame.IdOut1 = xorChip.TiedToOut1Chip.Id;
                    if (xorChip.TiedToIn2Chip != null) seveSchame.IdIn2 = xorChip.TiedToIn2Chip.Id;
                    rez.Add(seveSchame);
                }
                else if (chip is Connector connector)
                {
                    ShameToSaveLoad seveSchame = new ShameToSaveLoad()
                    {
                        Id = connector.Id,
                        Tupe = connector.TupeChip,
                        StartPoint = (connector.StartPoint).ToString(),
                        EndPoint = (connector.EndPoint).ToString(),
                    };
                    if (connector.TiedToIn1Chip != null) seveSchame.IdIn1 = connector.TiedToIn1Chip.Id;
                    if (connector.TiedToOut1Chip != null) seveSchame.IdOut1 = connector.TiedToOut1Chip.Id;
                    rez.Add(seveSchame);
                }
                else if (chip is DemultiplexerChip demultiplexerChip)
                {
                    ShameToSaveLoad seveSchame = new ShameToSaveLoad()
                    {
                        Id = demultiplexerChip.Id,
                        Tupe = demultiplexerChip.TupeChip,
                        Margin = demultiplexerChip.Margin,
                        Width = demultiplexerChip.Width,
                        Height = demultiplexerChip.Height,
                    };
                    if (demultiplexerChip.TiedToIn1Chip != null) seveSchame.IdIn1 = demultiplexerChip.TiedToIn1Chip.Id;
                    if (demultiplexerChip.TiedToOut1Chip != null) seveSchame.IdOut1 = demultiplexerChip.TiedToOut1Chip.Id;
                    if (demultiplexerChip.TiedToIn2Chip != null) seveSchame.IdIn2 = demultiplexerChip.TiedToIn2Chip.Id;
                    if (demultiplexerChip.TiedToOut2Chip != null) seveSchame.IdOut2 = demultiplexerChip.TiedToOut2Chip.Id;
                    rez.Add(seveSchame);
                }
                else if (chip is Scheme internalScheme)
                {
                    ShameToSaveLoad seveSchame = new ShameToSaveLoad()
                    {
                        Id = internalScheme.Id,
                        Tupe = internalScheme.TupeChip,
                        Margin = internalScheme.Margin,
                        Width = internalScheme.Width,
                        Height = internalScheme.Height,
                    };
                    seveSchame.ShameToSaveLoads = ToShameToSaveLoads(internalScheme);
                    rez.Add(seveSchame);
                }
            }
            return rez;
        }
    }
}
