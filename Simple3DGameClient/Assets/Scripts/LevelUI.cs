using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour {

	
	public GameObject PanelLevel;
	public GameObject PanelLoss;
	public GameObject PanelWin;
	private bool isRestartOnEnter = false;
	[System.NonSerialized]
	public GameManager manager;
	
	
	//game parameters from gamemanager
	public int bonuses_count;
	public int bonuses_need;
	
	//Textfields
	private Text BonusesText;
	
	void Start () {
		Transform gg = PanelLevel.transform.FindChild("Text_Bonuses");
		BonusesText = gg.gameObject.GetComponent<Text>();
	}
	
	
	void Update () {
		if (isRestartOnEnter && Input.GetKeyDown(KeyCode.Return)) RestartLevel();
		if (BonusesText != null) BonusesText.text = "Bonuses picked: "+
			bonuses_count.ToString()+"/"+bonuses_need.ToString();
	}
	
	public void ShowWinScreen()
	{
		if (!Application.isMobilePlatform) isRestartOnEnter = true;
		HideLevelScreen();
		PanelWin.SetActive(true);
	}
	public void ShowLossScreen()
	{
		if (!Application.isMobilePlatform) isRestartOnEnter = true;
		HideLevelScreen();
		PanelLoss.SetActive(true);
	}
	public void HideLevelScreen()
	{
		PanelLevel.SetActive(false);
	}
	
	public void RestartLevel()
	{
		if (manager != null)manager.RestartLevel();
		else Debug.LogError("UI doesn't know about GameManager instance");
	}
}
