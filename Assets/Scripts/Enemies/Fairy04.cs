using UnityEngine;
using System.Collections;

public class Fairy04 : MonoBehaviour {
    public float spd, ang, chg;
    public int delay;

    public IEnumerator RunSequence()
    {
        /*yield return StartCoroutine(Utilities.Wait(delay));
        yield return StartCoroutine(Utilities.MoveAngle(gameObject, ang, chg, spd, delay));
        yield return StartCoroutine(Patterns.Triangle(gameObject, 10, 7, 10));*/
        yield return StartCoroutine(Utilities.MoveAngle(gameObject, ang, chg, spd, 120 - delay));
    }

    public void Start()
    {
        StartCoroutine(RunSequence());
    }
}
