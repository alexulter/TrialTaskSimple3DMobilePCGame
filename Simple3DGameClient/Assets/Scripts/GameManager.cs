using UnityEngine;
using System.Collections;


public enum GState {Moving, Idle};

public class GameManager : MonoBehaviour {

	
	private LevelUI UI;
	public GameObject LevelUI_Pref;
	//public SharpJoystick LeftJoystick;
	private int bonus_counter = 0;
	public int WIN_CONDITION = 2;
	public GState GameState = GState.Moving;
	
	Player player;
	ArrayList bonus_list = new ArrayList();
	
	void Awake()
	{
		GameObject go = (GameObject)Instantiate(LevelUI_Pref);
		if (go != null) UI = go.GetComponent<LevelUI>();
		UI.manager = this;
	}
	
	void Start()
	{
		if (player != null) player.gameObject.SetActive(true);
		if (bonus_list.Count > 0) 
			foreach (Bonus item in bonus_list)
				item.gameObject.SetActive(true);
	}
	
	void Update () 
	{
		if (GameState == GState.Moving) ExchangeWithUI();
		else if (GameState == GState.Idle) player.DisablePlayer();
	}
	void ExchangeWithUI()
	{
		UI.bonuses_count = bonus_counter;
		UI.bonuses_need = WIN_CONDITION;
	}
	
	public void SetPlayer(Player guy)
	{
		player = guy;
	}
	
	public void AddBonusToList(Bonus item)
	{
		bonus_list.Add(item);
	}
	
	void RemoveBonus(Bonus item)
	{
		bonus_list.Remove(item);
		item.DestroyBonusObject();
	}
	
	void DoGameover()
	{
		GameState = GState.Idle;
		player.DisablePlayer();
		UI.ShowLossScreen();
	}
	void DoWin()
	{
		GameState = GState.Idle;
		player.DisablePlayer();
		UI.ShowWinScreen();
	}
	
	public void OnBonusPickUp(Bonus item)
	{
		if (item.Type == BonusType.bad) DoGameover();
		else if (item.Type == BonusType.good)
		{
		bonus_counter++;
		Debug.Log(bonus_counter);
		//RemoveBonus (item);
		item.gameObject.SetActive(false);
		if (bonus_counter >= WIN_CONDITION)DoWin();
		}
	}
	
	public void RestartLevel()
	{
		//так делать нехорошо, но для простоты оставим так
		Application.LoadLevel("Level");
	}

	
	
}
