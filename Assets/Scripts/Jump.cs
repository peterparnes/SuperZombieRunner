using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	public float jumpSpeed = 240f;
	public float superJumpSpeed = 280f;
	public float forwardSpeed = 20f;

	private Rigidbody2D body2d; 
	private InputState inputState;
	private bool firstJump = false; 

	void Awake(){
		body2d = GetComponent<Rigidbody2D> ();
		inputState = GetComponent<InputState> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (inputState.standing) {
			firstJump = false;
			if (inputState.actionButton) {
				body2d.velocity = new Vector2 (transform.position.x < 0 ? forwardSpeed : 0, jumpSpeed);
				firstJump = true;
			}
		} else if(firstJump) {
			if (inputState.actionButton) {
				body2d.velocity = new Vector2 (transform.position.x < 0 ? forwardSpeed : 0, superJumpSpeed);
				firstJump = false; 
			}

		}
	}
}
