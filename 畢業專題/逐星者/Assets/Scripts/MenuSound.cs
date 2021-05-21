using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MenuSound : MonoBehaviour
{

    public AudioMixer remix;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float sound_adjust = 0;
        if (Input.GetKey(KeyCode.PageUp))
        {
            sound_adjust = Time.deltaTime * 5f;
        }
        if (Input.GetKey(KeyCode.PageDown))
        {
            sound_adjust = -Time.deltaTime * 5f;
        }
        if (sound_adjust != 0)
        {
            float sounding;
            remix.GetFloat("主音量", out sounding);
            sounding = Mathf.Clamp(sounding + sound_adjust, -80, 20);
            remix.SetFloat("主音量", sounding);
        }
    }
    public void setbgm(float 音量)
    {
        remix.SetFloat("背景音量", 音量);
    }
    public void setEff(float 音量)
    {
        remix.SetFloat("音效", 音量);
    }
}
