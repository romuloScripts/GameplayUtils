using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BetterJump : MonoBehaviour
{
	public float fallMultiplayer = 2.5f;
	public float lowJumpMultiplayer = 2f;
	public string jumpButton = "Jump";
	public Rigidbody2D rb;

	private void Reset() {
		rb = GetComponent<Rigidbody2D>();	
	}

	void FixedUpdate () {
		if(rb.velocity.y <0)
		{
			rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplayer-1) * Time.fixedDeltaTime;
		}else if(rb.velocity.y >0 && !Input.GetButton(jumpButton)){
			rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplayer-1) * Time.fixedDeltaTime;
		}

	}
}
