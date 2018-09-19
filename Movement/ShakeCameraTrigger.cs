using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class ShakeCameraTrigger : MonoBehaviour {

	public float amount, duration;
	public bool onEnable;
	
	private Camera cam;

	private void Awake() {
		cam = Camera.main;
	}

	public void Shake(){
		cam.GetComponent<CameraShake>().ShakeCamera(amount,duration);
		//Camera.main.DOShakePosition(duration,amount);
	}

	private void OnEnable() {
		if(onEnable)
			Shake();
	}
}
