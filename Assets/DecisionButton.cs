using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DecisionButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void OnClick()
    {
        StartCoroutine(sleep());
        //GameObject.Find("Canvas").transform.Find("Panel").gameObject.SetActive(false);
        //SceneManager.LoadScene("MainScene");
    }

    IEnumerator sleep()
    {
        yield return new WaitForSeconds(0.6f);  // 0.6秒待つ
        GameObject.Find("Canvas").transform.Find("Panel").gameObject.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }
}
