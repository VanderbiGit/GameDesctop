using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainBatton : MonoBehaviour
{
    public static string nameUser;
    public static int CounterBot = 12;

    [SerializeField]
    Text textEror;

    bool CheakLengName; //1-9
    //зарезирвовані імена ботів
    private string[] namesBot = {"Karl", "Bobi", "Toni", "Cooleyt", "Vivi", "KaSun", "Destroy", "Bugabum", "Horse",
                                 "Fin", "Felt", "Lesi", "Kirk", "Roni", "Karto", "NoName", "Kasi", "Bit", "Alfred",
                                  "Andi", "Ron", "Shrek", "Wendi", "Lara", "Kit", "Imba", "Ysup", "Greak", "Lao", "Rakshata"};

    //кнопка одиночна ігра
    public void SinglePlay()
    {
        if (CheakLengName == true)
        {
            if(false == CheakNameForExisst())
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                textEror.gameObject.SetActive(true);
                textEror.text = "Name is exist";
            }
        }
        else
        {
            textEror.gameObject.SetActive(true);
            textEror.text = "Name must be 1-9later";
        }
        
    }

    //Вихід
    public void ExitGame()
    {
        Application.Quit();
    }

    //Перевіряєм довжину імя
    public void CheakName(string name)
    {
        if (name == string.Empty || name.Length > 9)
            CheakLengName = false;
        else
            CheakLengName = true;

        nameUser = name;

    }

    //перевірям чи є таке імя
    public bool CheakNameForExisst()
    {
        foreach(string item in namesBot)
            if (item == nameUser)
                return true;

        return false;

    }

    //Слайдер ботів
    public void CountersBot(float count)
    {
        if ((int)count % 3 == 0)
        {
            CounterBot = (int)count;
            textEror.text = "Counter Bots : " + CounterBot.ToString();
        }
    }


}
