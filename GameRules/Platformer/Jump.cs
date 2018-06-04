using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Jump :MonoBehaviour {

	public float velocity=5;
	public string jumpButton = "Jump";
	public Rigidbody2D rb;

	private void Reset() {
		rb= GetComponent<Rigidbody2D>();	
	}

	void Update () {
		if(Input.GetButtonDown(jumpButton)){
			rb.velocity = Vector2.up*velocity;
		}
	}
}
