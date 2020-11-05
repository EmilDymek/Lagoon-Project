using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairBehaviour : MonoBehaviour
{
//    private GameObject Player;
//    private LineRenderer lineRend;


    void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
        //lineRend = GetComponent<LineRenderer>();
        //lineRend.positionCount = 2;
        Cursor.visible = false;
    }

    void Update()
    {
        this.transform.position = Input.mousePosition;
        //lineRend.SetPosition(0, new Vector3(this.transform.position.x, this.transform.position.y, 0));
        //lineRend.SetPosition(1, new Vector3(Player.transform.position.x, Player.transform.position.y, 0));
        
    }
}
