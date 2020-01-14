using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*設定画面用スクリプト*/
public class setCTL : MonoBehaviour
{
    //トップメニューに戻るボタン用
    public void topback()
    {
        SceneManager.LoadScene("top");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //キー操作でトップメニューに戻る時用
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("top");
        }
    }
}
