using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] int health { get; set; }
    [SerializeField] int xSpeed;
    [SerializeField] int ySpeed;
    Health healthController;

    Rigidbody2D rb;

    [SerializeField] bool IsinitialWall;

	void Start () {
        health = 3;
        IsinitialWall = true;

        rb = GetComponent<Rigidbody2D>();
        healthController = GetComponent<Health>(); 
        rb.velocity = new Vector3(rb.velocity.x, 2, 0);
       
        

	}

    public int getHealth()
    {
        return health;
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
        if(other.gameObject.CompareTag("Obstacle"))
        {
            healthController.RemoveLife();
            Debug.Log("assets");
        }
        if(other.gameObject.CompareTag("Life"))
        {
            healthController.AddLife();
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
