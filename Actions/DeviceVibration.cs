using UnityEngine;
using System.Collections;

public static class DeviceVibration {
	
	#if UNITY_ANDROID && !UNITY_EDITOR
	public static AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
	public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
	public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
	#else
	public static AndroidJavaClass unityPlayer;
	public static AndroidJavaObject currentActivity;
	public static AndroidJavaObject vibrator;
	#endif
	
	public static void Vibrate(){
		#if UNITY_ANDROID && !UNITY_EDITOR
		if (GetAndroid())
			vibrator.Call("vibrate");
		else
			Handheld.Vibrate();
		#endif
	}
	
	
	public static void Vibrate(long milliseconds){
		#if UNITY_ANDROID && !UNITY_EDITOR
		if (GetAndroid())
			vibrator.Call("vibrate", milliseconds);
		else
			Handheld.Vibrate();
		#endif
	}
	
	public static void Cancel(){
		if (GetAndroid())
			vibrator.Call("cancel");
	}
	
	private static bool GetAndroid(){
		#if UNITY_ANDROID && !UNITY_EDITOR
		return true;
		#else
		return false;
		#endif
	}
}