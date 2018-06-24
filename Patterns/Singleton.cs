using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour{
	protected static T instance;	
	public static T Instancia{
		get{
			if(instance == null){
				instance = (T) FindObjectOfType(typeof(T));
				if (instance == null){
					GameObject obj = new GameObject();
					instance = obj.AddComponent<T>();
				}	
			} return instance;
		}
	}	
}

