using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody2D rig;
    private Animator anim;
    private CapsuleCollider2D cap;

    public float speed;
    public float detect;
    private float distance;
    private bool dead;
    private bool playerDestroyed;

    public Transform rightCol;
    public Transform leftCol;


    public Transform m_player;

    public Transform headPoint;

    private bool colliding;

    public LayerMask layer;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cap = GetComponent<CapsuleCollider2D>();
        dead = false;
        playerDestroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);
        if(!playerDestroyed)
        {
            distance = Vector2.Distance(transform.position, m_player.position);
        }
 
        if(!playerDestroyed  && distance < detect && !dead)
        {
            
            if(speed < 0)
            {
                if(transform.position.x < m_player.position.x)
                {
                    transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
                    speed = -speed;
                }
                transform.position = Vector2.MoveTowards(transform.position,m_player.position,speed *  Time.deltaTime * -1);
            }
            else
            {
                if(transform.position.x > m_player.position.x)
                {
                    transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
                    speed = -speed;
                }
                transform.position = Vector2.MoveTowards(transform.position,m_player.position,speed *  Time.deltaTime);
            }
            
        }
        else if(colliding  && !dead)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed = -speed;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player" )
        {
            float height = collision.contacts[0].point.y - headPoint.position.y;
            if(height > 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 2, ForceMode2D.Impulse);
                anim.SetBool("dead", true);
                dead = true;
                speed = 0;
                rig.constraints = RigidbodyConstraints2D.FreezeRotation;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject,0.7f);
            }
            else
            {
                anim.SetBool("attk", true);
                Game_Controller.instance.ShowGameOver();
                Destroy(collision.gameObject,1f);
                anim.SetBool("attk", true);
            }
        }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "attk"){
            anim.SetBool("dead", true);
            dead = true;
            speed = 0;
            rig.constraints = RigidbodyConstraints2D.FreezeRotation;
            rig.bodyType = RigidbodyType2D.Kinematic;
            Destroy(gameObject,0.7f);
            Destroy(collision.gameObject);
        }
    }
}
