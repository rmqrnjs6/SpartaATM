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
        Debug.Log("JSON 저장 경로: " + Application.persistentDataPath);
    }

    public void OnSignup()
    {
        Debug.Log("OnSignup 호출");
        string newID = NewIDInput.text.Trim();
        string NewPW = NewPasswordInput.text.Trim();


        if (string.IsNullOrEmpty(newID) || string.IsNullOrEmpty(NewPW))
        {
            SignupErrorText.text = "아이디와 비밀번호를 모두 입력해주세요.";
            return; // text 출력 후 Sign 메뉴로 반환
        }

        UserData User = SaveManager.Load();
        if(User != null)
        {
            SignupErrorText.text = "이미 가입된 사용자 정보가 존재합니다.";
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
        Debug.Log("가입이 완료되었습니다");
        SceneManager.LoadScene("PopupLogin");
    }
}
