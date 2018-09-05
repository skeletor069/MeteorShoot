using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : Panels {

	public Button backBtn;

	void Awake(){
		base.Awake();
		backBtn.onClick.AddListener(delegate{
			UIController.controller.LoadMainMenu();
		});

	}
	
}
