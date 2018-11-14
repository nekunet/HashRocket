using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTitleButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // ボタンをクリックした時の処理
    public void OnClick()
    {
        StartCoroutine(sleep());
    }

    IEnumerator sleep()
    {
        yield return new WaitForSeconds(0.6f);  // 0.6秒待つ
        SceneManager.LoadScene("title");
    }
}
