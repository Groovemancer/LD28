using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour
{

	private int casualties = 0;
	private float time = 0f;
	private bool reachedGoal = false;

	void Awake()
	{
		guiTexture.color = Color.black;
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		guiTexture.enabled = true;

		time = PlayerPrefs.GetFloat("time");
		casualties = PlayerPrefs.GetInt("casualties");
		reachedGoal = PlayerPrefs.GetInt("reachedGoal") == 1;
	}
	
	void OnGUI()
	{
		GUISkin skin = GUI.skin;
		skin.label.fontSize = 24;
		skin.label.normal.textColor = Color.yellow;
		skin.label.fontStyle = FontStyle.Bold;
		skin.label.alignment = TextAnchor.MiddleCenter;
		string dataText;

		if (reachedGoal)
		{
			if (casualties == 1)
				dataText = string.Format("You spent {0:0.00} seconds to reach your destination.\nHow do you feel knowing you killed a person to save another?", time);
			else if (casualties > 1)
				dataText = string.Format("You spent {0:0.00} seconds to reach your destination.\nHow do you feel knowing you killed {1} people to save 1?", time, casualties);
			else
				dataText = string.Format("You spent {0:0.00} seconds to reach your destination.\nCongrats! You managed to save a life!", time);
		}
		else
		{
			if (casualties == 1)
				dataText = string.Format("Not only did you not save the life you set out to save, but you killed a person.");
			else if (casualties > 1)
				dataText = string.Format("Not only did you not save the life you set out to save, but you killed {0} people.", casualties);
			else
				dataText = "You failed to save the life you set out to save.\nAt least you didn't kill anyone.";
		}
		GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Game Over!\n" + dataText);

		if (GUI.Button(new Rect(Screen.width / 2 - 128, Screen.height / 2 + 96, 128, 64), "Try Again?"))
			Application.LoadLevel(2);
		if (GUI.Button(new Rect(Screen.width / 2 + 32, Screen.height / 2 + 96, 128, 64), "Main Menu"))
			Application.LoadLevel(0);
	}

}
