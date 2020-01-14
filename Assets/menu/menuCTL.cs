using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//トップmenu用
public class menuCTL : MonoBehaviour
{
    //始めるボタン用
    public void stbutton()　{SceneManager.LoadScene("game");
    }

    //終了ボタン用
    public void endbutton() { Application.Quit(); }
    
    //設定ボタン用
    public void setbutton() { SceneManager.LoadScene("set"); }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
