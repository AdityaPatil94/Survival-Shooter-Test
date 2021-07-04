using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Nightmare
{
    public static class SaveSystem
    {
        static string Path = Application.persistentDataPath + "/player.save";
        static PlayerData playerData;
        public static void SavePlayer(Player playerDetails)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(Path, FileMode.Create);
            playerData = new PlayerData(playerDetails);

            formatter.Serialize(stream,playerData);
            stream.Close();
        }

        public static PlayerData LoadPlayer()
        {
            if (File.Exists(Path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(Path, FileMode.Open);

                playerData =  formatter.Deserialize(stream) as PlayerData;
                stream.Close();
                return playerData;
            }
            else
            {
                Debug.LogError("File not found");
                return null;
            }
        }

    }

}
