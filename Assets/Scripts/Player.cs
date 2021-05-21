using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    public float speed;
    public float jumpForce;

    public bool isJumping;
    public bool doubleJump;

    private bool attacking;
    private int front = 1;

    public static int nHits = 2;
    public static int hitsStartScene = 0;
    public Text hitsText;


    private Rigidbody2D rig;
    private Animator anim;

    
    public GameObject attk;
    public GameObject attk_pers;


    

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        attacking = false;
        hitsStartScene = DataHit.hit;
        nHits = hitsStartScene;
        Game_Controller.instance.array.Add("1");
        Game_Controller.instance.array.Add("2");
        Game_Controller.instance.array.Add("3");
        Game_Controller.instance.array.Add("4");
        Game_Controller.instance.array.Add("5");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Attack();
        AttHit();
    }

    void Attack()
    {
       if(Input.GetKeyDown(KeyCode.E))
       {
           attacking = true;
           if(attacking && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Attk") && nHits > 0 )
           {
                anim.SetTrigger("attk");
                GameObject tmpAttk = (GameObject) (Instantiate(attk,attk_pers.transform.position,Quaternion.identity));
                if(front == 1)
                {
                    tmpAttk.GetComponent<Attk>().SetDirection(Vector2.right);
                }
                else
                {
                    tmpAttk.GetComponent<Attk>().SetDirection(Vector2.left);
                }
                nHits -= 1;
                AttHit();
           }
           attacking = false;
       } 
       
    }


    void Move()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += move * Time.deltaTime * speed;
        if(Input.GetAxis("Horizontal") > 0f && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Attk"))
        {
            anim.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
            front = 1; 
        }
        if(Input.GetAxis("Horizontal") < 0f  && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Attk"))
        {
            anim.SetBool("run", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
            front = 0;
        }
        if(Input.GetAxis("Horizontal") == 0f && !anim.GetCurrentAnimatorStateInfo(0).IsTag("Attk"))
        {
            anim.SetBool("attk", false);
            anim.SetBool("run", false);
            
        }
        
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
                if(Input.GetAxis("Horizontal") > 0f)
                {
                    transform.eulerAngles = new Vector3(0f,0f,0f);
                }
                if(Input.GetAxis("Horizontal") < 0f)
                {   
                    transform.eulerAngles = new Vector3(0f,180f,0f);
                }
            }
            else{
                if(doubleJump){
                    rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    anim.SetBool("doub", true);
                    if(Input.GetAxis("Horizontal") > 0f)
                    {
                        transform.eulerAngles = new Vector3(0f,0f,0f);
                    }
                    if(Input.GetAxis("Horizontal") < 0f)
                    {   
                        transform.eulerAngles = new Vector3(0f,180f,0f);
                    }
                    doubleJump = false;
                }
            }
            
        }
    }

    void AttHit(){
         hitsText.text =  nHits.ToString();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.layer == 8 || collision.gameObject.layer == 14)
        {
            isJumping = false;
            anim.SetBool("jump", false);
            anim.SetBool("doub", false);

        }
        if(collision.gameObject.tag == "Danger" )
        {
            Game_Controller.instance.ShowGameOver();
            nHits = hitsStartScene;
            Destroy(gameObject);
        }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8 || collision.gameObject.layer == 14 )
        {
           isJumping = true; 
        }
    }

    

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 16 )
        {
            nHits += 2;
            AttHit();
        }
        if(collision.gameObject.layer == 10)
        {
            Game_Controller.instance.ShowGameOver();
            nHits = hitsStartScene;
            Destroy(gameObject);
        }
    }
    
}
