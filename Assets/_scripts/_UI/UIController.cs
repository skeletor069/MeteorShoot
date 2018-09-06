using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public static UIController controller;

	public MainMenuPanel mainMenuPanel;
	public UpgradePanel upgradePanel;
	public InGamePanel inGamePanel;
	public Animator titleAnim;

	BattleController battlerController;
	WaitForSeconds waitOne = new WaitForSeconds(.6f);

	static int animShow = Animator.StringToHash("show");
	static int animHide = Animator.StringToHash("hide");

	void Awake(){
		controller = this;
	}

	// IEnumerator Start(){
	// 	yield return waitOne;
	// 	LoadMainMenu();
	// }

	public void Initiate(BattleController battlerController){
		this.battlerController = battlerController;
	}

	public IEnumerator StartJourney(){
		yield return waitOne;
		titleAnim.SetTrigger(animShow);
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

	public void LoadGameOver(int score, int bestScore, bool newBest){

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
		titleAnim.SetTrigger(animHide);
		yield return waitOne;
		upgradePanel.gameObject.SetActive(false);
		mainMenuPanel.gameObject.SetActive(false);
		inGamePanel.Show();
		yield return waitOne;
		battlerController.StartGame();
	}

	public void SetScore(int score){
		inGamePanel.SetScore(score);
	}
}
