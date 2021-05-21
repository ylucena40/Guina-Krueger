using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLvl3_4 : MonoBehaviour
{
    public static QuestLvl3_4 instance;
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
        
        if(collision.gameObject.name == "Crate_yellow" )
        {
            questComplete = true;
        }
        
    }
}
