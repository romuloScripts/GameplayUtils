using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CollisionEnter : CollisionEventBase {

	void OnCollisionEnter (Collision col){
		StartCoroutine(Collision(col.collider));
	}
}
