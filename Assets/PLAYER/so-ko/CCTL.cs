using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Camera操作
　自キャラに追従するもの
　右ドラッグによるカメラ視点の移動*/
public class CCTL : MonoBehaviour
{
    [SerializeField] GameObject cube;

    private Vector3 Cpos;


    public Vector2 rorationSpeed;
    private Vector2 lastMousePos;
    private Vector2 newAngle = new Vector2(0, 0);
    // Start is called before the first frame update
    void Start()
    {
        Cpos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        //transform.position = new Vector3(cube.transform.position.x + Cpos.x, Cpos.y, cube.transform.position.z + Cpos.z);


        if (Input.GetMouseButtonDown(1))
        {
            //カメラの角度を代入
            newAngle = transform.localEulerAngles;
            //マウスの座標を代入
            lastMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(1))
        {
            newAngle.y -= (lastMousePos.x - Input.mousePosition.x) * rorationSpeed.y;
            newAngle.x -= (Input.mousePosition.y - lastMousePos.y) * rorationSpeed.x;

            transform.localEulerAngles = newAngle;
            lastMousePos = Input.mousePosition;
            
        }
    }
}
