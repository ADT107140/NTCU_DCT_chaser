using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mission_sheep : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject e_an;
    public GameObject wall;
    public ParticleSystem leave;

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

    public GameObject panel;
    public GameObject panel2;
    bool textFininshed;
    bool canceltyping;
    List<string> textlist = new List<string>();


    void Awake()
    {
        
        getTextFormFile(textfile);
        //missionpanel.SetActive(false);
    }
    private void OnEnable()
    {
        textFininshed = true;
        StartCoroutine(SetTextUi());
        

    }
    void Start()
    {
        leave.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (GLOBAL.missionNum == 0)
        {
            index1 = 0;
        }
        if (GLOBAL.missionNum == 2)
        {
            panel.SetActive(false);
            panel2.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                panel2.SetActive(false);
                
                gameObject.SetActive(false);
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && index1 == textlist.Count) //對話到最後一行
            {

                if (GLOBAL.missionNum == 1)
                {
                    GLOBAL.missionNum = 2;

                }
                e_an.SetActive(false);
                wall.SetActive(false);
                index1 = 0;
                GLOBAL.missionNum = 2;
                
                
                 return;
            }

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
    IEnumerator SetTextUi()
    {
        leave.Play();
        textFininshed = false;
        cattextLabel.text = "";
        sheeptextLabel.text = "";
        stonetextLabel.text = "";
        switch (textlist[index1])
        {
            case "CAT":
                catpanel.SetActive(true);
                sheeppanel.SetActive(false);
                stonepanel.SetActive(false);
                index1++;
                break;
            case "SHEEP":
                catpanel.SetActive(false);
                sheeppanel.SetActive(true);
                stonepanel.SetActive(false);
                index1++;
                break;
            case "STONE":
                catpanel.SetActive(false);
                sheeppanel.SetActive(false);
                stonepanel.SetActive(true);
                index1++;
                break;
        }
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
