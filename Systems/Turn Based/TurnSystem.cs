using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour {

	public Turn motherTurn;

	public void IniTurn(){
		motherTurn.Begin();
	}

	public void NextTurn(){
		motherTurn.MoveNext();
	}
}
