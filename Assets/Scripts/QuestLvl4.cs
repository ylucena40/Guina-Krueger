using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLvl4 : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Player" )
        {

            Game_Controller.instance.AddElement("Skeleton_pink");
        }
        
    }
}
