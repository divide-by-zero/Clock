using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour{
	private static T sInstance;
	public static T Instance{
		get{
			if(sInstance == null){
				sInstance = FindObjectOfType(typeof(T)) as T;
				if(sInstance == null){
					GameObject obj = new GameObject(typeof(T).Name);
					obj.AddComponent<T>();
                    obj.SendMessage("Initialize", SendMessageOptions.DontRequireReceiver);
                }
            }
			return sInstance;
		}
	}
	
	protected virtual void Awake (){
		if(this == Instance){
			DontDestroyOnLoad(Instance);
			return;
		}
		Destroy(gameObject);	//２つは作らない//
	}
}

public class MyUtil : SingletonMonoBehaviour<MyUtil> {
    public Coroutine Coroutine { private set; get; }

    public void DelayFunc(int frame, Action action) {
		Coroutine = StartCoroutine(_DelayFunc(frame, action));
	}

	private IEnumerator _DelayFunc(int frame, Action action) {
		for (int i = 0; i < frame; ++i) yield return null;
		action();
	    Coroutine = null;
	}
}

public static class LinqExtensions
{
    public static T RandomAt<T>(this IEnumerable<T> ie)
    {
        if (ie.Any() == false) return default(T);
        return ie.ElementAt(Random.Range(0, ie.Count()));
    }
}
