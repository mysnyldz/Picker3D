using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private int _level = 1;

    private void Awake()
    {
    }
    private void Start()
    {
        GameManager.instance.LoadSave();
        GameManager.instance.Lvlup += _instance_Lvlup;
        GameManager.instance.GameStart += _instance_GameStart;
    }
    private void _instance_GameStart(object sender, EventArgs e)
    {
        Load();
        GameManager.instance.SetLvl(_level);
    }
    private void _instance_Lvlup(object sender, EventArgs e)
    {
        _level = GameManager.instance.GetLvl();
        Save();
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/playerData.dat";
        if (File.Exists(path))
        {
            Debug.Log("Loadland�");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            PlayerData_Storage data = bf.Deserialize(file) as PlayerData_Storage;
            _level = data.Level;
            file.Close();
        }
        else
        {
            Debug.LogError("Loadalanamad� ��nk� Save yok" + path);
        }
    }
    public void Save()
    {   
        
        string path = Application.persistentDataPath + "/playerData.dat";
       
            Debug.Log("Savelendi");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(path);
            PlayerData_Storage data = new PlayerData_Storage();
            data.Level = _level;
            bf.Serialize(file, data);
            file.Close();
        
        
        
        //FileStream file = File.Create(path);
        

        
        
    }
    private void OnDestroy()
    {
        GameManager.instance.Lvlup -= _instance_Lvlup;
        GameManager.instance.GameStart -= _instance_GameStart;
    }
}

[Serializable]
class PlayerData_Storage
{

    public int Level;

}
