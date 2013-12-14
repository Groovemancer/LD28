using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	public float accelRate = 0.15f;
	public float baseSpeed = 1.5f;
	public float maxSpeed = 12f;

	// Friction, it will eventually slow down... right?
	public float slowRate = 0.994f;

	// The rate at which the player slows down when braking. Lower is faster, higher is slower.
	public float brakeRate = 0.97f;

	public float collisionSlow = 0.75f;

	// If velocity magnitude is below this, set velocity to 0.
	public const float VelocityThreshold = 0.01f;

	private CharacterController controller;
	private Vector3 velocity;

	// Use this for initialization
	void Start()
	{
		controller = gameObject.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update()
	{
		Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		if (direction.magnitude > 0 && velocity.magnitude == 0)
			velocity = direction * baseSpeed * Time.deltaTime;

		if (direction.magnitude > 0)
			velocity += direction * accelRate * Time.deltaTime;

		if (velocity.magnitude > maxSpeed)
			velocity = velocity.normalized * maxSpeed;

		if (direction.magnitude > 0)
		{
			if (Mathf.Abs(direction.x) == 0 && Mathf.Abs(direction.z) > 0)
			{
				velocity.x *= brakeRate;
			}
				
			if (Mathf.Abs(direction.x) > 0 && Mathf.Abs(direction.z) == 0)
			{
				velocity.z *= brakeRate;
			}
		}

		velocity *= slowRate;

		if (Input.GetButton("Brake"))
			velocity *= brakeRate;

		if (velocity.magnitude <= VelocityThreshold)
			velocity = Vector3.zero;

		controller.Move(velocity);

		//Debug.Log("Velocity: " + controller.velocity);

		if (direction.x > 0)
		{
			FlipSprite(true);
		}
		else if (direction.x < 0)
		{
			FlipSprite(false);
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.gameObject.tag == "Npc")
		{
			if (controller.velocity.magnitude > 7.5f)
				hit.gameObject.SendMessage("RoadKilled", SendMessageOptions.DontRequireReceiver);
		}
			

		// We don't want the ground to interfere with collisions.
		if (hit.gameObject.tag != "Ground")
		{
			Debug.Log("Velocity: " + controller.velocity.magnitude);
			velocity *= collisionSlow;
			// Will Add audio for collision later...
			// if (hit.relativeVelocity.magnitude > 2)
	//			audio.Play();
		}
	}

	private void FlipSprite(bool right)
	{
		Vector3 scale = transform.GetChild(0).gameObject.transform.localScale;
		if (right)
		{
			if (scale.x > 0)
				scale.x *= -1;
		}
		else
		{
			if (scale.x < 0)
				scale.x *= -1;
		}

		transform.GetChild(0).gameObject.transform.localScale = scale;
	}
}
