using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*カメラにアタッチするスクリプト
　左のシフトキーの入力で照準の表示を切り替える
　左のシフトキーの入力でカメラを切り替える*/
public class CTLboxC : MonoBehaviour
{   //照準の画像
    [SerializeField] Image AIM = default;
    //照準表示切替の判定
    private bool aimOn;
    //カメラの設定
    [SerializeField] GameObject cmr = default;
    [SerializeField] GameObject subcmr = default;
    private bool cmrcc = true;
    //プレイヤー取得
    [SerializeField] GameObject player;
    private int HP;
    //テキスト表示用
    [SerializeField] Text gameovertext;
    [SerializeField] Text gameCleartext;
    [SerializeField] GameObject rp;
    //ゲームオーバー判定
    private bool gameovercheck = false;
    //ボス取得
    [SerializeField] GameObject boss;
    
    // Start is called before the first frame update
    void Start()
    {
        
        AIM.enabled = false;
        aimOn = false;
        gameovertext.text = "";
        gameCleartext.text = "";
        //マウスカーソルを隠す
        Cursor.visible = false;
        //マウスカーソルをゲームウィンドウ外に出さない
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {  
        //照準の切り替え用
        if (Input.GetKeyDown(KeyCode.LeftShift) && aimOn == false)
        {
            aimOn = true;
            AIM.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && aimOn == true)
        {
            aimOn = false;
            AIM.enabled = false;
        }

        //カメラの切り替え用
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (cmrcc == true)
            {
                cmrcc = false;
                subcmr.SetActive(true);
                cmr.SetActive(false);
            }
            else if (cmrcc == false)
            {
                cmrcc = true;
                cmr.SetActive(true);
                subcmr.SetActive(false);
            }
        }
        //プレイヤーのHPを取得
        HP = player.GetComponent<PCTL>().HPP;

        //負けた時
        if (HP <= 0)
        {
            gameCleartext.text = "GameOvre";
            rp.SetActive(true);
            gameovercheck = true;
            Time.timeScale = 0;
        }
        //ボスを倒した時
        if (boss==null)
        {
            gameCleartext.text = "GameClear";
            rp.SetActive(true);
            gameovercheck = true;
            Time.timeScale = 0;
        }
        //ゲームが勝ち負け関わらず終了したとき
        if (gameovercheck == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (Input.GetKeyDown(KeyCode.Z))
            {
                SceneManager.LoadScene("game");

            }
        }
    }
}
