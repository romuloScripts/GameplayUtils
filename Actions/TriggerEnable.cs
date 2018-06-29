using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnable : MonoBehaviour {

	public Behaviour[] setEnable;   
	public Behaviour[] setDisable; 
	public GameObject[] setActiveTrue;   
	public GameObject[] setActiveFalse;

	public void ActiveAndEnable() {
		EnableAll ();
		ActiveAll ();
	} 

	public void DeactiveAndDisable(){
		DisableAll ();
		DeactiveAll ();
	}

	public void EnableAll(){
		for (int i=0; i<setEnable.Length; i++) {
			if (setEnable[i]!=null)
				setEnable[i].enabled = true;
		}
	}	

	public void DisableAll(){
		for (int i=0; i<setEnable.Length; i++) {
			if (setEnable [i] != null)
				setEnable [i].enabled = false;
		}
	}

	public void ActiveAll(){
		for (int i=0; i<setDisable.Length; i++) {
			if (setDisable[i]!=null)
				setDisable[i].enabled = true;
		}
	}

	public void DeactiveAll() {
		for (int i=0; i<setDisable.Length; i++) {
			if (setDisable[i]!=null)
				setDisable[i].enabled = false;
		}
	} 
}
