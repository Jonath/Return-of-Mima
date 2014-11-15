using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
	public GameObject weakEnemy;
	public Vector3 spawnValues;
	
	float count = 0.0f;
	int num = 0;

	void Update()
	{
		SpawnBlueFairies ();
	}

	void SpawnBlueFairies()
	{
		if(num < 5)
		{
			if(count > 0.5f)
			{
				Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (weakEnemy, spawnPosition, spawnRotation);

				count = 0.0f;
			}
		}
		count += Time.deltaTime;
	}
}
