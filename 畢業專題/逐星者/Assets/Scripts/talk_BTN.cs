using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talk_BTN : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;

    private void OnTriggerEnter(Collider other)
    {
        Button.SetActive(true);
        Debug.Log("887779952");
    }

    private void OnTriggerExit(Collider other)
    {
        Button.SetActive(false);
    }

    private void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            talkUI.SetActive(true);
        }
    }

}