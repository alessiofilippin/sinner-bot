using Discord;
using Newtonsoft.Json;
using SinnerBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SinnerBot.Controllers
{
    public static class JsonSerializerController
    {
        private static string path = AppDomain.CurrentDomain.BaseDirectory + @"\" + "instancesData.json";
        public static bool WriteDataForServer(InstanceDetails _data)
        {
            CleanFile();
            try
            {
                string json = "";
                bool isServerFound = false;

                if (File.Exists(path))
                {
                    //Append
                    List<Instance> items = JsonConvert.DeserializeObject<List<Instance>>(File.ReadAllText(path));

                    foreach (Instance item in items)
                    {
                        InstanceDetails instanceDetails = item.instance;
                        if (instanceDetails.serverID.Equals(_data.serverID))
                        {                            
                            instanceDetails.serverID = _data.serverID;

                            if(_data.availableMajorArcana != null)
                                instanceDetails.availableMajorArcana = _data.availableMajorArcana;

                            if (_data.availableMinorArcana != null)
                                instanceDetails.availableMinorArcana = _data.availableMinorArcana;

                            isServerFound = true;
                        }
                    }

                    if (!isServerFound)
                    {
                        items.Add(new Instance(_data));
                    }

                    json = System.Text.Json.JsonSerializer.Serialize(items);
                }
                else
                {
                    // Create new
                    List<Instance> data = new List<Instance>();
                    data.Add(new Instance(_data));
                    json = System.Text.Json.JsonSerializer.Serialize(data);
                }

                File.WriteAllText(path, json);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static InstanceDetails ReadDataForServer(string _serverID)
        {
            CleanFile();
            if (!File.Exists(path))
                return null;

            List<Instance> items = JsonConvert.DeserializeObject<List<Instance>>(File.ReadAllText(path));

            foreach (Instance item in items)
            {
                InstanceDetails instanceDetails = item.instance;
                if (instanceDetails.serverID.Equals(_serverID))
                {
                    return instanceDetails;
                }
            }

            return null;
        }

        // Delete the instance file if the bot wasn't used in the last 2hours. This is needed to save space on disk.
        private static void CleanFile()
        {
            if(File.Exists(path))
            {
               DateTime lastWrite = File.GetLastWriteTime(path);

                if(lastWrite > DateTime.Now.AddHours(-2))
                {
                    File.Delete(path);
                }
            }
        }
    }
}
