using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class EventRepeater : MonoBehaviour {

	public float time=5;
	public UnityEvent onInvoke;
	
	void Start () {
		Begin();
	}

	public void Begin(){
		StartCoroutine(Repeat());
	}

	IEnumerator Repeat(){
		while(true){
			yield return new WaitForSeconds(time);
			onInvoke.Invoke();
		}
	}

}
