using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CountEvent : MonoBehaviour {

	public int num, numMax;
	public UnityEvent onMaxValue;

	public void OnMax() {
		onMaxValue.Invoke();
	}

	public void Add(int n=1) {
		if(num >= numMax)
			return;
		num+=n;
		if(num >= numMax)
			OnMax();
	}

	
}
