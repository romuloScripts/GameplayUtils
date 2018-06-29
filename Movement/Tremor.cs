using UnityEngine;
using System.Collections;

public class Tremor : MonoBehaviour {

    public float multiplayer=2;
    private Vector3 euler;
    public void DoTremor(float intensity) {
        transform.localPosition = Random.insideUnitSphere * intensity;
        euler = transform.localEulerAngles;
        euler.x = Random.value * intensity*multiplayer;
        euler.y = Random.value * intensity*multiplayer;
        euler.z = Random.value * intensity*multiplayer;
        transform.localEulerAngles = euler;
    }

    public void ResetPos() {
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;
    }
}
