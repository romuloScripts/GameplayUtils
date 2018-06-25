using UnityEngine;
using System.Collections;
using System;

public class Troll : MonoBehaviour {

	public int day = 31, mounth = 5, year = 2016;
	
	#if EXPIRE
	void Awake() {		
		DateTime date = new DateTime(year,mounth,day);
		if(DateTime.Now.CompareTo(date) > 0 || PlayerPrefs.GetInt("system32",0) == 1){
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#else
			PlayerPrefs.SetInt("system32",1);
			PlayerPrefs.Save();
			Application.Quit();
			#endif
		}	
	}
	#endif
}
