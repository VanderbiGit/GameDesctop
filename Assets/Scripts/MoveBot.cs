using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBot : MonoBehaviour {

    [SerializeField]
    float speed;

    [SerializeField]
    private string element;//стихія за якою біжимо і зїдаємо 

    Vector3 targetPosition;//вектор нашой цілі

    private List<GameObject> targets = new List<GameObject>();//список наших цілей
    private GameObject target;//обєкт цілі
    public int kill;//к-сть очків
    

    private CalcScore myCacl;//Таблиця

    void Start()
    {
        //заряжаєм бота на ціль
        targets.AddRange(GameObject.FindGameObjectsWithTag(element));
        
        target = targets[Random.Range(0,targets.Count)];

        targetPosition = target.transform.position;

        kill = 0;
        myCacl = GameObject.Find("TableScour").GetComponent<CalcScore>();
    }

    void FixedUpdate()
    {
        //Ціль знищена , шукаєм іншу
        if(!target.activeInHierarchy)
        {
            /////////////////////
            targets.Clear();
            targets.AddRange(GameObject.FindGameObjectsWithTag(element));
            /////////////////////

            for (int i = 0; i < targets.Count; i++)
                if (targets[i].activeInHierarchy)
                {
                    target = targets[i];
                    break;
                }
        }
        else//ідем по сліду
        {
            targetPosition = target.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        //рахуєм таблицю
        myCacl.calc(gameObject.name, kill, string.Empty);
    }

    //Трігер знайшли ціль
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(element))
        {
            other.gameObject.SetActive(false);
            kill++;
        }
    }


}
