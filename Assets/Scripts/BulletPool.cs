using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour {
    // Current singleton of the BulletPool
	public static BulletPool current;

    // Bullet spriteSheet
	public Sprite[] bulletSprites;

    // Counting
    private int ctr = 0;

    // Default position for any bullet (out of screen !)
	private Vector2 defaultPos = new Vector2(-7,-7);

	void Awake () {
		current = this;
	}

	void Start () {
		// Get all bullet sprites refs
		bulletSprites = Resources.LoadAll<Sprite>("bulletLibrary");
	}

	public void DisableBullet(GameObject objRef) {
        Destroy(objRef);
	}

	public GameObject EnableBullet(GameObject obj, Vector3 position, float angle, float speed) {
        GameObject objRef = (GameObject)Instantiate(obj);

        objRef.transform.position = position;
		objRef.transform.eulerAngles = new Vector3(0, 0, angle);

        SpriteRenderer renderer = objRef.GetComponent<SpriteRenderer>();
        renderer.sortingOrder = ctr;
        ctr++;

		Updater updaterRef = objRef.GetComponent<Updater> ();
		updaterRef.Angle = angle;
		updaterRef.Speed = speed;

		objRef.collider2D.enabled = true;
		
		return objRef;
	}

    public GameObject EnableBullet(GameObject obj, Vector3 position, float angle, float speed, float acc, float max_speed) {
        GameObject objRef = (GameObject)Instantiate(obj);

        objRef.transform.position = position;
        objRef.transform.eulerAngles = new Vector3(0, 0, angle);

        SpriteRenderer renderer = objRef.GetComponent<SpriteRenderer>();
        renderer.sortingOrder = ctr;
        ctr++;

        Updater updaterRef = objRef.GetComponent<Updater>();
        updaterRef.Angle = angle;
        updaterRef.Speed = speed;
        updaterRef.Acceleration = acc;
        updaterRef.Max_Speed = max_speed;

        objRef.collider2D.enabled = true;

        return objRef;
    }
}
