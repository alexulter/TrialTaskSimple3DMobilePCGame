using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float movespeed = 5f;
	private float rotationspeed = 100f;
	public int MoveDirection = 0;
	public SharpJoystick JoyStickLeft;
	private Animator anim;
	
	//public SharpJoystick joyStickRight;
	private CharacterController guy;
	void Start () {
	guy = gameObject.GetComponent<CharacterController>();
	if (guy == null)
	{
		gameObject.SetActive(false);
		Debug.LogError("Unable to find character controller for the player");
	}
		anim = gameObject.GetComponentInChildren<Animator>();
	}

	void Update () {
		
		float speed_signum = 0f;
		if (Application.isMobilePlatform || Application.isEditor)
		{
		speed_signum = JoyStickLeft.position.y;
		transform.Rotate(0,JoyStickLeft.position.x*Time.deltaTime*rotationspeed,0,Space.World);			
		}
		if (!Application.isMobilePlatform)
		{
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
				speed_signum = 1; 
			if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
				speed_signum = -1;
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
				transform.rotation *= Quaternion.Euler(0,-rotationspeed*Time.deltaTime,0);
			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
				transform.rotation *= Quaternion.Euler(0,rotationspeed*Time.deltaTime,0);
		}
		guy.SimpleMove(transform.TransformDirection(Vector3.forward)*movespeed*speed_signum);
		if (speed_signum > 0) anim.SetInteger("movedir",1);
		else if (speed_signum < 0)anim.SetInteger("movedir",-1);
		else anim.SetInteger("movedir",0);;
	}
	
	
	
}