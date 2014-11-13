using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	
	GameManager manager;
	Animator anim;
	PlayerController controller;
	void Awake()
	{
		FindSpawner();
		manager = GameObject.FindObjectOfType<GameManager>();
		if (manager != null) manager.SetPlayer(this);
		anim = gameObject.GetComponentInChildren<Animator>();
		controller = gameObject.GetComponent<PlayerController>();
		gameObject.SetActive(false);
	}
	void Start () {
		
	}
	void Update()
	{
		//float speed = Vector3.Dot(guy.velocity, transform.TransformDirection(Vector3.forward));
		anim.SetInteger("movedir",controller.MoveDirection);
		Debug.Log ("movedir"+controller.MoveDirection.ToString());
		controller.MoveDirection = 0;
	}
	void FindSpawner()
	{
		GameObject go = GameObject.Find("PlayerSpawner");
		if (go != null) 
		{
			transform.position = go.transform.position;
			transform.rotation = go.transform.rotation;
			Destroy (go);
		}
	}
	public void DisablePlayer()
	{
		gameObject.GetComponent<PlayerController>().enabled = false;
	}
}
