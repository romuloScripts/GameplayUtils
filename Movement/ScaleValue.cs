using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleValue : MonoBehaviour {

    public AnimationCurve curve = AnimationCurve.Linear(0, 0, 1, 1);
    public float scaleMultiplayer=1;
    public float time = 1f;
    public float timeDisable = 1f;

    private float t=0;

    public void play() {
        t = 0f;
        enabled = true;
        apply();
    }

    void Update() {
        t += Time.deltaTime;
        apply();
    }

    void apply() {
        transform.localScale = Vector3.one * scaleMultiplayer * curve.Evaluate(t / time);
        if (timeDisable > 0f && t >= timeDisable)
            enabled = false;
    }
}
