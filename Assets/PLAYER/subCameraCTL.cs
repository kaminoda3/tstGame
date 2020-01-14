using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subCameraCTL : MonoBehaviour
{   //砲身の根本のオブジェクト
    [SerializeField] GameObject a;
    //砲塔
    [SerializeField] GameObject b;

    [Range(0.1f, 10f)]
    public float look=5f;
    [Range(0.1f, 1f)]
    public float lookSmooth = 0.1f;

    private Vector2 minmax = new Vector2(-65, 65);
    public Vector2 minmax2 = new Vector2(-40, 40);
    private float yrot;
    private float xrot;

    private float currentYRot;
    private float currentXRot;

    private float xRotVelocity;
    private float yRotVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //
    void Update()
    {
        yrot += Input.GetAxis("Mouse X") * look;
        xrot -= Input.GetAxis("Mouse Y") * look;

        //角度制限
        xrot = Mathf.Clamp(xrot, minmax.x, minmax.y);
        /*ウェブ参照理解が追いつかない*/
        currentXRot = Mathf.SmoothDamp(currentXRot, xrot, ref xRotVelocity, lookSmooth);
        currentYRot = Mathf.SmoothDamp(currentYRot, yrot, ref yRotVelocity, lookSmooth);

        a.transform.localRotation = Quaternion.Euler(currentXRot, 0, 0);
        b.transform.localRotation = Quaternion.Euler(0, currentYRot, 0);

        transform.rotation = Quaternion.Euler(currentXRot, currentYRot, 0);
    }
}
