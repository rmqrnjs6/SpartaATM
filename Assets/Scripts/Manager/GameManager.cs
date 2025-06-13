using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

[Serializable]
public class UserData
{
    public string Name = "±Ç±â¿ø";
    public int Balance = 50000;
    public int Cash = 100000;

    public string ID = "rldnjsdlel";
    public string Passward = "lol0507@*!^";

    public UserData(string name, int balance, int cash, string iD, string passward)
    {
        Name = name;
        Balance = balance;
        Cash = cash;
        ID = iD;
        Passward = passward;
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public UserData userData;

    [Header("UI References")]
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI BalanceText;
    public TextMeshProUGUI CashText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        userData = SaveManager.Load();
        Refresh();
    }

    public void Refresh()
    {
        NameText.text = userData.Name;
        BalanceText.text = string.Format("{0:N0}", userData.Balance);
        CashText.text = string.Format("{0:N0}", userData.Cash);
    }
}
