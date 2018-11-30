using UnityEngine;
using System.Collections;


public static class TransformExtensions {

	public static void DestroyChilds(this Transform transform)
	{
		for (int i = transform.childCount-1; i >=0; i--)
		{
			Object.Destroy((transform.GetChild(i).gameObject));
		}
	}

	public static float Distance (this Transform trans, Transform b) {
		return Vector3.Distance(trans.position, b.position);
	}

	public static float Deslocment (this Transform trans, Transform a, Transform b) {
		return a.Distance(trans) / a.Distance(b);
	}

	private static Vector3 _zForward;

	public static Vector3 zForward (this Transform trans) {
		_zForward = trans.forward;
		_zForward.z = 0f;
		return _zForward;
	}

	public static Quaternion zRotation (this Transform trans) {
		_zForward = trans.forward;
		_zForward.z = 0f;
		return Quaternion.LookRotation(_zForward);
	}

	public static void FlipScale2D(this Transform transform)
    {
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
    }

	public static void FlipScale2D(this Transform transform, float dir = -1)
    {
		Vector3 scale= transform.localScale;
		scale.x = Mathf.Abs(scale.x);
        transform.localScale = Vector3.Scale(scale, new Vector3(dir, 1, 1));
    }

	public static float Distance (this Vector3 v3, Vector3 b) {
		return Vector3.Distance(v3, b);
	}

	public static float Deslocment (this Vector3 v3, Vector3 a, Vector3 b) {
		return a.Distance(v3) / a.Distance(b);
	}

	public static bool checkSqrMagnitude (this Vector3 v3, float dist) {
		return v3.sqrMagnitude <= dist*dist;
	}

	public static Vector2 ToVector2(this Vector3 v){
		return new Vector2(v.x,v.y);
	}
}
