using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SlowMotionData{
    public float slowFactor = 0.2f;
    public float slowLenght = 1.5f;

    public void DoSlowMotion(){
        TimeManager.DoSlowMotion(slowFactor, slowLenght);
    }
}


public class TimeManager: MonoBehaviour{

	public float pause=1;
    public float timeScale =1;
    public float scaleFactor = 1;

	public const float fixedDeltaTime = 0.02f;
	public static TimeManager timeManager;

	public float TimeScale{
		get{
			return timeScale;
		}set{
            timeScale = value;
            if(pause != 0)
			    Time.timeScale = timeScale * scaleFactor;
		}
	}

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        UnPause();
        scaleFactor=1;
        TimeScale = 1;
    }

    static void CreateInstance() {
        GameObject g = new GameObject("TimeManager", typeof(TimeManager));
        timeManager = g.GetComponent<TimeManager>();
        SceneManager.sceneLoaded += timeManager.OnSceneLoaded;
        DontDestroyOnLoad(g);
    }

    public static TimeManager GetInstance() {
        if (!timeManager) {
            CreateInstance();
        }
        return timeManager;
    }

    public void PauseInstance(){
       Pause();
    }

    public void UnPauseInstance(){
       UnPause();
    }

    public static void Pause(){
        GetInstance().pause = 0;
        Time.timeScale = 0;
    }

    public static void UnPause(){
        GetInstance().pause = 1;
        Time.timeScale = GetInstance().timeScale * GetInstance().scaleFactor;
    }  

    public static void DoSlowMotion(float slowFactor =0.5f,float slowLenght =0.5f, float timeIni=0) {
		GetInstance().StartCoroutine(GetInstance().SlowMotion(slowFactor,slowLenght, timeIni));
	}

    public static void DoMoveTowardsTime(float slowFactor = 0.5f, float slowSpeed = 1) {
        GetInstance().MoveTowardsTime(slowFactor, slowSpeed);
    }

    public static void DoFramePause(float timeIni = 0.03f, float timePause = 0.08f, float newScale=0) {
        GetInstance().StartCoroutine(GetInstance().FramePause(timeIni, timePause,newScale));
    }

    void MoveTowardsTime(float slowFactor = 0.5f, float slowSpeed = 1) {
        if(pause == 0) return;
        scaleFactor = Mathf.MoveTowards(scaleFactor, slowFactor, slowSpeed * Time.unscaledTime);
        TimeScale = Mathf.Clamp(TimeScale, 0, 1);
        Time.fixedDeltaTime = Time.timeScale * fixedDeltaTime;
    }

    public static void StopCoroutines() {
        GetInstance().StopAllCoroutines();
    }

    IEnumerator SlowMotion(float slowFactor,float slowLenght,float timeIni) {
        if(timeIni >0)
            yield return GetInstance().StartCoroutine(WaitForSecondsRealtimeWithPause(timeIni));
        TimeScale = slowFactor;
		while (TimeScale != 1) {
			TimeScale += (1f / slowLenght) * Time.unscaledDeltaTime * pause;
			TimeScale = Mathf.Clamp (TimeScale, 0, 1);
			Time.fixedDeltaTime = Time.timeScale * fixedDeltaTime;
			yield return null;
		}
	}
		
	IEnumerator FramePause(float timeIni, float timePause, float newScale=0){
		yield return GetInstance ().StartCoroutine (WaitForSecondsRealtimeWithPause (timeIni));
		TimeScale = newScale;
        Time.fixedDeltaTime = Time.timeScale * fixedDeltaTime;
		yield return GetInstance ().StartCoroutine (WaitForSecondsRealtimeWithPause (timePause));
		TimeScale = 1;
        Time.fixedDeltaTime = Time.timeScale * fixedDeltaTime;
	}

	IEnumerator WaitForSecondsRealtimeWithPause(float time){
		float t=0;
		while (t < time) {
			t += Time.unscaledDeltaTime * pause; 
			yield return null;
		}
	}

	
}
