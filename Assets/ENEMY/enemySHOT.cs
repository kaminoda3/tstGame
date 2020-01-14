using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*ボスの攻撃用のスクリプト*/
public class enemySHOT : MonoBehaviour
{
    //向きを変える砲塔部分
    [SerializeField] GameObject player = default;
    //ボスの弾
    [SerializeField] GameObject tama = default;
    //砲塔の親部分
    [SerializeField] GameObject cube = default;
    //発射地点
    [SerializeField] Transform muz = default;
    //砲塔の親
    [SerializeField] GameObject cylinder = default;
    //弾速
    [SerializeField] float speed = default;
    //発射判定
    public bool shot = true;
    //発射終了後のcooltime用
    private bool cool = true;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ボスとプレイヤーの位置関係を計算
        Vector3 aim =  cube.transform.position - player.transform.position;
        //ボスとプレイヤーの角度を取得
        var look = Quaternion.LookRotation(aim);
        //オブジェクトの角度を変更
        cylinder.transform.localRotation = look;

        //３秒後起動
        Invoke("sho", 3f);
        if (shot == false)
        {
            //２秒後起動
            Invoke("des", 2f);
        }
    }
    void sho()
    {
        if (shot == true)
        {
            if (cool == true)
            {
                cool = false;
                //弾生成
                GameObject tamas = Instantiate(tama) as GameObject;
                //方向と速度
                Vector3 force = muz.gameObject.transform.forward * -speed;
                //前方に力を加える
                tamas.GetComponent<Rigidbody>().AddForce(force);
                //発射地点
                tamas.transform.position = muz.position;
                StartCoroutine("co");
            }
            StartCoroutine("stp1");
        }
    }
    //オブジェクトを非アクティブにする
    void des()
    {
        cube.gameObject.SetActive(false);
    }

    //発射停止
    IEnumerator stp1()
    {   //１秒経過してから判定を変える
        yield return new WaitForSeconds(1f);
        shot = false;
    }
    //発射間隔
    IEnumerator co()
    {
        yield return new WaitForSeconds(0.1f);
        cool = true;
    }


}
