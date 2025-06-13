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
            ShowError("아이디와 비밀번호를 모두 입력해주세요.");
            return;
        }

        UserData savedUser = SaveManager.Load();

        if (savedUser == null)
        {
            ShowError("등록된 사용자 정보가 없습니다. 먼저 회원가입을 해주세요.");
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
            ShowError("아이디 또는 비밀번호가 일치하지 않습니다.");
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
