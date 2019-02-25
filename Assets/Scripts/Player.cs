using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] int health;
    [SerializeField] int xSpeed;
    [SerializeField] int ySpeed;
    

    Rigidbody2D rb;

    [SerializeField] bool IsinitialWall;

	void Start () {
        IsinitialWall = true;

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector3(rb.velocity.x, 2, 0);
       
        

	}
	
	// Update is called once per frame
	void Update () {
        SwitchPlatform();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Wall"))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            IsinitialWall = !IsinitialWall;
        }

    }

    void SwitchPlatform()
    {       
        float direction;
        if (IsinitialWall) direction = 5;
        else direction = -5;


        if (Input.GetKeyDown("space"))
        {


            rb.velocity = new Vector3(direction*2.5f, rb.velocity.y, 0);


            //Debug.Log(transform.position.x);
            //Debug.Log(targetWall.x);
            
        }
        //float distance = Mathf.Abs(transform.position.x - targetWall.x);
        //Debug.Log(distance);
        
       

    }
}
