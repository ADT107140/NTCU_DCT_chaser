using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gifan : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] animatedImages;
    public Image anImageObj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anImageObj.sprite =  animatedImages [(int)(Time.time*3)%animatedImages.Length];
    }
}
