using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mission1 : MonoBehaviour
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
    public int index1;
    public float textSpeed;

    [Header("頭像")]
    public Sprite face01, face02;

    bool go;
    bool textFininshed;
    bool canceltyping;
    List<string> textlist = new List<string>();

    public GameObject missionpanel;
    
    void Awake()
    {
        

        //missionpanel.SetActive(false);
    }
    private void OnEnable()
    {

        // textLabel.text = textlist[index];
        //index++;
        index1 = 0;
        getTextFormFile(textfile);
        
        

    }
    // Update is called once per frame
    private void FixedUpdate()
    {

    }
    private void Start()
    {
        
        if(GLOBAL.missionNum == 1)
        {
            textFininshed = true;
            StartCoroutine(SetTextUi());
        }
    }
    void Update()
    {
        while (go)
        {
            if (GLOBAL.missionNum == 1)
            {
                textFininshed = true;
                StartCoroutine(SetTextUi());
                GameObject.Find("dialog").GetComponent<dialogsystem>().enabled = false;
                Debug.Log("555888");
                break;
            }
        }
        if (GLOBAL.missionNum == 1)
        {
            

            if (Input.GetKeyDown(KeyCode.E) && index1 == textlist.Count) //對話到最後一行
            {

                if (GLOBAL.missionNum == 1)
                {
                    //  getTextFormFile(text3);
                    //  missionpanel.SetActive(false);
                    GLOBAL.missionNum = 2;

                }
                gameObject.SetActive(false);
                index1 = 0;


                return;
            }

            //if (Input.GetKeyDown(KeyCode.R) && textFininshed)
            //{
            //    //textLabel.text = textlist[index];
            //    //index++;
            //    StartCoroutine(SetTextUi());
            //}

            if (Input.GetKeyDown(KeyCode.E))
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
        


    }
    IEnumerator SetTextUi()
    {
        textFininshed = false;
        cattextLabel.text = "";
        sheeptextLabel.text = "";
        stonetextLabel.text = "";
        switch (textlist[index1])
        {
            case "CAT":
                //  faceImage.sprite = face01;
                catpanel.SetActive(true);
                sheeppanel.SetActive(false);
                stonepanel.SetActive(false);
                index1++;
                break;
            case "SHEEP":
                //   faceImage.sprite = face02;
                catpanel.SetActive(false);
                sheeppanel.SetActive(true);
                stonepanel.SetActive(false);
                index1++;
                break;
            case "STONE":
                //   faceImage.sprite = face02;
                catpanel.SetActive(false);
                sheeppanel.SetActive(false);
                stonepanel.SetActive(true);
                index1++;
                break;
        }

        //for(int i = 0; i < textlist[index].Length; i++)
        //{
        //    textLabel.text += textlist[index][i];

        //    yield return new WaitForSeconds(textSpeed);
        //}
        int letter = 0;
        while (!canceltyping && letter < textlist[index1].Length - 1)
        {
            cattextLabel.text += textlist[index1][letter];
            sheeptextLabel.text += textlist[index1][letter];
            stonetextLabel.text += textlist[index1][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }
        cattextLabel.text = textlist[index1];
        sheeptextLabel.text = textlist[index1];
        stonetextLabel.text = textlist[index1];
        canceltyping = false;
        textFininshed = true;
        index1++;
    }
    void getTextFormFile(TextAsset file)
    {
        textlist.Clear();
        index1 = 0;

        var linedata = file.text.Split('\n');

        foreach (var line in linedata)
        {
            textlist.Add(line);
        }
    }
}
