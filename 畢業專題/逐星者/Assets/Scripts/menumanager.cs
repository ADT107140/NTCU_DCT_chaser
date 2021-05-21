using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menumanager : MonoBehaviour
{
    public static Animator menucon;
    public static float page1 = 0;
    float test;
    

    // Start is called before the first frame update
    void Start()
    {
        page1=0;
        menucon = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (test == 1)
            page1 = 1;
        if (test == 2)
            page1 = 0;
    }
    public static void gogogo()
    {

        menucon.SetTrigger("go");
        page1 = 1;
        Debug.Log("成功拉");

    }
    public static void baack()
    {
        menucon.SetTrigger("back");
        page1 = 0;
        Debug.Log("回去了");
    }
    public void forgo()
    {
        gogogo();
        test = 1;
    }
    public void forback()
    {
        baack();
        test = 2;
    }
}
