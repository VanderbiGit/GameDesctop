using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CalcScore : MonoBehaviour {

    [SerializeField]
    private Text[] scours;

    private Dictionary<string, int> tempD;  
    //забиваєм таблицю дефолтними значеннями
    private void Start()
    {
        for (int i = 0; i < scours.Length; i++)
        {
            scours[i].text = "none : 0";
        }

        tempD = new Dictionary<string, int>();
    }

    int counter = 0;
    bool cheakIfolayerInTable;

    //рахуєм таблицю. НЕТРОГАТЬ:)
    public void calc(string name, int kill, string nameOfPlayer)
    {
        cheakIfolayerInTable = false;
        counter = 0;


        if(tempD.TryGetValue(name, out counter))
        {
            tempD.Remove(name);
            tempD.Add(name, kill);
        }
        else
        {
            tempD.Add(name, kill);
        }

        tempD = tempD.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

        counter = 0;

        foreach (var item in tempD)
        {
            if (counter == scours.Length-1)
                break;


            if(item.Key == name)
            {
                scours[counter].color = Color.white;
            }

            if (item.Key == nameOfPlayer && item.Key == name)
            {
                cheakIfolayerInTable = true;
                scours[scours.Length - 1].text = "";
                scours[counter].color = Color.yellow;

            }


            counter++;

            scours[counter-1].text = " " + counter + "." + item.Key + " : " + item.Value;

        }

        counter = 0;
        if (cheakIfolayerInTable == false && name == nameOfPlayer)
        {
            foreach (var item in tempD)
            {

                counter++;
                if (item.Key == nameOfPlayer && item.Key == name)
                {
                    scours[scours.Length-1].text = " " + counter + "." + item.Key + " : " + item.Value;
                    scours[scours.Length - 1].color = Color.yellow;
                    break;
                        
                }
            }
        }
 





    }



}
