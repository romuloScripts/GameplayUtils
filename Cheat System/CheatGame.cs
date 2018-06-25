using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CheatGame : MonoBehaviour {

    public UnityEvent onUnlock;
    public string password = "?";

    private bool activated = false;
    private int posPassword = 0;

	void Update () {
        if (!activated) {
            if (Input.GetKeyDown("" + password[posPassword])) {
                posPassword++;
            }else if (Input.anyKeyDown) {
                posPassword = 0;
            }
            if (posPassword == password.Length) {
                posPassword = 0;
                UnlockFullGame();
            }
            return;
        }
	}

    void UnlockFullGame() {
        activated = true;
        enabled = false;
        Debug.Log("Cheat Ativated !");
        GetComponent<AudioSource>()?.Play();
        onUnlock.Invoke();
    }
}
