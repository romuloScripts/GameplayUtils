﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class BehaviourExtensions
{
    public static void SetEnable(this Behaviour component, bool enable){
   		component.enabled = enable;
	}

    public static void SetActiveGO(this Behaviour component,bool enable){
   		component.gameObject.SetActive(enable);
	}

    public static void SetEnableCollider2D(this Component component, bool enable){
        component.GetComponent<Collider2D>()?.SetEnable(enable);
    }
}

public static class InvokeExtension{

	public static Coroutine Invoke(this MonoBehaviour monoBehaviour, Action action, float time){
   		return monoBehaviour.StartCoroutine(InvokeImpl(action, time));
	}

	private static IEnumerator InvokeImpl(Action action, float time){
   		yield return new WaitForSeconds(time);
		action();
	}
}

public static class GameObjectExtensions  {

    public static bool ContainsLayer(this LayerMask layermask, GameObject gameObject) {
        return (1 << gameObject.layer | layermask) == layermask;
    }

    public static GameObject InstantiateTransform(this Transform transform, GameObject original) {
        return MonoBehaviour.Instantiate(original, transform.position, transform.rotation);
    }
}


public static class MovementExtensions{

    public static Vector3 GetDirBasedOnCam(this Transform camTransform, float v, float h){
        Vector3 camFoward = Vector3.Scale(camTransform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 move = v*camFoward + h* camTransform.right;
        return move;
	}

    public static bool CheckRotate360(this Transform player, float delayRotate, ref float timeRotate, ref float curAngleX, ref Vector3 lastFwd,ref float sign) {
        if (Time.time - timeRotate > delayRotate) {
            curAngleX = 0;
            timeRotate = Time.time;
            return false;
        }
        Vector3 curFwd = player.forward;
        // measure the angle rotated since last frame:
        float ang = Vector3.Angle(curFwd, lastFwd);
        if (ang > 0.01) { // if rotated a significant angle...
            if (Vector3.Cross(curFwd, lastFwd).y < 0) {
                ang = -1 * ang;
                sign = -1;
            } else sign = 1;
            curAngleX += ang; // accumulate in curAngleX...
            lastFwd = curFwd; // and update lastFwd
        }
        return Mathf.Abs(curAngleX) >= 360;
    }

    public static void TurnRotation(this Transform transform, Vector3 move, float rotationSpeed, Vector3 up){
        if(move.magnitude <=0f || ((transform.position+move) - transform.position) == Vector3.zero) return;
		Quaternion targetRot = Quaternion.LookRotation((transform.position+move) - transform.position,up);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, move.magnitude * rotationSpeed * Time.deltaTime);
    }

    public static void TurnRotation2D(this Transform transform,Vector2 direction, float speed=1){
        if (direction.magnitude != 0){
            float angle = Mathf.Atan2(direction.x, -1 * direction.y) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, q, speed * Time.deltaTime);
        }
    }

    public static void Move(this Rigidbody rigd, Vector3 move, float velMoviment = 1, Animator animator = null, string param = "Vel"){
        if (move.magnitude > 1f)
            move.Normalize();
        animator?.SetFloat(param, move.magnitude);
        rigd.velocity = move*velMoviment;
    }

    public static void MoveFoward(this Rigidbody rigd, Vector3 move, float velMoviment = 1, Animator animator = null, string param = "Vel"){
        if (move.magnitude > 1f)
            move.Normalize();
        animator?.SetFloat(param, move.magnitude);
        rigd.velocity = rigd.transform.forward * move.magnitude *velMoviment;
    }

    public static void Move2D(this Rigidbody2D rigd, Vector2 move, float velMoviment = 1, Animator animator = null, string param = "Speed"){
        if (move.magnitude > 1f)
            move.Normalize();
        animator?.SetFloat(param, move.magnitude);
        rigd.velocity = move*velMoviment;
    }

    public static void Move2DAddForce(this Rigidbody2D rigd, Vector2 move,  float velMoviment = 1, 
        ForceMode2D forceMode= ForceMode2D.Force, Animator animator = null, string param = "Speed"){
        if (move.magnitude > 1f)
            move.Normalize();
        animator?.SetFloat(param, move.magnitude);
        rigd.AddForce(move*velMoviment,forceMode);
    }

    public static void SetBodyType(this Rigidbody2D rigd, RigidbodyType2D rigidbodyType2D){
        rigd.bodyType = rigidbodyType2D;
    }
}
