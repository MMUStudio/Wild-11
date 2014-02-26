using UnityEngine;
using System.Collections;

public class DevHacks : MonoBehaviour 
{
	public GameObject enemyPrefab;
	public GameObject spawnPoint;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			print("Spawning enemy");
			GameObject enemy = Instantiate(enemyPrefab, spawnPoint.transform.position, enemyPrefab.transform.rotation) as GameObject;
			enemy.GetComponent<WaypointFollow>().nextWaypoint = spawnPoint.GetComponent<Waypoint>().next;
			enemy.GetComponent<WaypointFollow>().CalculateDirection();
		}
	}
}
