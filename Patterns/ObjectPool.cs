using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void AddAvaliable<T>(T obj);

public interface IObjectPool<T>{
    void ResetObjectPool(Vector3 pos, Quaternion rot);
    event AddAvaliable<T> disableObjPool;
}

public class ObjectPool<T> where T : MonoBehaviour, IObjectPool<T> {
    public List<T> avaliable = new List<T>();
    public Transform parentDefault;

    private static ObjectPool<T> _instance = null;

    public static ObjectPool<T> Instance{
        get{
            if (_instance == null){
                _instance = new ObjectPool<T>();
                GameObject g = new GameObject("ObjectPool " + typeof(T).Name);
                _instance.parentDefault = g.transform;
                SceneManager.sceneLoaded += OnSceneLoaded;
            }
            return _instance;
        }
    }

    static void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        if(_instance != null)
            _instance.avaliable.Clear();
        _instance = null;
    }

    public static T Instantiate(T obj, Vector3 pos, Quaternion rot) {
        return Instance.instantiate(obj, pos, rot);
    }

    private T instantiate(T obj, Vector3 pos, Quaternion rot) {
        if (avaliable.Count <= 0){
            T inst = MonoBehaviour.Instantiate<T>(obj, pos, rot,parentDefault);
            inst.disableObjPool += AddAvaliable;

            return inst;
        }else{
            avaliable[0].ResetObjectPool(pos, rot);
            T inst = avaliable[0];
            avaliable.RemoveAt(0);
            return inst;
        }
    }

    public void AddAvaliable(T obj) {
        avaliable.Add(obj);
        obj.gameObject.SetActive(false);
    }
}
