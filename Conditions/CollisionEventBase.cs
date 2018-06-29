using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEventBase : MonoBehaviour {

	public UnityEvent onCollisionEnter;
	public bool destroy=true;
	public float delay=0;
	public bool useTag;
	public const string collisionTag="Player";

	protected bool triggered;

	public void ForceEvent(Collider col){
		StartCoroutine(Collision(col));
	}

	public IEnumerator Collision(Collider col){
		if((triggered && destroy) || (useTag && !col.CompareTag(collisionTag))) yield break;
		triggered = true;
		yield return new WaitForSeconds(delay);
		onCollisionEnter.Invoke();
		if(destroy){
			Destroy(this);
		}
	}
}
