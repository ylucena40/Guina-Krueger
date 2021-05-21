using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    private Animator anim;

    public static Menu instance;
    public List<string> code = new List<string>();

    public GameObject ninja;
    private bool ninjaAct;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
        ninjaAct = false;
        //A-B-A-C-A-B-B
        code.Add("A");
        code.Add("A");
        code.Add("A");
        code.Add("A");
        code.Add("A");
        code.Add("A");
        code.Add("A");
    }

    void Update()
    {   
        if(!ninjaAct)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                code.Add("A");
            }
            else if(Input.GetKeyDown(KeyCode.B))
            {
                code.Add("B");
            }
            else if(Input.GetKeyDown(KeyCode.C))
            {
                code.Add("C");
            }
            VerifyCode();
        }
    }

    public void VerifyCode(){
        for(int i = 0; i <= (code.Count-7); i++){
             //A-B-A-C-A-B-B
            if(code[i] == "A" &&
                code[i+1] == "B" &&
                code[i+2] == "A" &&
                code[i+3] == "C" &&
                code[i+4] == "A" &&
                code[i+5] == "B" &&
                code[i+6] == "B"
                ){
                    CodeNinja();
                    break;
            }
        }
    }

    public void CodeNinja()
    {
        ninjaAct = true;
        ninja.SetActive(true);
    }

    public void ActiveAnimMadeira(){
        
        anim.SetBool("selectMadeira", true);
    }

    public void DesableAnimMadeira(){
        
        anim.SetBool("selectMadeira", false);
    }

    public void ActiveAnimDiego(){
        
        anim.SetBool("selectDiego", true);
    }

    public void DesableAnimDiego(){
        
        anim.SetBool("selectDiego", false);
    }

    public void ActiveAnimNinja(){
        
        anim.SetBool("selectNinja", true);
    }

    public void DesableNinja(){
        
        anim.SetBool("selectNinja", false);
    }

    public void SelectMadeira(){
        SceneManager.LoadScene("lvl_1");
    }

    public void SelectDiego(){
        SceneManager.LoadScene("lvl_6");
    }

    public void SelectNinja(){
        SceneManager.LoadScene("lvl_11");
    }
}
