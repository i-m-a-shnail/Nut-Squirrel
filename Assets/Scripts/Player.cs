using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] int health { get; set; }
    [SerializeField] int xSpeed;
    [SerializeField] int ySpeed;
    Health healthController;
    SpriteRenderer playerSprite;
    Rigidbody2D rb;

    [SerializeField] bool IsinitialWall;
    bool start;

    void Start() {
        health = 3;
        IsinitialWall = true;
        start = true;

        rb = GetComponent<Rigidbody2D>();
        healthController = GetComponent<Health>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        rb.velocity = new Vector3(rb.velocity.x, 2, 0);



    }

    public int getHealth()
    {
        return health;
    }

    // Update is called once per frame
    void Update() {
        SwitchPlatform();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Wall"))
        {

            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            IsinitialWall = !IsinitialWall;
        }
        if (other.gameObject.CompareTag("Obstacle"))
        {
            healthController.RemoveLife();
            
        }
        if (other.gameObject.CompareTag("Life"))
        {
            healthController.AddLife();
        }
        if(other.gameObject.CompareTag("Speed"))
        {
            StartCoroutine(SpeedPowerUp());      
        }
        //Destroy(other.gameObject);

    }

    void flipPlayer()
    {
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
       

    }

    void SwitchPlatform()
    {       
        float direction;
        if (IsinitialWall) direction = 5;
        else direction = -5;


        if (Input.GetKeyDown("space"))
        {
            flipPlayer();
            rb.velocity = new Vector3(direction*2.5f, rb.velocity.y, 0);


            //Debug.Log(transform.position.x);
            //Debug.Log(targetWall.x);
            
        }
        //float distance = Mathf.Abs(transform.position.x - targetWall.x);
        //Debug.Log(distance);
        
       

    }

    IEnumerator SpeedPowerUp()
    {
        rb.velocity = new Vector3(rb.velocity.x, 5 * rb.velocity.y, 0);
        Debug.Log("current speed: " + rb.velocity.y);
        yield return new WaitForSeconds(5);
        rb.velocity = new Vector3(rb.velocity.x, 2, 0);
        Debug.Log("after speed: " + rb.velocity.y);
    }
}
