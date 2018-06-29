using UnityEngine;
using System.Collections;

public class AutoSinCosMovement : MonoBehaviour {

	public Vector2 vel,amplitude;
	public float lerp=1;
	public bool randomIni;
	
	Vector3 posIni, newPos;
	float l,sum;
	
	void Start(){
		newPos = Vector3.zero;		
		posIni = transform.localPosition;
		if(randomIni)
			sum=Random.Range(-2f,7f);
	}
	
	void FixedUpdate () {
		newPos.x = Mathf.Sin(Mathf.PI * Time.time*vel.x+sum)*amplitude.x*l*Time.deltaTime;
		newPos.y = Mathf.Cos(Mathf.PI * Time.time*vel.y+sum)*amplitude.y*l*Time.deltaTime;
		transform.localPosition = posIni + newPos ;
		l = Mathf.Lerp(l,1,lerp*Time.deltaTime);
	}
}
