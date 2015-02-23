using UnityEngine;
using System.Collections;

public class Graze : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        if (obj.tag == "Bullet")
        {
            Player.current.Graze++;
        }
    }
}
