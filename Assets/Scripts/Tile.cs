using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour 
{
	// This will only work for testing!
	public GameObject testPrefab;

	private Transform towerPos;
	public bool hasTower = false;
	public bool canHaveTower = true;

	// Use this for initialization
	void Start () 
	{
		towerPos = this.transform.FindChild("TowerPos").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnMouseDown()
	{
		print("test");
		if(hasTower == true || canHaveTower == false)
			return;

		hasTower = true;

		//Destroy(this.gameObject);
		GameObject tower = Instantiate(testPrefab, towerPos.transform.position, testPrefab.transform.rotation) as GameObject;

		// Get the base of the tower
		GameObject tBase = tower.transform.FindChild("Base").gameObject;

		tower.transform.Translate(tower.transform.position - tBase.transform.position);

		//tower.GetComponent<SpriteRenderer>().
	}
}
