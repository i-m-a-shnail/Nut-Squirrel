using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    // Use this for initialization
    
    [SerializeField] int health;
    [SerializeField] int maxHealth=3;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;
    [SerializeField] Image[] hearts;
	void Start () {
        Player player = GetComponent<Player>();
        health = player.getHealth();
        

	}

    public void RemoveLife()
    {
        if (maxHealth - health == 1)
        {
            hearts[health - 1].sprite = emptyHeart;
            health--;
        }

    }

    public void AddLife()
    {
        if (health < maxHealth)
        {
            health++;
            hearts[health - 1].sprite = fullHeart;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //for (int i = 0; i < hearts.Length; i++)
        //{
        //    Debug.Log("outer loop");
        //    Debug.Log(health);
        //    Debug.Log(i + " i" );
        //    if (health<i+1)
        //    {
        //        hearts[i].sprite = emptyHeart;
        //        Debug.Log("inner loop");
        //    }
        //}
       
	}
}
