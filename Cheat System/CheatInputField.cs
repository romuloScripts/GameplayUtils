using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheatInputField : MonoBehaviour {
    
    public InputField inputField;

    #if UNITY_EDITOR || CHEAT
    private CheatManager cheatManager;
    private float timeScale;

    public void Ini(CheatManager cheatManager) {
        this.cheatManager = cheatManager;
        inputField.onEndEdit.AddListener(EndEdit);
        EventSystem.current.SetSelectedGameObject(inputField.gameObject);
        timeScale = TimeManager.GetInstance().TimeScale;
        TimeManager.GetInstance().TimeScale = 0;
        TimeManager.GetInstance().pause = 0;
    }

    public void EndEdit(string code){
        cheatManager.EnterCheatCode(code);
        EndEdit();
    }

    public void EndEdit(){
        TimeManager.GetInstance().TimeScale = timeScale;
        TimeManager.GetInstance().pause = 1;
        Destroy(gameObject);
    }
    #endif
}