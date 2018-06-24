using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ObservedFloat{
    [SerializeField]
	private float observedValue;
	public ChangeValueEvent onValueChanged;

    [System.Serializable]
    public class ChangeValueEvent: UnityEvent<float>{}

    public float ObservedValue{
        get{
            return observedValue;
        }set{
			if(!observedValue.Equals(value))
				onValueChanged.Invoke(value);
            observedValue = value;
        }
    }

	public void SilentSet(float value){
		observedValue = value;
	}

    public static implicit operator float(ObservedFloat observedFloat){
        return observedFloat.ObservedValue;
    }
}

[System.Serializable]
public class ObservedInt{
    [SerializeField]
	private int observedValue;
	public ChangeValueEvent onValueChanged;

    [System.Serializable]
    public class ChangeValueEvent: UnityEvent<int>{}

    public int ObservedValue{
        get{
            return observedValue;
        }set{
			if(!observedValue.Equals(value))
				onValueChanged.Invoke(value);
            observedValue = value;
        }
    }

	public void SilentSet(int value){
		observedValue = value;
	}
}

