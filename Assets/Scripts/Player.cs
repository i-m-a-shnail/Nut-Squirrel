using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    [SerializeField] int health=3;
    public int coinsAmount;
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
        SaveManager.SavePlayer(this);
        rb = GetComponent<Rigidbody2D>();
        healthController = GetComponent<Health>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
        rb.velocity = new Vector3(rb.velocity.x, 2, 0);


        coinsAmount = SceneSave.Instance.coinsAmount;

    }

    public int getHealth()
    {
        return health;
    }

    // Update is called once per frame
    void Update() {
        SwitchPlatform();

        Debug.Log(SaveManager.LoadPlayer().coinsAmount + "SAVEMANAGER");

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
        if (other.gameObject.CompareTag("Coin"))
        {
            coinsAmount++;
        }
        if(other.gameObject.CompareTag("Finish"))
        {
            //SaveManager.SavePlayer(this);
            playerSceneStatsSave();
            SceneManager.LoadScene("Level 2");
            
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

    private void playerSceneStatsSave()
    {
        SceneSave.Instance.coinsAmount = coinsAmount;
    }

    IEnumerator SpeedPowerUp()
    {
        rb.velocity = new Vector3(rb.velocity.x, 5 * rb.velocity.y, 0);
        //Debug.Log("current speed: " + rb.velocity.y);
        yield return new WaitForSeconds(5);
        rb.velocity = new Vector3(rb.velocity.x, 2, 0);
      //  Debug.Log("after speed: " + rb.velocity.y);
    }
}
