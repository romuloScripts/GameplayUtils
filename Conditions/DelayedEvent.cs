using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class DelayedEvent : MonoBehaviour {

	public float delay;
	public UnityEvent delayedEvent;
	
	public void Invoke(){
		Invoke(nameof(OnDelay),delay);
	}
	
	public void Invoke(float delay){
		Invoke(nameof(OnDelay),delay);
	}
	
	public void Cancel(){
		CancelInvoke(nameof(OnDelay));
	}
	
	public void OnDelay(){
		delayedEvent.Invoke();
	}
}
