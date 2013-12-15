using UnityEngine;
using System.Collections;

public class ArrowToGoal : MonoBehaviour {

	private Transform goal;
	private float rotationSpeed = 30f;

	// Use this for initialization
	void Start()
	{
		goal = GameObject.FindGameObjectWithTag("Goal").transform;
	}
	
	// Update is called once per frame
	void Update()
	{
		Vector3 direction = (goal.position - transform.position).normalized;
		direction.y = 0f;
		Quaternion pointRotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, pointRotation, Time.deltaTime * rotationSpeed);
	}
}
