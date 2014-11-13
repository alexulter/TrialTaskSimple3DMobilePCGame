using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour {

	
	public GameObject PanelLevel;
	public GameObject PanelLoss;
	public GameObject PanelWin;
	
	[System.NonSerialized]
	public GameManager manager;
	
	void Start () {

	}
	
	
	void Update () {
	
	}
	
	public void ShowWinScreen()
	{
		HideLevelScreen();
		PanelWin.SetActive(true);
	}
	public void ShowLossScreen()
	{
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
