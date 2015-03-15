using UnityEngine;
using System.Collections;

public class Fairy02 : MonoBehaviour {
    public float ang, spd;
    public int delay;

    public IEnumerator RunSequence()
    {
        yield return StartCoroutine(Utilities.Wait(delay));
        StartCoroutine(Utilities.MoveAngle(gameObject, ang, 0, spd, 120));
        //yield return StartCoroutine(Patterns.Homing(gameObject, 5));
    }

    public void Start()
    {
        StartCoroutine(RunSequence());
    }
}
