using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ContolPL : MonoBehaviour
{
    [SerializeField]
    private float speed;

    //ціль
    public string element;

    //друга точка в яку рухаємся
    private Vector3 targetPosition;

    public int kill;

    private CalcScore myCacl;

    void Start()
    {
        gameObject.name = MainBatton.nameUser;

        targetPosition = Vector3.zero;

        transform.position = new Vector3(Random.Range(-20.0f, 20.0f), 1.0f, Random.Range(-20.0f, 20.0f));

        kill = 0;
        myCacl = GameObject.Find("TableScour").GetComponent<CalcScore>();
    }


    void FixedUpdate()
    {
        //кідаєм луч
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
        {

            targetPosition = hit.point;

            targetPosition.y = transform.position.y;//щоб ігрок не взлітав
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);


        myCacl.calc(gameObject.name, kill, gameObject.name);

        //Ескейп виходим в МЕНЮ
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
   
    }

    //Трігер
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(element))
        {
            other.gameObject.SetActive(false);
            kill++;

        }
    }


}
