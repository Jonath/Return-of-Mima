using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public GameObject weakEnemy;
	public Vector3 spawnValues;

	void Start()
	{
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (1);
		for (int i = 0; i < 5; i++)
		{
			Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (weakEnemy, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(0.5f);
		}
	}
}
