using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class Save //allows the methods to be called from anywhere in the game
{
    static string filePath = "/Player.data";

    public static void savePlayer(PlayerController player) //Save the player's data
    {
        BinaryFormatter formatter = new BinaryFormatter(); //Create a new binary formatter that makes the players data unreadable
        string path = Application.persistentDataPath + filePath; //get the persistent path to store the data file.
        FileStream stream = new FileStream(path, FileMode.Create);
        savePlayer data = new savePlayer(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static savePlayer loadPlayer()
    {
        string path = Application.persistentDataPath + filePath; //check if theres a file in the path 
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open); //open the file

            savePlayer data = (savePlayer)formatter.Deserialize(stream); //unencrypt the file
            stream.Close();

            return data; //send the data back to the method
        }
        else
        {
            savePlayer data = new savePlayer();//create a new player if no file is found
            return data;
        }
    }
}
