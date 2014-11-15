using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour {

	public static BulletPool current;
	public GameObject obj;
	public bool willGrow;

	public List<GameObject> pooledObjects;

	private int pooledAmount = 1500;
	private Sprite[] bulletSprites;
	private Vector2 defaultPos = new Vector2(-7,-7);

	void Awake ()
	{
		current = this;
	}

	void Start () {
		// Get all bullet sprites refs
		bulletSprites = Resources.LoadAll<Sprite>("bulletLibrary");

		pooledObjects = new List<GameObject>();
		for(int i = 0 ; i < pooledAmount ; i++) 
		{
			// Instantiate an object, disable it, add it to the pool
			GameObject objRef = (GameObject)Instantiate(obj);
			DisableBullet(objRef);
			pooledObjects.Add(objRef);
		}
	}

	public void DisableBullet(GameObject objRef)
	{
		//objRef.SetActive (false);
		objRef.collider2D.enabled = false;
		objRef.rigidbody2D.velocity = Vector2.zero;
		objRef.rigidbody2D.position = defaultPos; // Set out of rendering
	}

	public GameObject EnableBullet(Vector3 position, float angle, float speed, int spriteID)
	{
		GameObject objRef = GetPooledObject();

		objRef.transform.position = position;
		objRef.transform.eulerAngles = new Vector3(0, 0, angle + 90);
		objRef.GetComponent<SpriteRenderer>().sprite = bulletSprites[spriteID]; 

		Updater updaterRef = objRef.GetComponent<Updater> ();
		updaterRef.angle = angle;
		updaterRef.speed = speed;

		updaterRef.Change();

		objRef.collider2D.enabled = true;
		
		return objRef;
	}

	private GameObject GetPooledObject()
	{
		for (int i = 0 ; i < pooledObjects.Count ; i++)
		{
			GameObject objRef = pooledObjects[i];
			if(!objRef.collider2D.enabled)
			{
				return pooledObjects[i];
			}
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
