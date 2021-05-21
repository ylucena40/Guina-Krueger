using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public bool quest;
    public string lvlName;
    public List<string> array = new List<string>();

    public int sizeArray = 5;

    public GameObject gameOver;

    public static Game_Controller instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame()
    {
        Boss.life = 20;
        SceneManager.LoadScene(lvlName);
    }

    public bool VerifyQuest(){
        return quest;
    }
    public string LevelNow(){
        return lvlName;
    }
    public void AddElement(string element){
        sizeArray+=1;
        array.Add(element);
    }
    public void AddSizeArray(int i){
        sizeArray+=1;
    }
    
}
