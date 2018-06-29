using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class CheatPoint : MonoBehaviour {

	public enum CheatKey {
		None = KeyCode.None,
		Shift_F1 = KeyCode.F1,
		Shift_F2 = KeyCode.F2,
		Shift_F3 = KeyCode.F3,
		Shift_F4 = KeyCode.F4,
		Shift_F5 = KeyCode.F5,
		Shift_F6 = KeyCode.F6,
		Shift_F7 = KeyCode.F7,
		Shift_F8 = KeyCode.F8,
		Shift_F9 = KeyCode.F9,
		Shift_F10 = KeyCode.F10,
		Shift_F11 = KeyCode.F11,
		Shift_F12 = KeyCode.F12,
	}

	public CheatKey key = CheatKey.None;
	public UnityEvent onCheat;

	#if CHEAT
	void Update () {
		if (!Cheat.ativo)
			return;
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) ) {
			if ( Input.GetKeyDown((KeyCode)tecla) ) {
				onCheat.invoke();
			}
		}
	}
	#endif

}
