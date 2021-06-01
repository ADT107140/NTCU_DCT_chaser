using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class loadscene : MonoBehaviour
{
    int currentindex;
    public int status;
    public float playerx;
    public float playery;
    public float playerz;
    public GameObject playercat;
    public void load()
    {
        currentindex = SceneManager.GetActiveScene().buildIndex;
        playerx = playercat.transform.position.x;
        playery = playercat.transform.position.y;
        playerz = playercat.transform.position.z;
        PlayerPrefs.SetInt("SaveScene", currentindex);
        PlayerPrefs.SetFloat("PosX", playerx);
        PlayerPrefs.SetFloat("PosY", playery);
        PlayerPrefs.SetFloat("PosZ", playerz);
    }
}
