using UnityEngine;
using System.Collections;

public class PedSpawn : MonoBehaviour
{
	public GameObject pedestrianPrefab;
	public float spawnTimeMin, spawnTimeMax;
	private float spawnTime;
	private float spawnTimer = 0f;


	// Use this for initialization
	void Start()
	{
		spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
	}
	
	// Update is called once per frame
	void Update()
	{
		spawnTimer += Time.deltaTime;

		if (spawnTimer >= spawnTime)
		{
			spawnTimer = 0f;
			spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
			SpawnPedestrian();
		}
	}

	private void SpawnPedestrian()
	{
		GameObject.Instantiate(pedestrianPrefab, gameObject.transform.position, Quaternion.identity);
	}
}
