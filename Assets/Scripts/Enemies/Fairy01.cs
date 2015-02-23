using UnityEngine;
using System.Collections;

// This script gives a behaviour to an enemy : first it goes to a given point, then it fires the given coroutine !
public class Fairy01 : MonoBehaviour
{
    public float x, y, spd, ang, chg;

    public IEnumerator RunSquence01()
    {
        yield return StartCoroutine(Utilities.Wait(100));
        yield return StartCoroutine(Utilities.MoveBy(gameObject, x, y, spd));
        // yield return StartCoroutine(Patterns.Triangle(gameObject, 10));
        StartCoroutine(Patterns.Circle(gameObject, 16, 10));
        StartCoroutine(Patterns.Circle(gameObject, 16, 20));
        StartCoroutine(Patterns.Circle(gameObject, 16, 30));
        StartCoroutine(Patterns.Circle(gameObject, 16, 40));
        //yield return StartCoroutine(Utilities.MoveAngle(gameObject, ang, chg, spd, 120));
    }

    public void Start()
    {
        StartCoroutine(RunSquence01());
    }
}