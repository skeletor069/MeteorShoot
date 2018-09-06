using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGamePanel : Panels {
	public TextMeshProUGUI scoreText;

	public void SetScore(int score){
		scoreText.text = score+"";
	}
	
}
