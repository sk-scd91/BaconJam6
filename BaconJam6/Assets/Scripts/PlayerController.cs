using UnityEngine;
using System.Collections;

// PlayerController.cs

[RequireComponent(typeof(CharacterController))] //for movement and collisions.
public class PlayerController : MonoBehaviour {
	
	private const float playerSpeed = 6f;

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//First, get the character controller.
		CharacterController controller = GetComponent<CharacterController>();
		
		//get movement vector.
		Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		controller.Move(movement * Time.deltaTime * playerSpeed);
	}
}
