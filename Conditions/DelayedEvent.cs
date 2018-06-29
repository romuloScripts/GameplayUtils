using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class DelayedEvent : MonoBehaviour {

	public float delay;
	public UnityEvent delayedEvent;
	
	public void Invoke(){
		Invoke("OnDelay",delay);
	}
	
	public void Invoke(float delay){
		Invoke("OnDelay",delay);
	}
	
	public void OnDelay(){
		delayedEvent.Invoke();
	}
}
