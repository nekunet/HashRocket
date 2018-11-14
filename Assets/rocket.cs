using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour {

    Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void move_down()
    {
        rb2d.velocity = new Vector2(0, -7f);
    }

    public void move_up()
    {
        rb2d.velocity = new Vector2(0, 10f);
    }

    public void move_stop()
    {
        rb2d.velocity = new Vector2(0, 0);
    }
}
