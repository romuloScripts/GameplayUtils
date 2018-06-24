using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ExtensionMethods{

	public static Coroutine Invoke(this MonoBehaviour monoBehaviour, Action action, float time){
   		return monoBehaviour.StartCoroutine(InvokeImpl(action, time));
	}

	private static IEnumerator InvokeImpl(Action action, float time){
   		yield return new WaitForSeconds(time);
		action();
	}
}
