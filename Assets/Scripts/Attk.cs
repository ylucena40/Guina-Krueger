using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attk : MonoBehaviour
{
    private CircleCollider2D circ;
    private Rigidbody2D rig;

    private float speed;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    { 
        rig = GetComponent<Rigidbody2D>();
        circ = GetComponent<CircleCollider2D>();
        speed = 3.0f;
        
    }

    void FixedUpdate()
    {
        rig.velocity = direction * speed;
        Destroy(gameObject, 1);
    }

    public void SetDirection(Vector2 _dir){
        direction = _dir;
    }

    
    

}
