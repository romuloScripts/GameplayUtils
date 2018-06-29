using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class TriggerEnterExit : MonoBehaviour {

	public UnityEvent onEnter;
	public UnityEvent onExit;

	void OnTriggerEnter (Collider col) {
		onEnter.Invoke();
	}

	void OnTriggerExit (Collider col) {
		onExit.Invoke();
	}

}
