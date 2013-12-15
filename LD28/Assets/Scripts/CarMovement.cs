using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour
{
	public float speed = 3f;
	public Vector3 baseScale;
	public Material verticalSprite, horizontalSprite;

	private float time = 0f;
	private float duration = 0f;
	private float durationMin = 0.5f;
	private float durationMax = 3f;
	private CharacterController controller;
	private Vector3 velocity;

	private int dir = 0;

	private NavMeshAgent agent;
	private Transform wayPoint;
	
	// Use this for initialization
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		SetDestination();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (agent.remainingDistance <= 1.5f)
		{
			time += Time.deltaTime;
			if (time > duration)
			{
				time = 0f;
				duration = Random.Range(durationMin, durationMax);
				SetDestination();
			}
		}

		SetSprite();
	}

	private void SetSprite()
	{
		Vector3 scale = baseScale;
		velocity = agent.velocity;
		if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.z))
		{
			if (velocity.x > 0)
				dir = 2;
			else if (velocity.x < 0)
				dir = 0;
		}
		else if (Mathf.Abs(velocity.x) < Mathf.Abs(velocity.z))
		{
			if (velocity.z > 0)
				dir = 1;
			else if (velocity.z < 0)
				dir = 3;
		}

		if (dir == 0 || dir == 2)
		{
			transform.GetChild(0).renderer.material = horizontalSprite;

			if (dir == 0)
				scale.x = baseScale.x;
			else if (dir == 2)
				scale.x = -baseScale.x;
			transform.GetChild(0).gameObject.transform.localScale = scale;
		}
		else if (dir == 1 || dir == 3)
		{
			transform.GetChild(0).renderer.material = verticalSprite;
			
			if (dir == 1)
				scale.z = -baseScale.z;
			else if (dir == 3)
				scale.z = baseScale.z;
			transform.GetChild(0).gameObject.transform.localScale = scale;
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

	private void SetDestination()
	{
		GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");		
		wayPoint = waypoints[Random.Range(0, waypoints.Length)].transform;
		agent.SetDestination(wayPoint.position);
	}
}
