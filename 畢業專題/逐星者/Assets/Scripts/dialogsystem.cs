using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogsystem : MonoBehaviour
{

    [Header("ui組件")]
    public Text cattextLabel;
    public Text sheeptextLabel;
    public Text stonetextLabel;
    //public Image faceImage;

    [Header("對話框")]
    public GameObject catpanel;
    public GameObject sheeppanel;
    public GameObject stonepanel;
    [Header("文本文件")]
    public TextAsset textfile;//mission =0
    public int index;
    public float textSpeed;
    public TextAsset text2;
    public TextAsset text3;

    [Header("頭像")]
    public Sprite face01, face02;

    public GameObject WASD;
    bool textFininshed;
    bool canceltyping;
    List<string> textlist = new List<string>();

    public GameObject missionpanel;
    
    void Awake()
    {
        
        getTextFormFile(textfile);
        //missionpanel.SetActive(false);
    }
    private void OnEnable()
    {
        
        // textLabel.text = textlist[index];
        //index++;
        textFininshed = true;
        StartCoroutine(SetTextUi());

    }
    // Update is called once per frame
    private void FixedUpdate()
    {

    }
    void Update()
    {
       // Debug.Log(textlist[index]);
        if (GLOBAL.missionNum == 0)
        {
            if (Input.GetKeyDown(KeyCode.R) && index == textlist.Count) //對話到最後一行
            {
                GLOBAL.missionNum = 1;
                Debug.Log(GLOBAL.missionNum);
                index = 0;
                textlist.Clear();
                textfile = null;
                WASD.SetActive(true);
                gameObject.SetActive(false);
                //GameObject.Find("dialog").GetComponent<dialogsystem>().enabled = false;
               // Debug.Log(GameObject.Find("dialog").name);
                
                return;
            }

            //if (Input.GetKeyDown(KeyCode.R) && textFininshed)
            //{
            //    //textLabel.text = textlist[index];
            //    //index++;
            //    StartCoroutine(SetTextUi());
            //}

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (textFininshed && !canceltyping)
                {
                    StartCoroutine(SetTextUi());
                }
                else if (!textFininshed && !canceltyping)
                {
                    canceltyping = true;
                }
            }
        }
        if (GLOBAL.missionNum == 1)
        {
            GameObject.Find("dialog").GetComponent<dialogsystem>().enabled = false;
        }


    }
    IEnumerator SetTextUi()
    {
        textFininshed = false;
        cattextLabel.text = "";
        sheeptextLabel.text = "";
        stonetextLabel.text = "";
        switch (textlist[index])
        {
            case "CAT":
                //  faceImage.sprite = face01;
                catpanel.SetActive(true);
                sheeppanel.SetActive(false);
                stonepanel.SetActive(false);
                index++;
                break;
            case "SHEEP":
                //   faceImage.sprite = face02;
                catpanel.SetActive(false);
                sheeppanel.SetActive(true);
                stonepanel.SetActive(false);
                index++;
                break;
            case "STONE":
                //   faceImage.sprite = face02;
                catpanel.SetActive(false);
                sheeppanel.SetActive(false);
                stonepanel.SetActive(true);
                index++;
                break;
            case "":
                catpanel.SetActive(false);
                sheeppanel.SetActive(false);
                stonepanel.SetActive(false);
                break;

        }

        //for(int i = 0; i < textlist[index].Length; i++)
        //{
        //    textLabel.text += textlist[index][i];

        //    yield return new WaitForSeconds(textSpeed);
        //}
        int letter = 0;
        while (!canceltyping && letter < textlist[index].Length - 1)
        {
            cattextLabel.text += textlist[index][letter];
            sheeptextLabel.text += textlist[index][letter];
            stonetextLabel.text += textlist[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }
        if(GLOBAL.missionNum == 0)
        {
            cattextLabel.text = textlist[index];
            sheeptextLabel.text = textlist[index];
            stonetextLabel.text = textlist[index];
            canceltyping = false;
            textFininshed = true;
            index++;
        }
        
    }
    void getTextFormFile(TextAsset file)
    {
        textlist.Clear();
        index = 0;

        var linedata = file.text.Split('\n');

        foreach (var line in linedata)
        {
            textlist.Add(line);
        }
        
    }
}
