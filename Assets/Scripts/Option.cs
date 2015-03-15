using UnityEngine;
using System.Collections;

public class Option : MonoBehaviour {
    public float angle = -90;
    public float angleDep = 0;

    public Transform focusShoot;
    public Transform normalShoot;

    public int rot;

    void Update() {
        Fire fire = gameObject.GetComponent<Fire>();
        if(Player.current.Focus) {
            fire.ShotDelegate = ReimuPatterns.NeedleShot;
            fire.ShotPrefab = focusShoot;
            fire.ShootingRate = 15;
        } else {
            fire.ShotDelegate = ReimuPatterns.HomingShot;
            fire.ShotPrefab = normalShoot;
            fire.ShootingRate = 90;
        }
    }

	void FixedUpdate () {
        transform.Rotate(new Vector3(0, 0, rot));
	}
}
