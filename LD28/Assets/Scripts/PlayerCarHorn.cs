using UnityEngine;
using System.Collections;

public class PlayerCarHorn : MonoBehaviour {

	public AudioSource hornSfx;
	public float hornRadius = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Horn"))
		{
			hornSfx.Play();
			ScarePedestrians();
		}
	}

	private void ScarePedestrians()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, hornRadius);
		for (int i = 0; i < hitColliders.Length; i++)
		{
			if (hitColliders[i].gameObject.tag == "Npc")
				hitColliders[i].SendMessage("MoveAway", rigidbody, SendMessageOptions.DontRequireReceiver);
		}
	}
}
