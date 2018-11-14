using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInput : MonoBehaviour {

    public static string input_name = "";
    public InputField inputField;

    // Use this for initialization
    void Start () {
		
	}
	
	public void get_input()
    {
        input_name = inputField.text;
        
        // 初期化
        inputField.text = "";
        Debug.Log("input_name = " + input_name);
    }
}
