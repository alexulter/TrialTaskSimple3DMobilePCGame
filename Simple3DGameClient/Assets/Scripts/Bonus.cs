using UnityEngine;
using System.Collections;

public enum BonusType {good, bad};
public class Bonus : MonoBehaviour {

	
	private GameManager manager;
	public BonusType Type;
		
	void Awake()
	{
		manager = GameObject.FindObjectOfType<GameManager>();
		if (manager != null) manager.AddBonusToList(this);
		gameObject.SetActive(false);
	}
	
	void Start () {
	
	
	}
	
	void Update () {
	
	}
	
	void OnTriggerEnter()
	{
	 manager.OnBonusPickUp(this);
	}
	public void DestroyBonusObject()
	{
		Destroy(gameObject);
	}
}
