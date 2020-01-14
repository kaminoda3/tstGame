using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*enemyにアタッチ
  HPバーの設定*/
public class mobCTL : MonoBehaviour
{
    
    GameObject player;
    [SerializeField] private int maxHP = 20;
    private int hp;
    [SerializeField] private GameObject HPUI;
    [SerializeField] private Slider HP;
    [SerializeField] private GameObject tama;
    private tamas scr;
    private Vector3 now;
    [SerializeField] Rigidbody rb;
    private int killcount = 0;
    private enemypop kill;

    void Start()
    {
        hp = maxHP;
        HP.value = 1f;
        scr = tama.GetComponent<tamas>();
        player = GameObject.FindWithTag("Player");
        kill = GameObject.FindWithTag("GameController").GetComponent<enemypop>();
    }

    void Update()
    {
        //モブとプレイヤーの座標計算
        Vector3 aim = transform.position - player.transform.position;
        var look = Quaternion.LookRotation(aim);
        transform.localRotation = look;
        //モブをプレイヤーに突撃させる
        transform.position += transform.forward * -0.2f;
    }

    //モブとプレイヤーがぶつかった時
    private void OnTriggerEnter(Collider other)
    {
        //モブ自体にもtamaと同じタグを設定している
        if (other.gameObject.tag == "tama")
        {
            int pow = scr.power;
            hp -= pow;
            HP.value = (float)hp / (float)maxHP;
        }

        if (other.gameObject == player)
        {
            Destroy(gameObject);
        }

        if (HP.value <= 0)
        {
            kill.addscore(1);

            Destroy(gameObject);
        }
    }
}