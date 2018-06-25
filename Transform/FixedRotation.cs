using UnityEngine;
using System.Collections;

public class FixedRotation : MonoBehaviour {

	Vector3 rot;
	void Start () {
		rot = transform.eulerAngles;
	}
	
	public void LateUpdate () {
		transform.eulerAngles = rot;
	}
}
