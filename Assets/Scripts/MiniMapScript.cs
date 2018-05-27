using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour {

    [SerializeField]
    Transform player;
    //камера рухається за гравцем(Міні камера)бордер з ліва з низу
    private void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
    }


}
