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
        Debug.Log("저장 완료");
    }

    public static UserData Load()
    {
        string path = FilePath;

        if (!File.Exists(FilePath))
        {
            Debug.LogWarning("저장된 파일이 없습니다.");
            return null;
        }
        try
        {
            string json = File.ReadAllText(path);
            UserData loaded = JsonUtility.FromJson<UserData>(json);
            Debug.Log("로드 완료: " + json);
            return loaded;
        }
        catch (System.Exception e)
        {
            Debug.LogError("로드 중 오류 발생: " + e.Message);
            return null;
        }
    }
}
