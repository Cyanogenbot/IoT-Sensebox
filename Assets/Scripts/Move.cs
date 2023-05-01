using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.InputSystem;



public class Move : MonoBehaviour {

	SerialPort sp = new SerialPort("COM10", 9600);

	public Rigidbody target;
	public float moveSpeed = 5f;
	private Vector2 move;

	public void OnMove(InputAction.CallbackContext context){
		move = context.ReadValue<Vector2>();
	}

	void Update(){
		// input
		movePlayer();
	}

	public void movePlayer(){
		Vector3 movement = new Vector3(move.x, 0f, move.y);

		transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
		if(movement != Vector3.zero){
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement),0.15f);
		}
	}
	// void FixedUpdate(){
	// 	target.MovePosition(target.position + movement * moveSpeed * Time.fixedDeltaTime);
	// }
}