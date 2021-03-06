﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemenu : MonoBehaviour
{
    //ゲームプレイ中にmenuを開いた時用
    [SerializeField] GameObject menu;
    private int mn = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    //続けるボタン用
    public void tudu()
    {
        menu.SetActive(false);
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
            //menuが閉じていた場合
            if (menu.activeSelf == false)
            {
                Time.timeScale = 0;
                menu.SetActive(true);
                mn += 1;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                
            }

            //menuが開いていた場合
            else if (menu.activeSelf==true)
            {
                Time.timeScale = 1;
                menu.SetActive(false);
                mn -= 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
                Debug.Log(2);
            }

        }
    }

}
