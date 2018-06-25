using UnityEngine;
using System.Collections;

public class DestroyColliders : MonoBehaviour {

	[ContextMenu("DestroyColliders")]
	public void DestroyAllChildColliders(){
		Collider[] cols = GetComponentsInChildren<Collider>();
		foreach (var item in cols) {
			DestroyImmediate(item);
		}
	}
}
