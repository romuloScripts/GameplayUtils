using UnityEngine;
using System.Collections;
 
public class CameraShake : MonoBehaviour {
 
	public bool debugMode = false;//Test-run/Call ShakeCamera() on start
    public float rotScaleFactor = 1;
    public float posScaleFactor = 1;
    public float shakeAmount;//The amount to shake this frame.
    public float maxShakeAmount=20;
    public float maxShakeDuration = 7;
    public float shakeDuration;//The duration this frame.
 
	//Readonly values...
	float shakePercentage;//A percentage (0-1) representing the amount of shake to be applied when setting rotation.
	float startAmount;//The initial shake amount (to determine percentage), set when ShakeCamera is called.
	float startDuration;//The initial shake duration, set when ShakeCamera is called.
 
	bool isRunning = false;	//Is the coroutine running right now?
 
	public bool smooth;//Smooth rotation?
	public float smoothAmount = 5f;//Amount to smooth
 
	void Start () {
 
		if(debugMode) ShakeCamera ();
	}
 
 
	void ShakeCamera() {
 
		startAmount = shakeAmount;//Set default (start) values
		startDuration = shakeDuration;//Set default (start) values
 
		if (!isRunning) StartCoroutine (Shake());//Only call the coroutine if it isn't currently running. Otherwise, just set the variables.
	}
 
	public void ShakeCamera(float amount, float duration) {
 
		shakeAmount += amount;//Add to the current amount.
        if (shakeAmount >= maxShakeAmount) shakeAmount = maxShakeAmount;
		startAmount = shakeAmount;//Reset the start amount, to determine percentage.
		shakeDuration += duration;//Add to the current time.
        if (shakeDuration > maxShakeDuration) shakeDuration = maxShakeDuration;
		startDuration = shakeDuration;//Reset the start time.
        if (!isRunning) StartCoroutine (Shake());//Only call the coroutine if it isn't currently running. Otherwise, just set the variables.
	}
 
 
	IEnumerator Shake() {
		isRunning = true;
		while (shakeDuration > 0.0001f) {
			Vector3 rotationAmount = Random.insideUnitSphere * shakeAmount * rotScaleFactor;
            Vector3 positionAmount = Random.insideUnitSphere * shakeAmount * posScaleFactor;//A Vector3 to add to the Local Rotation
            rotationAmount.z = 0;//Don't change the Z; it looks funny.
            positionAmount.z= 0;
            shakePercentage = shakeDuration / startDuration;//Used to set the amount of shake (% * startAmount).
 
			shakeAmount = startAmount * shakePercentage;//Set the amount of shake (% * startAmount).
			shakeDuration = Mathf.MoveTowards(shakeDuration, 0, Time.deltaTime);//Lerp the time, so it is less and tapers off towards the end.

            if (smooth) {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotationAmount), Time.deltaTime * smoothAmount);
                transform.localPosition = Vector3.Lerp(transform.localPosition, positionAmount, Time.deltaTime * smoothAmount);
            } else {
                transform.localRotation = Quaternion.Euler(rotationAmount);//Set the local rotation the be the rotation amount.
                transform.localPosition = positionAmount;
            }
			yield return null;
		}
		shakeAmount = 0;
		transform.localRotation = Quaternion.identity;//Set the local rotation to 0 when done, just to get rid of any fudging stuff.
        transform.localPosition = Vector3.zero;
        isRunning = false;
	}
}