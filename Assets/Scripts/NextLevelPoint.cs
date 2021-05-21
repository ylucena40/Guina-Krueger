using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelPoint : MonoBehaviour
{
    public string lvlName;

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(Game_Controller.instance.LevelNow() == "lvl_1" || Game_Controller.instance.LevelNow() == "lvl_6" || Game_Controller.instance.LevelNow() == "lvl_11" )
        {
            DataHit.hit = Player.nHits;
            Player.hitsStartScene = DataHit.hit;
            SceneManager.LoadScene(lvlName);
        }
        else if(Game_Controller.instance.LevelNow() == "lvl_2" || Game_Controller.instance.LevelNow() == "lvl_7" || Game_Controller.instance.LevelNow() == "lvl_12")
        {
            if(QuestLvl2.instance.VerifyQuestComplete()){
                DataHit.hit = Player.nHits;
                Player.hitsStartScene = DataHit.hit;
                SceneManager.LoadScene(lvlName);
            }
        }
        else if(Game_Controller.instance.LevelNow() == "lvl_3"|| Game_Controller.instance.LevelNow() == "lvl_8" || Game_Controller.instance.LevelNow() == "lvl_13")
        {
            if(QuestLvl3_1.instance.VerifyQuestComplete()
                && QuestLvl3_2.instance.VerifyQuestComplete()
                && QuestLvl3_3.instance.VerifyQuestComplete()
                && QuestLvl3_4.instance.VerifyQuestComplete()
                && QuestLvl3_5.instance.VerifyQuestComplete()
            ){
                DataHit.hit = Player.nHits;
                Player.hitsStartScene = DataHit.hit;
                SceneManager.LoadScene(lvlName);
            }
        }
        else if(Game_Controller.instance.LevelNow() == "lvl_4"|| Game_Controller.instance.LevelNow() == "lvl_9" || Game_Controller.instance.LevelNow() == "lvl_14")
        {
            for(int i = 0; i <= (Game_Controller.instance.array.Count-5); i++)
            {
                if(Game_Controller.instance.array[i] == "Skeleton_pink"
                    && Game_Controller.instance.array[i+1] == "Skeleton_pink"
                    && Game_Controller.instance.array[i+2] == "Skeleton_blue"
                    && Game_Controller.instance.array[i+3] == "Skeleton_yellow"
                    && Game_Controller.instance.array[i+4] == "Skeleton_blue"
                )
                {
                    DataHit.hit = Player.nHits;
                    Player.hitsStartScene = DataHit.hit;
                    Boss.life = 20;
                    SceneManager.LoadScene(lvlName);
                    break;
                }
            }
            
        }
        else if(Game_Controller.instance.LevelNow() == "lvl_5"|| Game_Controller.instance.LevelNow() == "lvl_10"  || Game_Controller.instance.LevelNow() == "lvl_15")
        {
            if(Boss.life <= 0)
            {
                DataHit.hit = Player.nHits;
                Player.hitsStartScene = DataHit.hit;
                SceneManager.LoadScene(lvlName);
            }
        }
        
    }
}
