using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        GameObject.Find("Panel").SetActive(false);
    }
}
