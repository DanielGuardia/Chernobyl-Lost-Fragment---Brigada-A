using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class GameSaveLoad
{
    public static void Save(int nPartida, Jugador player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/juego" + nPartida + ".chernobyl";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static GameData Load(int nPartida)
    {
        string path = Application.persistentDataPath + "/juego" + nPartida + ".chernobyl";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Archivo guardado no fue encontrado en " + path);
            return null;
        }
    }    
}
