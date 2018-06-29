using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TriggerExit : CollisionEventBase {

	public bool testBounds;
	private Collider thisCol;

	void Awake(){
		thisCol = GetComponent<Collider>();
	}

	void OnTriggerExit(Collider col){
		if(testBounds && !thisCol.bounds.Contains(col.bounds.center)) return;
		StartCoroutine(Collision(col));
	}
	
}
