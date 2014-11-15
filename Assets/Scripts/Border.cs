﻿using UnityEngine;
using System.Collections;

public class Border : MonoBehaviour {
	void OnTriggerExit2D(Collider2D other)
	{
		GameObject objRef = other.gameObject;
		if (objRef.tag == "Bullet")
		{
			// Resetting the object for further use
			BulletPool.current.DisableBullet(objRef);
		}
		if(objRef.tag == "Shot")
		{
			Destroy(objRef);
		}
		if(objRef.tag == "Enemy")
		{
			Destroy(objRef);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		GameObject objRef = other.gameObject;
		if (objRef.tag == "Enemy")
		{
			objRef.GetComponent<Pattern>().canFire = true;
		}
	}	
}
