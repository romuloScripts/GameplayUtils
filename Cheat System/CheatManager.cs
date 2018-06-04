using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method)]
public class CheatName : Attribute {
    public string name;

    public CheatName(string name) {
        this.name = name;
    }
}

[CreateAssetMenu(fileName = "CheatManager",menuName = "GameFramework/CheatManager")]
public class CheatManager : ScriptableObject {
    
    public KeyCode keyCodeInputField = KeyCode.Insert;
    public CheatInputField inputField;
    public KeyCodeCheat[] keyCodeCheat;

    [System.Serializable]
    public class KeyCodeCheat{
        public string name;
        public KeyCode keyCode;
        public KeyCode keyCode2;
        public string parameters;
    }

    [System.Serializable]
    public class StringCheat{
        public StringCheat stringCheat;
        public UnityEvent onActive;
    }

    private CheatInputField inputFieldInstance;

    public void InputCheat(){
        #if UNITY_EDITOR || CHEAT
        if(Input.GetKeyDown(keyCodeInputField)){
            if(!inputFieldInstance){
                inputFieldInstance = Instantiate<CheatInputField>(inputField);
                inputFieldInstance.Ini(this);
            }else{
                inputFieldInstance.EndEdit();
            }
        }else if(inputFieldInstance) {
            return;
        }

        for (int i = 0; i < keyCodeCheat.Length; i++){
            KeyCodeCheat kc = keyCodeCheat[i];
            bool result = false;
            if(kc.keyCode2 == KeyCode.None && Input.GetKeyDown(kc.keyCode)){
                result = true;
            }else if(Input.GetKeyDown(kc.keyCode2) && Input.GetKey(kc.keyCode)){
                result = true;
            }
            if (result){
                if(string.IsNullOrEmpty(kc.parameters))
                    EnterCheatCode(kc.name);
                else
                    EnterCheatCode(kc.name + ":" + kc.parameters);
            }
        }
        #endif
    }

    #if UNITY_EDITOR || CHEAT
    public void EnterCheatCode(string cheatCode){
        string[] strings= cheatCode.Split(':');
        if(strings.Length <=0) return;
        string method = strings[0];

        MethodInfo theMethod = GetMethod(method);       
        if(theMethod == null || theMethod.Name.Equals("EnterCheatCode")) return;
        if(strings.Length >1){
            ParameterInfo[] parameters = theMethod.GetParameters();
            if(strings.Length-1 != parameters.Length) return;
            object[] param = new object[strings.Length-1];
            for (int i = 0; i < strings.Length-1; i++){
                param[i] = System.Convert.ChangeType(strings[i+1],parameters[i].ParameterType);
            }
            theMethod.Invoke((object)this,param);
        }else{
            theMethod.Invoke((object)this,null);
        }    
    }

    private MethodInfo GetMethod(string methodCodeName){
        System.Type thisType = this.GetType();
        MethodInfo theMethod = thisType.GetMethod(methodCodeName);
        if(theMethod != null){
            return theMethod;
        }
        foreach (var method in thisType.GetMethods()){
            foreach (var attribute in method.GetCustomAttributes(typeof(CheatName),true)){
                if(methodCodeName.Equals(((CheatName)attribute).name))
                    return method;
            }
        }
        return null;
    }
    #endif
}