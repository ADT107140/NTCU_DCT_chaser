using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class swipe : MonoBehaviour
{
    public GameObject scrollbar;
    float scroll_pos = 0;
    float[] pos;
    int posisi = 0;
    Image child;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void next()
    {
        if (posisi < pos.Length - 1)
        {
            posisi += 1;
            scroll_pos = pos[posisi];
        }
        else
            scroll_pos = 0;
    }
    public void prev()
    {
        if (posisi > 0)
        {
            posisi -= 1;
            scroll_pos = pos[posisi];
        }
        else
            scroll_pos = 1;
    }
    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];//3
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)//0-2
        {
            pos[i] = distance * i;
            // Debug.Log(pos[i] + "數");
        }
        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                    child = transform.GetChild(i).GetChild(0).GetComponent<Image>();
                    var tempColor = child.color;
                    tempColor.a = 1f;
                    child.color = tempColor;
                    posisi = i;
                }
            }
        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int a = 0; a < pos.Length; a++)
                {
                    if (a != i)
                    {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                        child = transform.GetChild(a).GetChild(0).GetComponent<Image>();
                        var tempColor = child.color;
                        tempColor.a = 0.1f;
                        child.color = tempColor;


                    }
                }
            }
        }


    }
}
