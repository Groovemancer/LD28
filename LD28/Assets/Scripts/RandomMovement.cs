using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour
{

	public float speed = 3f;
	private float time = 0f;
	private float duration = 0f;
	private float durationMin = 0.5f;
	private float durationMax = 3f;
	private CharacterController controller;
	private Vector3 velocity;

	// Use this for initialization
	void Start()
	{
		//controller = gameObject.GetComponent<CharacterController> ();
		duration = Random.Range (durationMin, durationMax);
		SetRandomVelocity();
	}

	// Update is called once per frame
	void Update()
	{
		time += Time.deltaTime;

		if (time > duration)
		{
			time = 0f;
			duration = Random.Range(durationMin, durationMax);
			SetRandomVelocity();
		}
	}

	private void SetRandomVelocity()
	{
		int r = Random.Range (0, 100);
		if (r < 60)
			velocity = new Vector3 (Random.Range (-1f, 1f), 0f, Random.Range (-1f, 1f)) * speed;
		else if (r >= 60 && r < 95)
			velocity = Vector3.zero;
		rigidbody.velocity = velocity;
	}

	private void MoveAway(Rigidbody source)
	{
		Vector3 diff = transform.position - (source.position);
		diff.Normalize();
		velocity = new Vector3(Random.Range(0.5f, 1f) * diff.x, 0f, Random.Range(0.5f, 1f) * diff.z) * speed * 2;
		rigidbody.velocity = velocity;
		time = 0f;
		duration = 3f;
	}
}
