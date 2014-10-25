using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public int damage = 1;
	public bool isEnemyShot = false;
	public bool isAbleToShot = false;
	
	// Use this for initialization
	void Start () {
		// 2 - Limited time to live to avoid any leak
		Destroy(gameObject, 100); // 100sec
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
