﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameSaveManager : MonoBehaviour
{

    public List<ScriptableObject> objects = new List<ScriptableObject>();


    public void ResetScriptables()
    {
        for(int i = 0; i < objects.Count; i++)
        {
            if(File.Exists(Application.persistentDataPath + $"/{i}"))
            {
                File.Delete(Application.persistentDataPath + $"/{i}");
            }
        }
    }

    private void OnEnable()
    {
        LoadScriptables();
    }

    private void OnDisable()
    {
        SaveScriptables();
    }

    public void SaveScriptables()
    {
        for(int i = 0; i < objects.Count; i ++)
        {
            FileStream file = File.Create(Application.persistentDataPath + 
                $"/{i}");
            BinaryFormatter binary = new BinaryFormatter();
            var json = JsonUtility.ToJson(objects[i]);
            binary.Serialize(file, json);
            file.Close();
        }
    }

    public void LoadScriptables()
    {
        for(int i = 0; i < objects.Count; i ++)
        {
            if(File.Exists(Application.persistentDataPath + 
                $"/{i}"))
            {
                FileStream file = File.Open(Application.persistentDataPath + 
                $"/{i}", FileMode.Open);
                BinaryFormatter binary = new BinaryFormatter();
                JsonUtility.FromJsonOverwrite((string)binary.Deserialize(file), objects[i]);
                file.Close();
            }
        }
    }

}
