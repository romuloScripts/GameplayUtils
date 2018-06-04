using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shoot : MonoBehaviour {

	public Rigidbody2D bulletPrefab;
    public Transform bulletSpawn;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
            Fire();
        }	
	}

    void Fire(){
        var bullet = Instantiate<Rigidbody2D>(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        bullet.velocity = bullet.transform.up * 6;
        Destroy(bullet, 2.0f);    
    }
}
