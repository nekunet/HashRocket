using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    /// ボタンをクリックした時の処理
    public void OnClick()
    {
        Application.Quit();
        Debug.Log("EndButton click!");
    }
}
