using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

public class CheakBots : MonoBehaviour {

    [SerializeField]
    GameObject Ice;

    [SerializeField]
    GameObject Water;

    [SerializeField]
    GameObject Fire;

    [SerializeField]
    GameObject Player;

    [SerializeField]
    int size;

    //Якщо іграка зїли викідаєм канву з вибор стихій
    [SerializeField]
    Canvas cheangElementUser;

    //Створюєм ботів для гри
    private List<GameObject> ListBots = new List<GameObject>();

    private ContolPL myPlayer;
    private List<MoveBot> OllBotsReturn = new List<MoveBot>();

    private string[] namesBot = {"Karl", "Bobi", "Toni", "Cooleyt", "Vivi", "KaSun", "Destroy", "Bugabum", "Horse",
                                 "Fin", "Felt", "Lesi", "Kirk", "Roni", "Karto", "NoName", "Kasi", "Bit", "Alfred",
                                  "Andi", "Ron", "Shrek", "Wendi", "Lara", "Kit", "Imba", "Ysup", "Greak", "Lao", "Rakshata"};
    //Ініціалізуєм ботів
    private void Start()
    {
        size = MainBatton.CounterBot;

        for (int i = 0; i < size / 3; i++)
        {
            ListBots.Add(Instantiate(Ice) as GameObject);
            ListBots.Add(Instantiate(Fire) as GameObject);
            ListBots.Add(Instantiate(Water) as GameObject);
        }

        for(int i =0; i <size;i++)
        {
            ListBots[i].transform.position = new Vector3(Random.Range(-20.0f, 20.0f), 1.0f, Random.Range(-20.0f, 20.0f));
            ListBots[i].name = namesBot[i];
        }


        myPlayer = Player.GetComponent<ContolPL>();
        for (int i = 0; i < size; i++)
            OllBotsReturn.Add(ListBots[i].GetComponent<MoveBot>());

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Якщо іграка зїли пропонуєм на вибір іншу стихію І Оживляєм іграка
        if (!Player.activeInHierarchy)
        {
            cheangElementUser.gameObject.SetActive(true);

            myPlayer.kill = 0;
        }

        //активуєм програвших ботів
        for (int i = 0; i < size; i++)
        {
            if (!ListBots[i].activeInHierarchy)
            {
                ListBots[i].transform.position = new Vector3(Random.Range(-20.0f, 20.0f), 1.0f, Random.Range(-20.0f, 20.0f));
                ListBots[i].SetActive(true);
                OllBotsReturn[i].kill = 0;
            }
        }



    }
}
