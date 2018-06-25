using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ArrayEvents : MonoBehaviour {

	public UnityEvent[] events;

	private int id = -1;

	public void NextEvent() {
		id++;
		if (id >= events.Length)
			return;
		events[id].Invoke();
	}

}
