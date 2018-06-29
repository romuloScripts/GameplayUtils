using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFloatShader : MonoBehaviour {

	public string param;
	public Material material;

	public void SetFloat(float value){
		material.SetFloat(param,value);
	}
}
