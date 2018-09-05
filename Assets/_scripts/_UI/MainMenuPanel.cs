using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuPanel : Panels {
	public Button playBtn;
	public Button upgradeBtn;
	public Button settingsBtn;

	void Awake(){
		base.Awake();
		upgradeBtn.onClick.AddListener(delegate{
			UIController.controller.LoadUpgradePanel();
		});

		playBtn.onClick.AddListener(delegate{
			UIController.controller.LoadInGamePanel();
		});
	}
}
