using UnityEngine;
using System.Collections;

public class GrazeText : MonoBehaviour {
    void Update()
    {
        gameObject.GetComponent<TextMesh>().text = "Graze : " + Player.current.Graze.ToString("00");
    }
}
