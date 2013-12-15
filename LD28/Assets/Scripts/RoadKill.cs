using UnityEngine;
using System.Collections;

public class RoadKill : MonoBehaviour {

	public GameObject npcDead;

	void RoadKilled()
	{
		GameObject.Instantiate(npcDead, gameObject.transform.position, gameObject.transform.GetChild(0).transform.rotation);
		GameObject.FindGameObjectWithTag("Game").SendMessage("IncreaseCasualties", SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);
	}
}
