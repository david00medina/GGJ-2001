using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace System
{
    public static class Game
    {
        public static void SaveGame(GameObject player)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "saves.dat";
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(player);
            
            formatter.Serialize(stream, data);
            stream.Close();
            
            Debug.Log("Game saved at " + path);
        }

        public static PlayerData LoadGame()
        {
            string path = Application.persistentDataPath + "saves.dat";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
                
                return data;
            }
            else
            {
                Debug.LogError("Save file not found in " + path);
                return null;
            }
        }
    }
}