using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class movement : MonoBehaviour
{
    public float speed = 10f;
    [HideInInspector]public float translation;
    [HideInInspector]public float rotation;
    [HideInInspector]public Transform camDir;
    [Header("當前速度")]private float  yVelocity = 0.0f;
    [Header("旋轉速度")]private float  rotaSpeed = 0.03f;
    // Start is called before the first frame update
    [HideInInspector]public Transform groundCheck;
    [HideInInspector]public float raylength = 0.5f;
    Rigidbody m_Rigidbody;

    [HideInInspector]public Vector3 HitNormal;
    [HideInInspector]public RaycastHit hit;

    public static bool isopen;
    public GameObject mybag;
    public GameObject wasd;

    void Start()
    {
        // 取得攝影機方向
        camDir = GameObject.Find("Main Camera").GetComponent<Transform>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        PlayerAnimator();
        OnSlope();
        openmybag();
    }
    
    #region Smooth旋轉 
    public void SmoothRotationY(float iTargetAngle)
    {
        transform.eulerAngles = new Vector3(0 , Mathf.SmoothDampAngle(transform.eulerAngles.y,iTargetAngle, ref yVelocity,rotaSpeed),0);
    }
    #endregion
    
    #region 角色移動
    public void Move()
    {
        if(GLOBAL.missionNum != 0)
        {

            translation = Input.GetAxis("Vertical");
            rotation = Input.GetAxis("Horizontal");
            if(Input.GetAxis("Vertical") != 0|| Input.GetAxis("Horizontal") != 0)
            {
                wasd.SetActive(false);
            }
            

            if (translation != 0f && rotation != 0f)
            {
                translation = translation * (Mathf.Sqrt(2) / 2);
                rotation = rotation * (Mathf.Sqrt(2) / 2);
            }
            Vector3 HitNormal = new Vector3(rotation, 0, translation).normalized;
            if (OnSlope())
            {
                HitNormal = Vector3.ProjectOnPlane(HitNormal, hit.normal).normalized;
                HitNormal = new Vector3(HitNormal.x, -HitNormal.y, HitNormal.z);
            }
            // print(HitNormal.y);
            transform.Translate(HitNormal * Time.deltaTime * speed, Camera.main.transform);
        }
        
        
        #region 朝攝影機移動
        if(translation > 0f)
        {
            SmoothRotationY(camDir.eulerAngles.y);
            
        }
        if(translation < 0f)
        {
            SmoothRotationY(camDir.eulerAngles.y + 180);
        }
        if(rotation > 0f)
        {
            SmoothRotationY(camDir.eulerAngles.y + 90);
        }
        if(rotation < 0f)
        {
            SmoothRotationY(camDir.eulerAngles.y + -90);
        }   
        #endregion
    }
    #endregion
    
    #region 按下方向鍵 執行走路動畫
    void PlayerAnimator()
    {
        if ( translation == 0f && rotation == 0f )
        {   
            this.gameObject.GetComponent<Animator>().SetBool("walk",false);
            // Debug.Log("0FFFF");
        }
        if ( translation != 0f || rotation != 0f)
        {    
            this.gameObject.GetComponent<Animator>().SetBool("walk",true);
            // Debug.Log(">>>>");
        }
        
    }
    #endregion
    
    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Invarea")
        {
            // Debug.Log("碰");
            Vcam.vcam2.m_Priority = 15;
        }
        if (collision.tag == "Leftarea")
        {
            // Debug.Log("碰");
            Vcam.vcam3.m_Priority = 15;
        }
        if (collision.tag == "Leftmiddle")
        {
            // Debug.Log("碰");
            Vcam.vcam4.m_Priority = 15;
        }
        if (collision.tag == "TOLeftarea")
        {
            // Debug.Log("碰");
            Vcam.vcam5.m_Priority = 15;
        }
        if (collision.tag == "Timeline")
        {
            // Debug.Log("碰");
            Drone.isDrone = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {   
        if (collision.tag == "Invarea")
        {
            // Debug.Log("離");
            Vcam.vcam2.m_Priority = 9;
        }
        if (collision.tag == "Leftarea")
        {
            // Debug.Log("碰");
            Vcam.vcam3.m_Priority = 9;
        }
        if (collision.tag == "Leftmiddle")
        {
            // Debug.Log("碰");
            Vcam.vcam4.m_Priority = 9;
        }
        if (collision.tag == "TOLeftarea")
        {
            // Debug.Log("碰");
            Vcam.vcam5.m_Priority = 9;
        }
    }
    #region 坡度判定 並給一個垂直於坡面的力
    bool OnSlope()
    {
        Ray ray = new Ray(groundCheck.position, Vector3.down);
        
        if(Physics.Raycast(ray, out hit, raylength))
        {
            float slopeAngle = Vector3.Angle(hit.normal,Vector3.up);
            
            if(slopeAngle > 1)
                return true;
        }
        return false;
    }
    #endregion
    void openmybag()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isopen = !isopen;
            mybag.SetActive(isopen);
            inventoryManager.RefreshItem();
        }
    }

}
