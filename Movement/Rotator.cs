using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator: MonoBehaviour {

    public float multiplier = 1;
    public float vel = 10;
    public Vector3 vectorUp = Vector3.up;

    private void Update() {
        transform.Rotate(vectorUp, vel * multiplier* Time.deltaTime);
    }
}
