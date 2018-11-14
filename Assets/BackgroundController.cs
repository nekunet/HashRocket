using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using USEncoder;

public class BackgroundController : MonoBehaviour {

    int mater;
    int result_mater;
    int move_mater;
    bool flg = false;
    static string name_data;
    GameObject refObj;
    rocket roc;
    GameObject[] roc_effect;
    public AudioClip audioClip1;
    private AudioSource audioSource;

    GameObject scoreText;

    static int hash1(int num)
    {
        long result = 0;
        result = (num * num * 59) % 10657;

        // とりあえずのエラー処理
        if (result < 0)
        {
            result = 3987;
        }

        return (int)result;
    }

    static int name_to_hash()
    {
        int name_hash = 0;

        //byte[] resultBytes = Encoding.GetEncoding("Shift-JIS").GetBytes(name_data.ToCharArray());
        byte[] resultBytes = ToEncoding.ToSJIS(name_data);

        // 変換した数値を足し込んでいく作業
        foreach (byte b in resultBytes)
        {
            name_hash += (int)b;
        }

        // 計算、返す
        name_hash = hash1(name_hash);
        return name_hash;
    }

    // Use this for initialization
    void Start () {

        GameObject.Find("Canvas").transform.Find("Panel").gameObject.SetActive(false);

        name_data = GetInput.input_name;
        refObj = GameObject.Find("rocket");
        roc_effect = GameObject.FindGameObjectsWithTag("rocketeffect");
        foreach (GameObject effect in roc_effect)
        {
            // 非表示
            effect.SetActive(false);
        }
        roc = refObj.GetComponent<rocket>();
        audioSource = gameObject.GetComponent<AudioSource>();
        mater = name_to_hash();
        result_mater = 0;
        move_mater = 0;
        Debug.Log(name_data + "のハッシュ値は" + mater);

        StartCoroutine(sleep());
    }

    IEnumerator sleep()
    {
        roc.move_down();
        yield return new WaitForSeconds(0.3f);
        roc.move_stop();
        yield return new WaitForSeconds(0.2f); 
        roc.move_up();
        yield return new WaitForSeconds(0.3f);
        roc.move_stop();
        //yield return new WaitForSeconds(0.6f);
        foreach (GameObject effect in roc_effect)
        {
            // 表示
            effect.SetActive(true);
        }
        audioSource.clip = audioClip1;
        audioSource.Play();
        flg = true;
    }

    IEnumerator result()
    {
        yield return new WaitForSeconds(0.7f);
        GameObject.Find("Canvas").transform.Find("Panel").gameObject.SetActive(true);

    }


    // Update is called once per frame
    void Update () {

        if (flg)
        {

            if (mater > 8000)
            {
                move_mater = 30;
            }
            else if (mater <= 8000 && mater > 4000)
            {
                move_mater = 20;
            }
            else if (mater <= 4000 && mater > 300)
            {
                move_mater = 10;
            }
            else if (mater <= 300 && mater > 100)
            {
                move_mater = 3;
            }
            else
            {
                move_mater = 1;
            }

            if (mater <= move_mater)
            {
                move_mater = mater;
            }
            mater -= move_mater;

            result_mater += move_mater;

            // スコアの更新
            GameObject.Find("Canvas").GetComponent<UIController>().AddMater(move_mater);

            
            // ロケットが止まったら
            if (mater == 0)
            {
                foreach (GameObject effect in roc_effect)
                {
                    // エフェクト非表示
                    effect.SetActive(false);
                }
                audioSource.Stop();
                // 結果の表示
                StartCoroutine(result());
                
            }


            if (move_mater <= 1)
            {
                transform.Translate(0, -0.00011f * mater, 0);
            }
            else
            {
                transform.Translate(0, -0.00005f * mater, 0);
            }



            // 背景画像の座標が一定値以上小さくなったとき
            if (transform.position.y < -7.5f)
            {
                // 元の位置に戻す
                transform.position = new Vector3(0, 7.5f, 0);
            }

        }


    }
}
