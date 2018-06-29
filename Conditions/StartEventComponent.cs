using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TriggerStart : MonoBehaviour {

	public UnityEvent onStart;
	void Start () {
		onStart.Invoke();
	}
}
