using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static string FilePath => Path.Combine(Application.persistentDataPath, "userdata.json");
    public static void Save(UserData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(FilePath, json);
        Debug.Log("���� �Ϸ�");
    }

    public static UserData Load()
    {
        string path = FilePath;

        if (!File.Exists(FilePath))
        {
            Debug.LogWarning("����� ������ �����ϴ�.");
            return null;
        }
        try
        {
            string json = File.ReadAllText(path);
            UserData loaded = JsonUtility.FromJson<UserData>(json);
            Debug.Log("�ε� �Ϸ�: " + json);
            return loaded;
        }
        catch (System.Exception e)
        {
            Debug.LogError("�ε� �� ���� �߻�: " + e.Message);
            return null;
        }
    }
}
