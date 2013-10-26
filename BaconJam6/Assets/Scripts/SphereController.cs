using UnityEngine;
using System.Collections;

// SphereController.cs

public class SphereController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	void OnTriggerEnter (Collider c) {
		if (c.tag == "Player") {
			gameObject.SetActive(false);
		}
	}
}
