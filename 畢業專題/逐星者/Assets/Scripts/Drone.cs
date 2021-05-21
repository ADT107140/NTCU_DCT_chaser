using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Drone : MonoBehaviour
{
    public CinemachineVirtualCamera DroneCam;
    public CinemachineTrackedDolly dolly;
    public float flyspeed;
    
    [HideInInspector]public static bool isDrone;

    [HideInInspector]public GameObject dronetri;

    // Start is called before the first frame update
    void Start()
    {
        isDrone = false;
        DroneCam = GetComponent<CinemachineVirtualCamera>();
        dronetri = GameObject.Find("Timeline");
        dronecamdolly();       
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDrone)
        {
            DroneCam.m_Priority = 20;
            dronepos();
        }
    }
    void dronecamdolly()
    {
        dolly = DroneCam.GetCinemachineComponent<CinemachineTrackedDolly>();
        dolly.m_Path = GameObject.Find("DollyTrack1").GetComponent<CinemachineSmoothPath>();
    }
    public void dronepos()
    {
        if(dolly.m_PathPosition < 10)
        {
            flyspeed = Mathf.SmoothStep(0.0f,10f,0.2f);
            dolly.m_PathPosition += 10 * flyspeed * Time.deltaTime;   
        }
        if(dolly.m_PathPosition < 40 )
        {
            // flyspeed = Mathf.SmoothStep(1.0f,10f,0.2f);
            dolly.m_PathPosition += 10 * flyspeed * Time.deltaTime;   
        }
        if(dolly.m_PathPosition > 40)
        {   
            flyspeed = Mathf.SmoothStep(flyspeed,0.8f,0.1f);
            dolly.m_PathPosition += 10 * flyspeed * Time.deltaTime;   
        }
        if(dolly.m_PathPosition >= dolly.m_Path.PathLength)
        {
            Destroy(dronetri);
            DroneCam.m_Priority = 9;
        }
    }
}
