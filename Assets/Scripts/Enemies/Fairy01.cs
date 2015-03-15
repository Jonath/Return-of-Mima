using UnityEngine;
using System.Collections;

// This script gives a behaviour to an enemy : first it goes to a given point, then it fires the given coroutine !
public class Fairy01 : MonoBehaviour {
    public float spd, ang;
    public GameObject obj;

    public IEnumerator RunSequence()
    {
        yield return StartCoroutine(Utilities.Wait(100));
        yield return StartCoroutine(Utilities.MoveAngle(gameObject, ang, spd, 45));
        StartCoroutine(Patterns.Circle(gameObject, obj, 1f, 16, 10));
        StartCoroutine(Patterns.Circle(gameObject, obj, 1f, 16, 40));
        StartCoroutine(Patterns.Circle(gameObject, obj, 1f, 16, 70));
        StartCoroutine(Patterns.Circle(gameObject, obj, 1f, 16, 100));
    }

    public void Start()
    {
        StartCoroutine(RunSequence());
    }
}