using UnityEngine;
using System.IO;

    public class JsonData
    {
        public void Write<T>(T data, string path)
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(path, json);
        }

        public T Read<T>(string path)
        {
            T data = default;
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                data = JsonUtility.FromJson<T>(json);
            }
            return data;
        }
    }