using UnityEngine;
using System.Collections;
using UnityEngine.Events;

[RequireComponent (typeof(AudioSource))]
public class MusicLoop : MonoBehaviour {

	[System.Serializable]
	public struct Loop {
		public float fadeIn;
		public float start;
		public float end;
		public float fadeOut;
	}


	public float startTime = 0f;
	[Range(0f, 1f)]
	public float volume = 1f;
	public int loop = 0;
	public AudioSource aud1;
	public Loop[] vLoop;
	public UnityEvent onCompleted;

	private bool fade = false;
	private float volumeAnt;
	private AudioSource aud2;

	void Awake () {
		if(!aud1)
			aud1 = GetComponent<AudioSource>();
		volumeAnt = aud1.volume;
		aud2 = gameObject.AddComponent<AudioSource>();
		aud2.ignoreListenerVolume =true;
		aud1.ignoreListenerVolume =true;
		aud2.clip = aud1.clip;
		aud2.loop = false;
		aud2.playOnAwake = false;
		aud2.volume = volumeAnt;
		aud1.time = startTime;
	}

	public virtual void onLoopCompleted(){
		onCompleted.Invoke();
	}

	void Update () {
		if (loop<0 || loop>=vLoop.Length) {
			aud1.volume = volumeAnt * volume;
			aud2.volume = volumeAnt * volume;
			return;
		}

		if (fade==false) {
			if (aud1.time > vLoop[loop].end - (vLoop[loop].start - vLoop[loop].fadeIn)) {
				fade = true;
				aud2.time = vLoop[loop].start - (vLoop[loop].end - aud1.time);
				aud2.Play();
			}
		}
		if (fade==true) {
			if (aud1.time > vLoop[loop].end) {
				fade = false;
				AudioSource aux = aud1;
				aud1 = aud2;
				aud2 = aux;
				onLoopCompleted();
			}
		}
		if (aud1.time > vLoop[loop].end)
			aud1.volume = calcFadeVol(aud1) * volumeAnt * volume;
		else
			aud1.volume = volumeAnt * volume;
		aud2.volume = calcFadeVol(aud2) * volumeAnt * volume;

	}

	public float calcFadeVol (AudioSource au) {
		float vol;
		if (au.time<vLoop[loop].start) {
			vol = Mathf.InverseLerp(vLoop[loop].fadeIn, vLoop[loop].start, au.time);
		} else {
			vol = Mathf.InverseLerp(vLoop[loop].fadeOut, vLoop[loop].end, au.time);
			if (au.time >= vLoop[loop].fadeOut)
				au.Stop();
		}
		return vol;
	}
}
