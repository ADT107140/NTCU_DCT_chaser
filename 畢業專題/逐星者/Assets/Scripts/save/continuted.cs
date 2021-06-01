using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class continuted : MonoBehaviour
{
    private int sceneToContinue;
    public void continuGame()
    {
        sceneToContinue = PlayerPrefs.GetInt("SaveScene");
        
        if (sceneToContinue != 0)
            SceneManager.LoadScene(sceneToContinue);
        else
            return;
        GLOBAL.saveloadscene = true;
    }
}
