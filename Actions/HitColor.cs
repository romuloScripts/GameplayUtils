using UnityEngine;
using System.Collections;

public interface IHitColor {
	void setHitColor(HitColor hitColor);
}

public class HitColor : MonoBehaviour {

	[System.Serializable]
	public struct TMaterial {
		public string idsMateriais;
		public Color corHit;
		public string nomeProp;
		public Color[] cores;

		[HideInInspector, SerializeField]
		public int[] ids;
	}
	public Vector2 fadeIn = new Vector2(0.1f, 0f);
	public Vector2 fadeOut = new Vector2(0.2f, 0.3f);
	public Renderer render;
	public MonoBehaviour parentHitColor;
	public TMaterial[] materiais;
	private float tHit = -10f;


	[ContextMenu("Pegar Cores")]
	void Awake () {
		if (parentHitColor is IHitColor)
			((IHitColor)parentHitColor).setHitColor(this);
		if(!render)
			render = GetComponent<Renderer>();
		pegarCores();
	}

	void pegarCores () {
		string[] split;
		for (int i=0; materiais!=null && i<materiais.Length; i++) {
			if ( string.IsNullOrEmpty(materiais[i].nomeProp) )
				materiais[i].nomeProp = "_Color";
			split = materiais[i].idsMateriais.Split(',');
			materiais[i].ids = new int[split.Length];
			materiais[i].cores = new Color[split.Length];
			for (int j = 0; j < split.Length; j++) {
				int.TryParse(split[j], out materiais[i].ids[j]);
				materiais[i].cores[j] = render.sharedMaterials[ materiais[i].ids[j] ].GetColor(materiais[i].nomeProp);
			}
		}
	}
	
	public Color getCorHit (Color corHit, Color corInimigo) {
		float t = 0f;
		t += Mathf.InverseLerp(fadeIn.x, fadeIn.y, Time.time-tHit);
		t += Mathf.InverseLerp(fadeOut.x, fadeOut.y, Time.time-tHit);
		if(t>=1) enabled = false;
		return Color.Lerp(corHit, corInimigo, t);
	}

	[ContextMenu("setHit")]
	public void setHit (){
		enabled = true;
		tHit = Time.time;
	}

	void Update () {
		update ();
	}

	public void update(){
		for (int i=0; materiais!=null && i<materiais.Length; i++) {
			for (int j=0; j<materiais[i].ids.Length; j++) {
				render.materials[ materiais[i].ids[j] ].SetColor(
					materiais[i].nomeProp , getCorHit( materiais[i].corHit, materiais[i].cores[j] )
					);
			}
		}	
	}

	public void SetColor(Color color){
		for (int i=0; materiais!=null && i<materiais.Length; i++) {
			for (int j=0; j<materiais[i].ids.Length; j++) {
				render.materials[ materiais[i].ids[j] ].SetColor(materiais[i].nomeProp , color);
			}
		}
	}

	public void SetColor2(Color color){
		for (int i=0; materiais!=null && i<materiais.Length; i++) {
			for (int j=0; j<materiais[i].ids.Length; j++) {
				render.material.SetColor(materiais[i].nomeProp , color);
			}
		}
	}
}
