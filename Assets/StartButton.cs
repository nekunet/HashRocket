using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {

    void Start()
    {

    }

    // ボタンをクリックした時の処理
    public void OnClick()
    {
        GameObject.Find("Canvas").transform.Find("Panel").gameObject.SetActive(true);
        Debug.Log("StartButton click!");
    }
}
