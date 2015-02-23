using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour {
    void Update()
    {
        gameObject.GetComponent<TextMesh>().text = Player.current.power.ToString("0.00") + " / 4.00";
    }
}
