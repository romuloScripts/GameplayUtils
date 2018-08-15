using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCameraTrigger : MonoBehaviour {

	public float amount, duration;
	public bool onEnable;
	
	public void Shake(){
		Camera.main.GetComponent<CameraShake>().ShakeCamera(amount,duration);
	}

	private void OnEnable() {
		if(onEnable)
			Shake();
	}
}
