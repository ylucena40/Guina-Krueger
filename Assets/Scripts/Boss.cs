using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boss : MonoBehaviour
{

    
    private float speed;
    private float distance;
    private float distanceP;
    private bool playerDestroyed;

    private float time = 4.0f;
    private float timeCudown = 4.5f;

    private bool attacking;
    private int front = 0;

    public static int life = 20;
    public Slider lifeBar;

    private Rigidbody2D rig;
    private Animator anim;

    public Transform m_player;

    public Transform headPoint;

    
    public GameObject attk;
    public GameObject attk_pers;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        attacking = false;
        lifeBar.value = life;
        speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Attack();
        Life();
    }

    void Life(){
        lifeBar.value = life;
        if(life == 10){
            if(speed < 0 )
            {
                speed = -3.0f;
            }
            else
            {
                speed = 3.0f;
            }
            
        }
        else if(life == 5){
            timeCudown = 2.5f;
        }
        else if(life == 5){
            speed = 4.0f;
        }
        if(!(life > 0)){
            anim.SetBool("dead", true);
            Destroy(gameObject,1f);
        }
    }


    
    void Attack()
    {
        
        distance = Vector2.Distance(transform.position, m_player.position);
        time += Time.deltaTime;
        if(distance < 8 && time > timeCudown)
        {
           attacking = true;
           if(attacking && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Attk") )
           {
                time  = 0.0f;
                anim.SetTrigger("attk");
                GameObject tmpAttk = (GameObject) (Instantiate(attk,attk_pers.transform.position,Quaternion.identity));
                if(front == 1)
                {
                    tmpAttk.GetComponent<Attk_Boss>().SetDirection(Vector2.right);
                }
                else
                {
                    tmpAttk.GetComponent<Attk_Boss>().SetDirection(Vector2.left);
                }
                
           }
           attacking = false;
        } 
       
    }

    void Move()
    {
        distanceP = Vector2.Distance(transform.position, m_player.position);
        if(distanceP > 1){
            if(speed < 0)
            {
                if(transform.position.x > m_player.position.x)
                {
                    transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
                    front = 0;
                    speed = -speed;
                }
                transform.position = Vector2.MoveTowards(transform.position,m_player.position,speed *  Time.deltaTime * -1);
            }
            else
            {
                if(transform.position.x < m_player.position.x)
                {
                    transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
                    front = 1;
                    speed = -speed;
                }
                transform.position = Vector2.MoveTowards(transform.position,m_player.position,speed *  Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player" )
        {
            float height = collision.contacts[0].point.y - headPoint.position.y;
            if(height > 0 && !playerDestroyed)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                life -= 1;
                lifeBar.value = life;
            }
            else
            {
                anim.SetBool("attk", true);
                playerDestroyed = true;
                Game_Controller.instance.ShowGameOver();
                Destroy(collision.gameObject,1f);
                anim.SetBool("attk", true);
                life = 10;
                lifeBar.value = life;
            }
        }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "attk"){
            life -= 1;
            lifeBar.value = life;
        }
    }
}
