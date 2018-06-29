using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLocalOffsetUpdate : MonoBehaviour {

	public LocalOffsetUpdate[] offsets;
	public int id;

	void LateUpdate () {
		offsets[id].setPos();
	}

	public void SetID(float i){
		id = (int)i;
	}

	public void setOffset(float value){
		offsets[id].SetOffset(value);
	}

}
