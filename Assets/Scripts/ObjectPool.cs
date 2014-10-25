using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

	public static ObjectPool current;
	public GameObject obj;
	public bool willGrow;

	private int pooledAmount = 5000;
	public List<GameObject> pooledObjects;

	void Awake ()
	{
		current = this;
	}

	void Start () {
		pooledObjects = new List<GameObject>();
		for(int i = 0 ; i < pooledAmount ; i++) 
		{
			GameObject objRef = (GameObject)Instantiate(obj);
			objRef.SetActive(false);
			pooledObjects.Add(objRef);
		}
	}

	public GameObject GetPooledObject()
	{
		for (int i = 0 ; i < pooledObjects.Count ; i++)
		{
			if(!pooledObjects[i].activeInHierarchy)
				return pooledObjects[i];
		}

		if(willGrow)
		{
			GameObject objRef = (GameObject)Instantiate(obj);
			pooledObjects.Add(objRef);
			return objRef;
		}

		return null;
	}
}
