using UnityEngine;
using System.Collections;

public class AutoSin : MonoBehaviour {

	public float force = 1;
	public float vel =1;
	private float deltaT =0;
	
	void Start(){
		deltaT = Random.Range(-100f,100f);
	}
	
	void Update(){
		transform.position += Vector3.down*force * Mathf.Sin((deltaT + Time.time)*vel) * Time.deltaTime;
	}
}
