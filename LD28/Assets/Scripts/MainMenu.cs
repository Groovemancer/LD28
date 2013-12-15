using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
	public int levelIndex;

	void Awake()
	{
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		guiTexture.enabled = true;
	}
	
	// Update is called once per frame
	void Update()
	{

	}

	void OnGUI()
	{
		if (GUI.Button(new Rect(128, 232, 128, 64), "Play"))
		{
			Application.LoadLevel(levelIndex);
		}
		if (GUI.Button(new Rect(128, 320, 128, 64), "Quit"))
		{
			Application.Quit();
		}
	}
}
