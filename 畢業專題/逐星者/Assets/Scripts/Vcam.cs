using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;



public class Vcam : MonoBehaviour
{
    [HideInInspector]CinemachineVirtualCamera vcam1;
    [HideInInspector]CinemachineTransposer vcamtransposer01;
    // Start is called before the first frame update
    [HideInInspector]public static CinemachineVirtualCamera vcam2;
    [HideInInspector]public static CinemachineTransposer vcamtransposer02;
    [HideInInspector]public static CinemachineVirtualCamera vcam3;
    [HideInInspector]public static CinemachineTransposer vcamtransposer03;
    [HideInInspector]public static CinemachineVirtualCamera vcam4;
    [HideInInspector]public static CinemachineTransposer vcamtransposer04;
    
    [HideInInspector]public static CinemachineVirtualCamera vcam5;
    [HideInInspector]public static CinemachineTransposer vcamtransposer05;
    void Start()
    {
        vcam_01();
        VCam_02();
        VCam_03();
        VCam_04();
        VCam_05();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void vcam_01()
    {
        vcam1 = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        vcam1.m_Follow = GameObject.Find("2021-05-12-原始檔").transform;
        vcam1.m_LookAt = GameObject.Find("2021-05-12-原始檔").transform;
        
        vcamtransposer01 = vcam1.GetCinemachineComponent<CinemachineTransposer>();
        vcamtransposer01.m_FollowOffset = new Vector3(0,5,10);
    }
    void VCam_02()
    {
        vcam2 = GameObject.Find("CM vcam2").GetComponent<CinemachineVirtualCamera>();
        vcam2.m_Follow = GameObject.Find("2021-05-12-原始檔").transform;
        vcam2.m_LookAt = GameObject.Find("2021-05-12-原始檔").transform;
        
        vcamtransposer02 = vcam2.GetCinemachineComponent<CinemachineTransposer>();
        vcamtransposer02.m_FollowOffset = new Vector3(-3.7f,2.87f,3.55f);
    }
    void  VCam_03()
    {
        vcam3 = GameObject.Find("CM vcam3").GetComponent<CinemachineVirtualCamera>();
        vcam3.m_Follow = GameObject.Find("2021-05-12-原始檔").transform;
        vcam3.m_LookAt = GameObject.Find("2021-05-12-原始檔").transform;
        
        vcamtransposer03 = vcam3.GetCinemachineComponent<CinemachineTransposer>();
        vcamtransposer03.m_FollowOffset = new Vector3(-4.88f,3.5f,-1.22f);
    }
    void  VCam_04()
    {
        vcam4 = GameObject.Find("CM vcam4").GetComponent<CinemachineVirtualCamera>();
        vcam4.m_Follow = GameObject.Find("2021-05-12-原始檔").transform;
        vcam4.m_LookAt = GameObject.Find("2021-05-12-原始檔").transform;
        
        vcamtransposer04 = vcam4.GetCinemachineComponent<CinemachineTransposer>();
        vcamtransposer04.m_FollowOffset = new Vector3(-2.0f,2.5f,4.7f);
    }
    void  VCam_05()
    {
        vcam5 = GameObject.Find("CM vcam5").GetComponent<CinemachineVirtualCamera>();
        // vcam5.m_Follow = GameObject.Find("2021-05-12-原始檔").transform;
        vcam5.m_LookAt = GameObject.Find("2021-05-12-原始檔").transform;
        
        vcamtransposer05 = vcam5.GetCinemachineComponent<CinemachineTransposer>();
        vcamtransposer05.m_FollowOffset = new Vector3(0f,2.5f,4.7f);
    }
}
