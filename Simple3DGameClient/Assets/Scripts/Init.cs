using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour {

	public void StartLevel()
	{
		Application.LoadLevel("Level");
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return)) StartLevel();
	}
}
