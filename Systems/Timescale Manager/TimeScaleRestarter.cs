using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeScaleRestarter : MonoBehaviour {

	public static TimeScaleRestarter singleton;

	void Awake(){
		SetSingleton();
	}
	
	void OnEnable() {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
	
	void SetSingleton(){
		if(!singleton){ 
			singleton = this;
			DontDestroyOnLoad(gameObject);
		}else if(singleton != this){
			Destroy(this);
		}
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        SetSingleton();
		Time.timeScale = 1f;
    }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void OnAfterSceneLoadRuntimeMethod(){
		new GameObject("TimeScaleRestarter",typeof(TimeScaleRestarter));
	}
}
