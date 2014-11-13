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
	
	void Start () {

	}
	
	
	void Update () {
		if (isRestartOnEnter && Input.GetKeyDown(KeyCode.Return)) RestartLevel();
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
