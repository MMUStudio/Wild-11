using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour 
{
	public float speed = 3f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.Translate(new Vector3(1f, -0.5f, 0f) * Time.deltaTime * speed);
	}

	public void JumpDownRight()
	{
		//Vector3 pos = this.transform.position;

		//pos.x += this.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
		//pos.y -= this.GetComponent<SpriteRenderer>().sprite.bounds.size.y;

		//this.transform.position = pos;
	}

	public void Kill()
	{

	}
}
