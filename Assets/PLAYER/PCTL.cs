using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCTL : MonoBehaviour
{
    //カメラの移動用
    private float inputHORI;
    private float inputVER;
    //カメラ取得
    [SerializeField] Camera cmr = default;
    [SerializeField] Camera subcmr = default;

    [SerializeField] Rigidbody rb = default;
    //移動速度
    private float speed = 30f;
    //プレイヤーのHP設定
    public int HPP;
    [SerializeField] int MAXHPP;
    [SerializeField] private GameObject HPUI;
    [SerializeField] private Slider HP;

    private bool ch = true;

    // Start is called before the first frame update
    void Start()
    {
        //HP初期化
        HPP = MAXHPP;
        HP.value = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //入力を認識する
        inputHORI = Input.GetAxisRaw("Horizontal");
        inputVER = Input.GetAxisRaw("Vertical");

        float xr = 180f; float yr = 290f;
        //プレイヤーの移動範囲制限
        transform.position = new Vector3
            (Mathf.Clamp(transform.position.x, -xr, xr),
            transform.position.y,
             Mathf.Clamp(transform.position.z, 0f, yr));
       // Mathf.Clamp(transform.position.x, -xr, xr);
        //Mathf.Clamp(transform.position.z, 0f, yr);
    }

    //カメラの向きを基準にして操作を行う時に使う
    private void FixedUpdate()
    {
        if (subcmr.gameObject.activeSelf == false)
        {
            Vector3 camera = Vector3.Scale(cmr.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 move = camera * inputVER + cmr.transform.right * inputHORI;
            rb.velocity = move * speed + new Vector3(0, rb.velocity.y, 0);
        }
        if (subcmr.gameObject.activeSelf == true)
        {
            Vector3 camera = Vector3.Scale(subcmr.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 move = camera * inputVER + subcmr.transform.right * inputHORI;
            rb.velocity = move * speed + new Vector3(0, rb.velocity.y, 0);
        }
    }
    //プレイヤーの被ダメージ関係
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            if (ch == true)
            {
                ch = false;
                HPP -= 10;
                var kill=GameObject.FindWithTag("GameController").GetComponent<enemypop>();
                kill.addscore(1);
                StartCoroutine("Stn");
            }

            
            HP.value = (float)HPP / (float)MAXHPP;
        }
        if (other.gameObject.CompareTag("enemytama"))
        {
            HPP -= 1;
            HP.value = (float)HPP / (float)MAXHPP;
        }
    }
    IEnumerator Stn()
    {
        yield return new WaitForSeconds(0.2f);
        ch = true;
    }
}
