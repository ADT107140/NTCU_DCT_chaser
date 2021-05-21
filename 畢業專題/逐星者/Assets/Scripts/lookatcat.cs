using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatcat : MonoBehaviour
{
    public Transform _cameraTransform;//摄像机位置
    float rotateX, rotateZ;//记录物体角度x,z变量;

    //Start初始化
    void Start()
    {
        rotateX = transform.eulerAngles.x;
        rotateZ = transform.eulerAngles.z;
    }

    void Update()
    {
        transform.LookAt(_cameraTransform);
        transform.eulerAngles = new Vector3(rotateX, transform.eulerAngles.y, rotateZ);//还原最开始的x,z;
    }
}
