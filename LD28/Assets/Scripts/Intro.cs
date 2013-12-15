using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

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
		if (GUI.Button(new Rect(Screen.width / 2 - 64, Screen.height / 2 + 288, 128, 64), "Start!"))
		{
			Application.LoadLevel(levelIndex);
		}
	}
}
