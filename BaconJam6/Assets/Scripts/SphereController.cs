﻿using UnityEngine;
using System.Collections;

// SphereController.cs

public class SphereController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				
		// Spin around the player for now.
		transform.RotateAround(Vector3.zero, Vector3.up, 40f * Time.deltaTime);
	
	}
	
	
	void OnTriggerEnter (Collider c) {
		if (c.tag == "Player") {
			gameObject.SetActive(false);
		}
	}
}
