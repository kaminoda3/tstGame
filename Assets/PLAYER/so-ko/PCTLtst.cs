using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*cubeにアタッチするスクリプト
　自機の操作に関するスクリプト*/
public class PCTLtst : MonoBehaviour
{
    [SerializeField] GameObject field;
    [SerializeField] float speed ;
    Vector3 Ppos;


    // Start is called before the first frame update
    void Start()
    {
        Ppos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
        }
    }
}
