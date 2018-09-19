using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

    public Camera cam;

    void Awake(){
       cam = Camera.main;
    }

    void Update () {
        transform.LookAt(cam.transform);
    }
}