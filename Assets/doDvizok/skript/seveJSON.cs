using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class seveJSON : MonoBehaviour
{
    private bool sevesss = false;
    public static seves sevess = new seves();
    private string path;

    void StartSeve()
    {
#if !UNITY_EDITOR && UNITY_ANDROID
        path = Path.Combine(Application.persistentDataPath, "seve.json");
#else
        path = Path.Combine(Application.dataPath, "doDvizok/seve.json");
#endif
        if (File.Exists(path))
        {
            sevess = JsonUtility.FromJson<seves>(File.ReadAllText(path));
        }
        sevesss = true;
    }

    void Seve()
    {
        File.WriteAllText(path, JsonUtility.ToJson(sevess));
    }

#if !UNITY_EDITOR && UNITY_ANDROID
    private void OnApplicationPause(bool pause)
    {
        if(sevesss)
        if (pause) File.WriteAllText(path, JsonUtility.ToJson(seves));
    }
#endif
    private void OnApplicationQuit()
    {
        if(sevesss)
        File.WriteAllText(path, JsonUtility.ToJson(sevess));
    }

    public void seve()
    {
        if (sevesss)
            File.WriteAllText(path, JsonUtility.ToJson(sevess));
    }

}

[Serializable]
public class seves
{
    public int neremenix=0;
    public Dictionary<string, int> peremeniInt = new Dictionary<string, int>();
    public Dictionary<string, float> peremeniFloat = new Dictionary<string, float>();
    public Dictionary<string, string> peremeniString = new Dictionary<string, string>();
    public Dictionary<string, bool> peremeniBool = new Dictionary<string, bool>();

    public void NewAddMas(List<string> key, List<string> valu)
    {if (key.Count != valu.Count) { Debug.LogError($"������ ���������� ��������� {key.Count} {valu.Count}"); return; } neremenix += valu.Count; for (int i = 0; i < valu.Count; i++) peremeniString.Add(key[i], valu[i]);}
    public void NewAddMas(List<string> key, List<float> valu)
    {if (key.Count != valu.Count) { Debug.LogError($"������ ���������� ��������� {key.Count} {valu.Count}"); return; } neremenix += valu.Count; for (int i = 0; i < valu.Count; i++) peremeniFloat.Add(key[i], valu[i]);}
    public void NewAddMas(List<string> key, List<int> valu)
    {if (key.Count != valu.Count) { Debug.LogError($"������ ���������� ��������� {key.Count} {valu.Count}"); return; } neremenix += valu.Count; for (int i = 0; i < valu.Count; i++) peremeniInt.Add(key[i], valu[i]);}
    public void NewAddMas(List<string> key, List<bool> valu)
    {if (key.Count != valu.Count) { Debug.LogError($"������ ���������� ��������� {key.Count} {valu.Count}"); return; } neremenix += valu.Count; for (int i = 0; i < valu.Count; i++) peremeniBool.Add(key[i], valu[i]);}

    public void Add(string key, string valu)
    {peremeniString.Add(key, valu); neremenix++; }
    public void Add(string key, int valu)
    { peremeniInt.Add(key, valu); neremenix++; }
    public void Add(string key, float valu)
    { peremeniFloat.Add(key, valu); neremenix++; }
    public void Add(string key, bool valu)
    { peremeniBool.Add(key, valu); neremenix++; }

    public object vzat(string neim)
    {
        foreach (var p in peremeniInt)if (p.Key == neim) return p.Value;
        foreach (var p in peremeniFloat) if (p.Key == neim) return p.Value; 
        foreach (var p in peremeniString) if (p.Key == neim) return p.Value; 
        foreach (var p in peremeniBool) if (p.Key == neim) return p.Value;
        return null;
    }

    public String vzat(string neim, String i)
    { return peremeniString[neim]; }
    public int vzat(string neim, int i)
    { return peremeniInt[neim]; }
    public float vzat(string neim, float i)
    { return peremeniFloat[neim]; }
    public bool vzat(string neim, bool i)
    { return peremeniBool[neim]; }
    public string vzatString(string neim)
    { return peremeniString[neim]; }
    public int vzatInt(string neim)
    { return peremeniInt[neim]; }
    public float vzatFloat(string neim)
    { return peremeniFloat[neim]; }
    public bool vzatBool(string neim)
    { return peremeniBool[neim]; }

    public void vstavit(string neim, string i)
    { peremeniString[neim] = i; }
    public void vstavit(string neim, int i)
    { peremeniInt[neim] = i; }
    public void vstavit(string neim, float i)
    { peremeniFloat[neim] = i; }
    public void vstavit(string neim, bool i)
    { peremeniBool[neim] = i; }



}

[Serializable]
public class golosSeve
{
    public float tember;
}
