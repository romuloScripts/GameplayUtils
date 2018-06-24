using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	protected static T instance;	
	public static T Instancia{
		get{
			while(instance == null){
				instance = (T) FindObjectOfType(typeof(T));
				//Debug.Log("procurou");	
				if (instance == null){
					//Debug.Log("criou");
					GameObject obj = new GameObject();
					//instancia = obj.AddComponent<T>();
					obj.AddComponent<T>();	
				}	
			} return instance;
		}
	}	
}

