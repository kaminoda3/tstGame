using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*ボスにアタッチするスクリプト
　モジュールのオブジェクトをランダムに出現させてプレイヤーへ攻撃する*/

public class bossCTL : MonoBehaviour
{
    //プレイヤーとオブジェクト
    [SerializeField] GameObject player = default;
    [SerializeField] GameObject a = default;
    [SerializeField] GameObject b = default;
    [SerializeField] GameObject c = default;
    [SerializeField] GameObject d = default;
    [SerializeField] GameObject e = default;
    bool Acheck = true;
    bool Bcheck = true;
    bool Ccheck = true;
    bool Dcheck = true;
    bool Echeck = true;
    //オブジェクト格納用のリスト
    public List<GameObject> mylist = new List<GameObject>();
    //ボスの最大HP
    [SerializeField] private int maxHP;
    //ボスの現在HP
    private int hp;
    //HPバー表示用のスライダー
    [SerializeField] private GameObject HPUI;
    [SerializeField] private Slider HP;
    //ボスが発射する弾
    [SerializeField] private GameObject tama;
    //プレイヤーの弾に設定されている値を取得するときに使う
    private tamas scr;
    //ボスのモジュールが破壊された時に使う
    public int bonus = 1;

    // Start is called before the first frame update
    void Start()
    {
        //HPの初期値を設定
        hp = maxHP;
        //比率計算用
        HP.value = 1f;
        //プレイヤーの弾に設定されているスクリプト参照用
        scr = tama.GetComponent<tamas>();
        //ゲーム開始時の挙動
        StartCoroutine(St());

    }

    // Update is called once per frame
    void Update()
    {
        //モジュールが存在しなくなった時にリストから外す
        if (a == null)
        {
            mylist.Remove(a);
            if (Acheck == true)
            {
                Acheck = false;
                bonus += 1;
            }
        }
        if (b == null)
        {
            mylist.Remove(b);
            if (Bcheck == true)
            {
                Bcheck = false;
                bonus += 1;
            }
        }
        if (c == null)
        {
            mylist.Remove(c);
            if (Ccheck == true)
            {
                Ccheck = false;
                bonus += 1;
            }
        }
        if (d == null)
        {
            mylist.Remove(d);
            if (Dcheck == true)
            {
                Dcheck = false;
                bonus += 1;
            }
        }
        if (e == null)
        {
            mylist.Remove(e);
            if (Echeck == true)
            {
                Echeck = false;
                bonus += 1;
            }
        }
    }
    //モジュールの挙動用
    void AIMROTE()
    {
        //ボスとプレイヤーの位置関係を計算
        var aim = player.transform.position - transform.position;
        //ボスとプレイヤーの角度を取得
        var look = Quaternion.LookRotation(aim);
        //オブジェクトの角度を変更
        transform.localRotation = look;
    }

    IEnumerator St()
    {
        //モジュールのリスト化
        mylist = new List<GameObject>();
        mylist.Add(a);
        mylist.Add(b);
        mylist.Add(c);
        mylist.Add(d);
        mylist.Add(e);

        //whileを使って無限ループを作る
        while (true)
        {
            //10秒待ってから起動する
            yield return new WaitForSeconds(10f);
            //リストの0個からリストの数で値を決める
            int i = Random.Range(0, mylist.Count - 1);
            //選ばれたオブジェクトをアクティブにする
            mylist[i].SetActive(true);
            //そのオブジェクトに設定されている弾発射のスクリプトを呼び出す
            var f = mylist[i].GetComponent<enemySHOT>();
            //そのスクリプトを起動する
            f.shot = true;
        }
    }

    //ダメージ計算
    private void OnCollisionEnter(Collision collision)
    {
        //tamaタグとぶつかった時
        if (collision.gameObject.tag == "tama")
        {
            //弾の威力を計算
            int pow = scr.power * (bonus);
            hp -= pow;
            HP.value = (float)hp / (float)maxHP;
        }
        //HPの比率が0以下になった時
        if (HP.value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
