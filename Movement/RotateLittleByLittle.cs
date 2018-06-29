using UnityEngine;
using System.Collections;

public class RotateLittleByLittle : MonoBehaviour {

	public enum UpdateType{
		Update,
		FixedUpdate,
		Lateupdate,
	}
	public float delay = 1;
	public Vector3 axis = Vector3.right;
	public UpdateType updateType = UpdateType.FixedUpdate;

	private float rot;
	private Vector3 rotation;
	
	void Start () {
		rotation = transform.eulerAngles;
		randomRot ();
		InvokeRepeating("randomRot",0,delay);
	}

	void FixedUpdate () {
	
		if(updateType != UpdateType.FixedUpdate) return;
		Rotate();
	}
	
	void Update()
	{
		if(updateType != UpdateType.Update) return;
		Rotate();
	}
	
	void LateUpdate(){
		if(updateType != UpdateType.Lateupdate) return;
		Rotate();
	}
	
	void randomRot(){
		rot += Random.Range(5f, 25f);
	}
	
	void Rotate(){
		transform.eulerAngles = rotation;
		transform.Rotate(axis, rot);
	}
	
	
}
