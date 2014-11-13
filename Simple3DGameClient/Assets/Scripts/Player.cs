using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	
	GameManager manager;
	PlayerController controller;
	void Awake()
	{
		FindSpawner();
		manager = GameObject.FindObjectOfType<GameManager>();
		if (manager != null) manager.SetPlayer(this);
		controller = gameObject.GetComponent<PlayerController>();
		gameObject.SetActive(false);
	}
	void Start () {
		
	}
	void Update()
	{
		
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
		gameObject.GetComponentInChildren<Animator>().enabled = false;
	}
}
