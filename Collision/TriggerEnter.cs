using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TriggerEnter : CollisionEventBase {

	void OnTriggerEnter (Collider col){
		StartCoroutine(Collision(col));
	}
}
