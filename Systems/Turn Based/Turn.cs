using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Turn", menuName = "TurnBased/Turn", order = 0)]
public class Turn : ScriptableObject {
	public Turn[] childTurns;
	public UnityEvent onBegin;
	public UnityEvent onEnd;

	[SerializeField]
	private int idChildTurn;
	[SerializeField]
	private bool loop;
	private bool end;

    public int IdChildTurn{
        get{
            return idChildTurn;
        }set{
            idChildTurn = value;
        }
    }

    public virtual void Begin(){
		ResetId();
		onBegin.Invoke();
		if(childTurns != null && IdChildTurn < childTurns.Length)
			childTurns[IdChildTurn].Begin();
	}

	public virtual void MoveNext(){
		if(childTurns != null && IdChildTurn < childTurns.Length){
			childTurns[IdChildTurn].MoveNext();
			if(childTurns[IdChildTurn].end){
				IdChildTurn++;
				if(IdChildTurn >= childTurns.Length){
					End();
				}else{
					childTurns[IdChildTurn].Begin();
				}
			}
		}else{
			End();
		}
	}

	public virtual void End(){
		end = true;	
		onEnd.Invoke();
		if(loop) Begin();
	}

    private void ResetId(){
		end = false;
		IdChildTurn = 0;
    }

	public int GetChildID(int depth){
		if(depth <=0)
			return idChildTurn;
		else{
			int i = IdChildTurn >= childTurns.Length?childTurns.Length-1:IdChildTurn;
			return childTurns[i].GetChildID(depth-1);
		}
	}

	public int GetNumChild(int depth){
		if(depth <=0)
			return childTurns.Length;
		else{
			int i = IdChildTurn >= childTurns.Length?childTurns.Length-1:IdChildTurn;
			return childTurns[i].GetNumChild(depth-1);
		}
	}
}
