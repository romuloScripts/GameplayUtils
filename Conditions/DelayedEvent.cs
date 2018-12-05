using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class DelayedEvent : MonoBehaviour {

	public float delay;
	public UnityEvent delayedEvent;

	private Coroutine _c;
	
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
	
	public void InvokeUnscaledTime()
	{
		_c = this.Invoke(OnDelay, delay, true);
	}
	
	public void InvokeUnscaledTime(float delay){
		_c = this.Invoke(OnDelay, delay, true);
	}
	
	public void CancelUnscaledTime()
	{
		if(_c != null)
			StopCoroutine(_c);
	}
}
