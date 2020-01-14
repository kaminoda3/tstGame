using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*enemyにアタッチ
  HPバーの設定*/
public class bossmojCTL : MonoBehaviour
{
    //モジュールの最大HP
    [SerializeField] private int maxHP = 20;
    //モジュールのHP
    private int hp;
    //オブジェクト取得
    [SerializeField] private GameObject HPUI;
    [SerializeField] private Slider HP;
    //モジュールが発射する弾
    [SerializeField] private GameObject tama;
    private tamas scr;
    //ボス本体
    [SerializeField] GameObject boss;

    void Start()
    {
        hp = maxHP;
        HP.value = 1f;
        scr = tama.GetComponent<tamas>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "tama")
        {
            int pow = scr.power;
            hp -= pow;
            HP.value = (float)hp / (float)maxHP;
        }

        if (HP.value <= 0)
        {
           var bosdam=boss.GetComponent<bossCTL>();
            Destroy(gameObject);
        }
    }
}
