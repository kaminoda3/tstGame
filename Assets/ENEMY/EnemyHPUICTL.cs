using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*モブのHPバーを表示向きをプレイヤーのカメラ目線にする*/
public class EnemyHPUICTL : MonoBehaviour
{
    //aim用のサブカメ取得
    [SerializeField] Camera sub;

    private void Update()
    {
        
    }

    private void LateUpdate()
    {
        //サブカメがアクティブではない時
        if (sub.gameObject.activeSelf == false)
        {
            transform.rotation = Camera.main.transform.rotation;
        }
        //サブカメがアクティブの時
        else if (sub.gameObject.activeSelf == true)
        {
            transform.rotation = sub.transform.rotation;
        }
    }
}
