using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float movespeed = 5f;
	private float rotationspeed = 100f;
	public SharpJoystick JoyStickLeft;
	
	//public SharpJoystick joyStickRight;
	private CharacterController guy;
	void Start () {
	guy = gameObject.GetComponent<CharacterController>();
	if (guy == null)
	{
		gameObject.SetActive(false);
		Debug.LogError("Unable to find character controller for the player");
	}
	}

	void Update () {
		

		if (Application.isMobilePlatform || Application.isEditor)
		{
		guy.SimpleMove(transform.TransformDirection(Vector3.forward)*JoyStickLeft.position.y*movespeed);
		transform.Rotate(0,JoyStickLeft.position.x*Time.deltaTime*rotationspeed,0,Space.World);			
		}
		if (!Application.isMobilePlatform)
		{
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
				guy.SimpleMove(transform.TransformDirection(Vector3.forward)*movespeed);
			if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
				guy.SimpleMove(-transform.TransformDirection(Vector3.forward)*movespeed);
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
				transform.rotation *= Quaternion.Euler(0,-rotationspeed*Time.deltaTime,0);
			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
				transform.rotation *= Quaternion.Euler(0,rotationspeed*Time.deltaTime,0);
		}
	}
	
	
	
}