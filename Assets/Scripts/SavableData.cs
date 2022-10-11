using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public abstract class SavableData
{
    public SavableData(string fileName)
    {
        path = Application.persistentDataPath + "/" + fileName + ".json";
    }

    protected string path;
    protected JsonData jsonData = new JsonData();
  
    public virtual event UnityAction LoadingSuccessful;

    public void Save() => jsonData.Write(this, path);

    protected void ConfirmDataAvailability() => LoadingSuccessful?.Invoke();
}