using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*cubeにアタッチするスクリプト
　クリックされた時に弾を発射する。その後一定時間のインターバルを入れる*/
public class tamaCTL : MonoBehaviour
{   //発射速度
    [SerializeField] float speed = default;
    //弾薬
    [SerializeField] GameObject tama = default;
    //砲身
    [SerializeField] Transform muz = default;

    //発射可能かどうかの判定
    private bool shot;



    // Start is called before the first frame update
    void Start()
    {
        shot = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (shot == true)
            {

                shot = false;
                //弾を生成
                GameObject tamas = Instantiate(tama) as GameObject;
                //方向と速度
                Vector3 force= muz.gameObject.transform.forward * speed;
                tamas.GetComponent<Rigidbody>().AddForce(force);
                //発射地点
                tamas.transform.position = muz.position;
                //発射判定
                StartCoroutine("stp");
            }
        }
    }
    IEnumerator stp()
    {   //0.2秒経過してから判定を変える
        yield return new WaitForSeconds(0.2f);
        shot = true;
    }
}
