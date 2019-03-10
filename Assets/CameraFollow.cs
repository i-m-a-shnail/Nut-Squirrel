using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


    private Player target;
    void Start()
    {


        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, target.transform.position.y, -10);
    }
   
}
