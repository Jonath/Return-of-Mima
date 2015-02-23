using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {					

	// Reference on animator
	private Animator anim;

	// Frame counting
	private float count;

	void Start ()
	{
		anim = gameObject.GetComponent<Animator>();
	}

	public void FixedUpdate()
	{
        // TODO : update enemy movements
	}
}