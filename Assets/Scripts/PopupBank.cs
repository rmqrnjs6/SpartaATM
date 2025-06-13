using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    public GameObject CurrentMenu;
    public GameObject DespositPanel;
    public GameObject WithDrawPanel;

    public TMP_InputField MoneyInput;

    public void ShowMenu(GameObject Panel)
    {
        CurrentMenu.SetActive(false);
        Panel.SetActive(true);
    }

    public void BackToMain(GameObject CurrentPanel) 
    {
        CurrentPanel.SetActive(false);
        CurrentMenu.SetActive(true);
    }

    public void Deposit(int Money)
    {
        var data = GameManager.Instance.userData;

        if (data.Cash <= 0)
        {
            Debug.LogError("잔액이 부족합니다.");
            return;
        }

        data.Balance += Money;
            data.Cash -= Money;
        
        GameManager.Instance.Refresh();
        SaveManager.Save(data);
    }

    public void DepositFromInput()
    {
        var data = GameManager.Instance.userData;

        if (int.TryParse(MoneyInput.text, out int amount))
        {
            if (amount <= 0)
            {
                Debug.LogWarning("입금 금액은 0보다 커야 합니다.");
                return;
            }
            if (data.Cash <= 0)
            {
                Debug.LogError("잔액이 부족합니다.");
                return;
            }

            data.Cash -= amount;
            data.Balance += amount;

            GameManager.Instance.Refresh();
            MoneyInput.text = "";
            SaveManager.Save(data);
        }
        else
        {
            Debug.LogWarning("유효한 숫자가 아닙니다.");
        }
    }
    public void Withdraw(int Money)
    {
        var data = GameManager.Instance.userData;

        if (data.Balance <= 0)
        {
            Debug.LogError("잔액이 부족합니다.");
            return;
        }

        data.Cash += Money;
        data.Balance -= Money;

        GameManager.Instance.Refresh();
        SaveManager.Save(data);
    }
    public void WithdrawFromInput()
    {
        var data = GameManager.Instance.userData;

        if (int.TryParse(MoneyInput.text, out int amount))
        {
            if (amount <= 0)
            {
                Debug.LogWarning("출금 금액은 0보다 커야 합니다.");
                return;
            }
            if (data.Balance <= 0)
            {
                Debug.LogError("잔액이 부족합니다.");
                return;
            }
            data.Cash += amount;
            data.Balance -= amount;

            GameManager.Instance.Refresh();
            MoneyInput.text = "";
            SaveManager.Save(data);
        }
        else
        {
            Debug.LogWarning("유효한 숫자가 아닙니다.");
        }
    }
}
