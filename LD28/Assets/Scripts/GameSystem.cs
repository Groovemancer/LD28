using UnityEngine;
using System.Collections;

public class GameSystem : MonoBehaviour {

	private float timer = 60f;
	public GUISkin skin;

	private int casualties = 0;
	private bool endGame = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (endGame)
		{
			EndGame();
		}
		else
		{
			timer -= Time.deltaTime;

			if (timer <= 0f)
			{
				timer = 0f;
				GameOver(false);
			}
		}
	}

	void OnGUI()
	{
		GUI.skin.label.alignment = TextAnchor.UpperCenter;
		GUI.skin = skin;
		GUI.skin.label.fontSize = 24;
		GUI.skin.label.normal.textColor = Color.yellow;
		string text = string.Format("Time Remaining: {0:0.00}", timer);
		GUI.Label(new Rect(0, 16, 320, 32), text);

		text = string.Format("Casualties: {0}", casualties);
		GUI.Label(new Rect(400, 16, 320, 32), text);

		GUI.skin.label.normal.textColor = Color.white;
		GUI.skin.label.fontSize = 16;
		text = "Move - WASD Horn - H\nBrake - Spacebar";
		GUI.Label(new Rect(720, 16, 320, 64), text);
//		GUI.Label(new Rect())
	}

	void IncreaseCasualties()
	{
		casualties++;
	}

	void GameOver(bool reachedGoal)
	{
		float time = 60f - timer;
		PlayerPrefs.SetFloat("time", time);
		PlayerPrefs.SetInt("casualties", casualties);
		PlayerPrefs.SetInt("reachedGoal", reachedGoal ? 1 : 0);

		endGame = true;
	}

	void EndGame()
	{
		GameObject.FindGameObjectWithTag("ScreenFader").SendMessage("EndScene", 3, SendMessageOptions.DontRequireReceiver);
	}
}
