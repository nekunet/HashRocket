using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{

    int mater = 0;
    static string name_data;
    GameObject scoreMater;
    private AudioSource audioSource3;
    bool soundflg = true;


    public void AddMater(int add_num)
    {
        this.mater += add_num;
    }

    void Start()
    {
        name_data = GetInput.input_name;
        // name_data = "上原航汰"; // debnbug用
        this.scoreMater = GameObject.Find("Mater");
        audioSource3 = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        scoreMater.GetComponent<Text>().text = mater + "m";
        GameObject pa = GameObject.Find("Panel");
        if (pa)
        {
            if (soundflg)
            {
                audioSource3.Play();
                soundflg = false;
            }
            
            GameObject.Find("Panel").transform.Find("Nametext").GetComponent<Text>().text = name_data + "<color=\"white\"> さん\r\nの結果は...</color>";
            GameObject.Find("Panel").transform.Find("Matertext").GetComponent<Text>().text = mater + " <size=50>mです！</size>";

            if(mater > 8000)
            {
                GameObject.Find("Panel").transform.Find("hensati").GetComponent<Text>().text = "ハッシュ偏差値： <color=\"red\">高</color>";
            }else if(mater > 3000 && mater <= 8000)
            {
                GameObject.Find("Panel").transform.Find("hensati").GetComponent<Text>().text = "ハッシュ偏差値： <color=#F0E68C>中</color>";
            }else
            {
                GameObject.Find("Panel").transform.Find("hensati").GetComponent<Text>().text = "ハッシュ偏差値： <color=#89CEEB>低</color>";
            }

        }
    }

}