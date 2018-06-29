using UnityEngine;
using System.Collections;

public class CopyPosition : MonoBehaviour {

	public Transform p;

	public void SetPosition(){
		transform.position = p.position;
	}

	public void SetPosition(Transform pos){
		transform.position = pos.position;
	}
	
}
