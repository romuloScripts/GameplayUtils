using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollision : MonoBehaviour{

	public int damage = 10;

	void OnCollisionEnter2D(Collision2D collision){
		//Debug.Log(collision.gameObject.GetInstanceID() + " "+ collision.gameObject.name);
        var hit = collision.gameObject;
		var health = hit.GetComponent<Health>();
		if (health != null){
			health.TakeDamage(damage);
		}
		Destroy(gameObject);
    }
}
