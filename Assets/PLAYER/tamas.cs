using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*弾にアタッチするスクリプト
　一定時間後に消えるようにする*/
public class tamas : MonoBehaviour
{
    [SerializeField] public int power = 1;

    void Update()
    {
        //５秒後に消滅する
        Destroy(this.gameObject, 5f);
    }

    //ぶつかったら消滅地面用
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
