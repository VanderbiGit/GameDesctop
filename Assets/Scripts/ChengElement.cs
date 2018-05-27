using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChengElement : MonoBehaviour {

    //Клас для переформотування іграка в іншу стихію

    [SerializeField]
    GameObject Player;

    [SerializeField]
    Material FireMat;

    [SerializeField]
    Material WaterMat;

    [SerializeField]
    Material IceMat;

    private ContolPL myPlayer;

    public void Ice()
    {
        myPlayer = Player.GetComponent<ContolPL>();
        Player.tag = "Ice";
        myPlayer.element = "Water";
        myPlayer.GetComponent<MeshRenderer>().material = IceMat;

        Player.transform.position = new Vector3(Random.Range(-20.0f, 20.0f), 1.0f, Random.Range(-20.0f, 20.0f));
        Player.SetActive(true);
        
        gameObject.SetActive(false);

    }

    public void Water()
    {
        myPlayer = Player.GetComponent<ContolPL>();
        Player.tag = "Water";
        myPlayer.element = "Fire";
        myPlayer.GetComponent<MeshRenderer>().material = WaterMat;

        Player.transform.position = new Vector3(Random.Range(-20.0f, 20.0f), 1.0f, Random.Range(-20.0f, 20.0f));
        Player.SetActive(true);

        gameObject.SetActive(false);

    }

    public void Fire()
    {
        myPlayer = Player.GetComponent<ContolPL>();
        Player.tag = "Fire";
        myPlayer.element = "Ice";
        myPlayer.GetComponent<MeshRenderer>().material = FireMat;

        Player.transform.position = new Vector3(Random.Range(-20.0f, 20.0f), 1.0f, Random.Range(-20.0f, 20.0f));
        Player.SetActive(true);

        gameObject.SetActive(false);
    }
}
