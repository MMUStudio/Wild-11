using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour 
{
	public int health;
	public float moveSpeed = 0.5f;

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
		if(other.tag == "Tower")
		{
			other.gameObject.GetComponent<BaseTower>().EnemyEnterRange(this.gameObject);
		}

		if(other.tag == "Tile")
		{
			//print(GetComponent<SpriteRenderer>().sortingOrder);
			GetComponent<SpriteRenderer>().sortingOrder = other.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
			//print("New sorting layer of enemy = " + GetComponent<SpriteRenderer>().sortingOrder);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Tower")
		{
			print("wut");
			other.gameObject.GetComponent<BaseTower>().EnemyExitRange(this.gameObject);
		}
	}
}
