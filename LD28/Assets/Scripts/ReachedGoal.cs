using UnityEngine;
using System.Collections;

public class ReachedGoal : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
		{
			GameObject.FindGameObjectWithTag("Game").SendMessage("GameOver", true, SendMessageOptions.DontRequireReceiver);
		}
	}
}
