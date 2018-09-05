using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public static UIController controller;

	public MainMenuPanel mainMenuPanel;
	public UpgradePanel upgradePanel;
	public InGamePanel inGamePanel;

	WaitForSeconds waitOne = new WaitForSeconds(.6f);

	void Awake(){
		controller = this;
	}

	IEnumerator Start(){
		yield return waitOne;
		LoadMainMenu();
	}

	public void LoadMainMenu(){
		StartCoroutine(ShowMainMenu());
	}

	public void LoadUpgradePanel(){
		StartCoroutine(ShowUpgradePanel());
	}

	public void LoadInGamePanel(){
		StartCoroutine(ShowInGamePanel());
	}

	IEnumerator ShowMainMenu(){
		upgradePanel.Hide();
		inGamePanel.Hide();
		yield return waitOne;
		mainMenuPanel.Show();
	}

	IEnumerator ShowUpgradePanel(){
		mainMenuPanel.Hide();
		inGamePanel.Hide();
		yield return waitOne;
		upgradePanel.Show();
	}

	IEnumerator ShowInGamePanel(){
		upgradePanel.Hide();
		mainMenuPanel.Hide();
		yield return waitOne;
		inGamePanel.Show();
	}
}
