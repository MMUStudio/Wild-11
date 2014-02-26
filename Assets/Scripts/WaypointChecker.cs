using UnityEngine;
using System.Collections;

public class WaypointChecker : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "WayPoint")
		{
			// The enemy is the parent of the feet
			this.transform.parent.GetComponent<WaypointFollow>().nextWaypoint = other.gameObject.GetComponent<Waypoint>().next;
			this.transform.parent.GetComponent<WaypointFollow>().CalculateDirection();
		}
		else if(other.tag == "EndPoint")
		{
			print("You lost a life");
			
			// Remove the enemy from all tower's list if he gets to the end
			GameObject [] towers = GameObject.FindGameObjectsWithTag("Tower");

			for(int i = 0; i < towers.Length; ++i)
			{
				print(towers[i].name);
				print(this.transform.parent.gameObject);

				// HACK:  For some reason there is one tower in memory even though the hierarchy says otherwise.
				// WTF
				if(towers[i].GetComponent<BaseTower>() != null)
				{
					towers[i].GetComponent<BaseTower>().EnemyExitRange(this.transform.parent.gameObject);
				}
			}

			Destroy(this.transform.parent.gameObject);
		}
	}
}
