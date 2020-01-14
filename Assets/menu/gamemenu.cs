using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemenu : MonoBehaviour
{
    //ゲームプレイ中にmenuを開いた時用
    [SerializeField] GameObject manu;
    private int mn = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    //続けるボタン用
    public void tudu()
    {
        manu.SetActive(false);
        Time.timeScale = 1;
        //マウスカーソル制御
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    //やめるボタン操作用
    public void end()
    {
        SceneManager.LoadScene("top");
    }
    // Update is called once per frame
    void Update()
    {
        //ESCを入力でページを開く
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //menuが開いていた場合
            if (manu != null)
            {
                Time.timeScale = 0;
                manu.SetActive(true);
                mn += 1;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

            //menuが閉じていた場合だけど挙動が納得できないので何か考える
            if (manu == null)
            {
                Time.timeScale = 1;
                manu.SetActive(false);
                mn -= 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
            }

        }
    }
}
