using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Plataform : MonoBehaviour
{
    public float fallingTime;
    public float upTIme;

    private bool falling;

    private SpriteRenderer sr;
    private BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
        falling = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player" )
        {
            Invoke("Falling", fallingTime);
            falling = true;
        }
        if(falling){
            Invoke("Up", upTIme);
        }
    }

    void Falling()
    {
        sr.enabled = false;
        box.isTrigger = true;
    }
     void Up()
    {
        sr.enabled = true;
        box.isTrigger = false;
    }
}
