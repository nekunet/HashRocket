﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashing : MonoBehaviour {

    public Text Qtext;
    float a_color;
    bool flag_G;

    // Use this for initialization
    void Start()
    {
        a_color = 255;
    }
    // Update is called once per frame
    void Update()
    {
        //テキストの透明度を変更する
        Qtext.color = new Color(149f / 255f, 223f / 255f, 236f / 255f, a_color);
        if (flag_G)
            a_color -= Time.deltaTime;
        else
            a_color += Time.deltaTime;
        if (a_color < 0)
        {
            a_color = 0;
            flag_G = false;
        }
        else if (a_color > 1)
        {
            a_color = 1;
            flag_G = true;
        }
    }
}
