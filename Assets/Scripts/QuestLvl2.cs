using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLvl2 : MonoBehaviour
{
    
    public static QuestLvl2 instance;
    private bool questComplete;

    void Start(){
        instance = this;
        questComplete = false;
    }

    public bool VerifyQuestComplete(){
        return questComplete;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "box" )
        {
            questComplete = true;
        }
        
    }
    
}
