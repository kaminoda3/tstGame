using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*空のオブジェクトにアタッチするスクリプト
* 照準をマウスカーソルの位置に移動させる*/
public class AIMCTL : MonoBehaviour
{
    [SerializeField] 　Image AIM;

    void Update()
    {   //画像の座標をマウスカーソルの位置にする
        //AIM.rectTransform.position = Input.mousePosition;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 60))
        {
            //カーソルの位置に敵が居た場合に色を変える
            string hitname = hit.transform.gameObject.tag;
            if (hitname == "enemy")
            {
                AIM.color = new Color(1f, 0, 0, 1f);
            }
            else
            {
                AIM.color = new Color(0, 1f, 1f, 1f);
            }
        }
        else
        {
            AIM.color = new Color(0, 1f, 1f, 1f);
        }

    }
}

