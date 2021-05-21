using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton2 : MonoBehaviour
{
    [SerializeField] MenuButtonController2 menuButtonController;
    [SerializeField] int thisIndex;
    public GameObject undo;
    public GameObject pick;

    public GameObject loadscreen;
    public Slider slider;
    public Text progresstext;
    public AudioSource click_eff;

    // Update is called once per frame
    private void Start()
    {
        click_eff = GetComponent<AudioSource>();
    }
    void Update()
    {

        
        //Debug.Log(page);
        if (menuButtonController.index == thisIndex)
        {
            undo.SetActive(false);
            pick.SetActive(true);
            if (Input.GetAxis("Submit") == 1)
            {
                click_eff.Play();
                if (thisIndex == 0)
                    //loadlevel(1);
                    if (thisIndex == 1)
                        Debug.Log("還沒做拉");
                if (thisIndex == 4)
                {
                    menumanager.baack();
                    menuButtonController.index = 0;
                }
                    



            }
        }
        else
        {
            undo.SetActive(true);
            pick.SetActive(false);
        }


    }
    public void OnMouseOver()
    {
        menuButtonController.index = thisIndex;
    }
    private void OnMouseEnter()
    {
        menuButtonController.playmusic();
    }
    public void OnMouseExit()
    {

        menuButtonController.index = 0;
    }


    public void loadlevel(int sceneIndex)
    {
        StartCoroutine(LoadAsync(sceneIndex));
    }
    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadscreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progresstext.text = progress * 100f + "%";
            yield return null;
        }
    }
}
