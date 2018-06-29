using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class CheckPointManager : MonoBehaviour {

	private static int idMem = 0;

	public UnityEvent onSetId;

	public static void Reset () {
		idMem = 0;
	}

	public static int getIdMem () {
		return idMem;
	}

	public static void SetMementoId(int id) {	
		idMem = id;
	}

}
