using UnityEngine;
using System.Collections;

public class RotByMoviment: MonoBehaviour{

	public float multiplier=100;
	public Vector3 axe;
	
	private Vector3  lastPos;

	void Start(){
		lastPos = transform.position;
	}

	void Update(){
		CheckRotation();
	}
	
	public  void CheckRotation(float sign =1){
		float vel = sign * (lastPos -transform.position).magnitude * multiplier;
		transform.Rotate(axe*vel,Space.Self);
		lastPos = transform.position;
	}
}
