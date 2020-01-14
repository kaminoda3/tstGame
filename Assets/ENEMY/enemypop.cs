using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*エネミーを生成するときのスクリプト*/
public class enemypop : MonoBehaviour
{
    //モブ取得
    [SerializeField] GameObject enemy;
    //敵撃破スコア用
    private int count = 0;
    //モブ生成用
    private bool check;
    //ボスの生成判定用
    private int bosscheck=0;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject bossHP;
    //スコアの表記用
    public Text scoretext;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        //３秒待ってから起動する
        Invoke("Fpop", 3f);
        //撃破スコアの初期化
        score = 0;
        Uscoretext();
    }
    //スコア表示用
    public void addscore(int scoretoadd)
    {   
        //スコアに撃破数をプラスする
        score += scoretoadd;
        Uscoretext();
    }
    //スコア表示用
    void Uscoretext()
    {
        scoretext.text = "撃破数  " + score;
    }

    // Update is called once per frame
    void Update()
    {
        //ボスの出現状態の判定
        if (score == 5 && bosscheck == 0)
        {
            bosscheck += 1;
            boss.SetActive(true);
            bossHP.SetActive(true);
        }

        //モブの生成用
        if (check == true)
        {
            if (count <= 10)
            {
                check = false;
                StartCoroutine("Uenemypop");
            }
        }
    }

    //１体目のモブの出現位置
    void Fpop()
    {
        Instantiate(enemy, new Vector3(0f, 1f, 60f),Quaternion.identity);
        check = true;
        count += 1;
    }

    //２体目以降のモブの出現位置
    IEnumerator Uenemypop()
    {
        //５秒待ってから
        yield return new WaitForSeconds(5f);
        //生成が行われる範囲指定
        float xd = Random.Range(-100f, 100f);
        float zd = Random.Range(100f, 250f);
        //モブを生成する
        Instantiate(enemy, new Vector3(xd, 1f, zd), Quaternion.identity);
        check = true;
        count += 1;
    }
}
