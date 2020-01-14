using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class McameraCTL : MonoBehaviour
{
     Vector3 pos;
    [SerializeField] Transform cube = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(1))
        {
            pos = cube.position;
            float mouseX = Input.GetAxis("Mouse X");
            transform.RotateAround(pos, Vector3.up, mouseX * Time.deltaTime * 200);
        }
    }
}
