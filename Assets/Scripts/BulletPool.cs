using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour {
    // Current singleton of the BulletPool
	public static BulletPool current;

    // Bullet spriteSheet
	public Sprite[] bulletSprites;

    // The prefab from which Bullet is instanciated
	public GameObject obj;

    // Should the pool grow in size when no bullets remain in the pool ?
	public bool willGrow;

    // List of pooled objects
	public List<GameObject> pooledObjects;

    // Size of the list
	private int pooledAmount = 1500;

    // Default position for any bullet (out of screen !)
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
            objRef.transform.parent = current.transform;
		}
	}

	public void DisableBullet(GameObject objRef)
	{
		//objRef.SetActive (false);
		objRef.collider2D.enabled = false;
		objRef.rigidbody2D.position = defaultPos; // Set out of rendering

		Updater updaterRef = objRef.GetComponent<Updater> ();
		updaterRef.Angle = 0;
		updaterRef.Speed = 0;
	}

	public GameObject EnableBullet(Vector3 position, float angle, float speed, int spriteID)
	{
		GameObject objRef = GetPooledObject();

		objRef.transform.position = position;
		objRef.transform.eulerAngles = new Vector3(0, 0, angle);
		objRef.GetComponent<SpriteRenderer>().sprite = bulletSprites[spriteID]; 

		Updater updaterRef = objRef.GetComponent<Updater> ();
		updaterRef.Angle = angle;
		updaterRef.Speed = speed;

		objRef.collider2D.enabled = true;
		
		return objRef;
	}

    public GameObject EnableBullet(Vector3 position, float angle, float speed, float acc, float max_speed, int spriteID)
    {
        GameObject objRef = GetPooledObject();

        objRef.transform.position = position;
        objRef.transform.eulerAngles = new Vector3(0, 0, angle);
        objRef.GetComponent<SpriteRenderer>().sprite = bulletSprites[spriteID];

        Updater updaterRef = objRef.GetComponent<Updater>();
        updaterRef.Angle = angle;
        updaterRef.Speed = speed;
        updaterRef.Acceleration = acc;
        updaterRef.Max_Speed = max_speed;

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
