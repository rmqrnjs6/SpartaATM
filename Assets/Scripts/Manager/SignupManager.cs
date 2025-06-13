using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SignupManager : MonoBehaviour
{
    public TMP_InputField NewIDInput;
    public TMP_InputField NewPasswordInput;

    public TMP_Text SignupErrorText;

    private const string USER_FILE_NAME = "userdata.json";

    void Start()
    {
        if(SignupErrorText != null)
        {
            SignupErrorText.text = "";
        }
        Debug.Log("JSON ���� ���: " + Application.persistentDataPath);
    }

    public void OnSignup()
    {
        Debug.Log("OnSignup ȣ��");
        string newID = NewIDInput.text.Trim();
        string NewPW = NewPasswordInput.text.Trim();


        if (string.IsNullOrEmpty(newID) || string.IsNullOrEmpty(NewPW))
        {
            SignupErrorText.text = "���̵�� ��й�ȣ�� ��� �Է����ּ���.";
            return; // text ��� �� Sign �޴��� ��ȯ
        }

        UserData User = SaveManager.Load();
        if(User != null)
        {
            SignupErrorText.text = "�̹� ���Ե� ����� ������ �����մϴ�.";
            return;
        }


        UserData newUser = new UserData(
            name: newID,
            balance: 50000,
            cash: 100000,
            iD: newID,
            passward: NewPW
            );


        SaveManager.Save(newUser);
        Debug.Log("������ �Ϸ�Ǿ����ϴ�");
        SceneManager.LoadScene("PopupLogin");
    }
}
