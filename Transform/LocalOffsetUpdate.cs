using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LocalOffsetUpdate : MonoBehaviour {

    [Range(0,1)]
    public float offset;
    public float vel = 1;
    public AnimationCurve anim;
    public Vector3 localPos, localPos2;
    public new Transform transform;
    public Transform posTransform;

    Vector3 posIni;

    [System.Serializable] public class FloatEvent : UnityEvent<float> { }
    public FloatEvent onSetValue;

#if UNITY_EDITOR
    public bool validate = true;

    void OnValidate() {
        if (!validate || Application.isPlaying)
            return;
        if(!transform) transform = GetComponent<Transform>();
        transform.localPosition = Vector3.LerpUnclamped(localPos, localPos2, anim.Evaluate(offset));
    }
#endif

    private void Awake() {
        if(!transform) transform = GetComponent<Transform>();
        posIni = transform.localPosition;
    }

    private void LateUpdate() {
        setPos();
    }

    public void setPos() {
        if(posTransform){
            Vector3 local = posTransform.position - transform.position;
            localPos2.x = local.x;
            localPos2.z = local.z;
        }
        transform.localPosition = posIni + Vector3.MoveTowards(transform.localPosition, Vector3.LerpUnclamped(localPos, localPos2, anim.Evaluate(offset)),vel*Time.deltaTime);
    }

    public void SetOffset(float n) {
        offset = n;
        onSetValue.Invoke(n);
    }
}
