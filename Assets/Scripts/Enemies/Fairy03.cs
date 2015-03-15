using UnityEngine;
using System.Collections;

public class Fairy03 : MonoBehaviour
{
    public float ang, spd, chg;
    public int delay;

    public IEnumerator RunSequence()
    {
        yield return StartCoroutine(Utilities.Wait(delay));
        yield return StartCoroutine(Utilities.MoveAngle(gameObject, ang, 0, spd, 60));
        //yield return StartCoroutine(Patterns.Circle(gameObject, 3f, 20, 10));
        yield return StartCoroutine(Utilities.Wait(30));
        yield return StartCoroutine(Utilities.MoveAngle(gameObject, ang, chg, spd, 160));
    }

    public void Start()
    {
        StartCoroutine(RunSequence());
    }
}
