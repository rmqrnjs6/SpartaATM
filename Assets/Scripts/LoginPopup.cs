using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginPopup : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField IDInput;
    public TMP_InputField PasswordInput;

    public TMP_Text ErrorText;

    private const string USER_FILE_NAME = "userdata.json";

    private void Start()
    {
        if (ErrorText != null)
        {
            ErrorText.text = "";
        }
    }

    public void LoginFromInput()
    {
        string inputID = IDInput.text.Trim();
        string inputPW = PasswordInput.text.Trim();

        if (string.IsNullOrEmpty(inputID) || string.IsNullOrEmpty(inputPW))
        {
            ShowError("���̵�� ��й�ȣ�� ��� �Է����ּ���.");
            return;
        }

        UserData savedUser = SaveManager.Load();

        if (savedUser == null)
        {
            ShowError("��ϵ� ����� ������ �����ϴ�. ���� ȸ�������� ���ּ���.");
            return;
        }


        if (inputID == savedUser.ID && inputPW == savedUser.Passward)
        {
            ClearError();


            GameManager.Instance.userData = savedUser;
            GameManager.Instance.Refresh();

            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            ShowError("���̵� �Ǵ� ��й�ȣ�� ��ġ���� �ʽ��ϴ�.");
            IDInput.text = "";
            PasswordInput.text = "";
        }
    }

    public void OnSignUp()
    {
        SceneManager.LoadScene("PopupSignUp");
    }

    private void ShowError(string message)
    {
        if (ErrorText != null)
        ErrorText.text = message;
    }


    private void ClearError()
    {
        if (ErrorText != null) 
        ErrorText.text = "";
    }
}
