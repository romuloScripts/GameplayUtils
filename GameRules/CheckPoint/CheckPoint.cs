using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider))]
public class CheckPoint : MonoBehaviour {

	public int idMem = 0;
	public string collisionTag = "Player";
	public bool teleport=true;
	public Transform posCheckpoint, actor;

	void Start() {
		if (actor!=null) {
			if(teleport && idMem == CheckPointManager.getIdMem()) {
				actor.position = posCheckpoint.position;	
			}
			if (idMem <= CheckPointManager.getIdMem()){
				Destroy(gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.CompareTag(collisionTag) && idMem != CheckPointManager.getIdMem()) {
			CheckPointManager.SetMementoId(idMem);
			Destroy(gameObject);
		}
	}
}
