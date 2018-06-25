using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CheckIdMemEvent : MonoBehaviour {
	
	public int idMem;
	public UnityEvent onSmaller 	;
	public UnityEvent onEqual;
	public UnityEvent onBigger;
	
	void Start () {
		if(idMem < CheckPointManager.getIdMem())
			OnSmaller();
		else if(idMem > CheckPointManager.getIdMem())
			OnBigger();
		else
			OnEqual();
	}
	
	public void OnSmaller(){
		onSmaller.Invoke();
	}

	public void OnEqual(){
		onEqual.Invoke();
	}

	public void OnBigger(){
		onBigger.Invoke();
	}
}
