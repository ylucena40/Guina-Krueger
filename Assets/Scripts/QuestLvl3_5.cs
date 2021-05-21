using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLvl3_5 : MonoBehaviour
{
    public static QuestLvl3_5 instance;
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
        
        if(collision.gameObject.name == "Crate_blue" )
        {
            questComplete = true;
        }
        
    }
}
