using UnityEngine;
using System.Collections;

public class WaypointFollow : MonoBehaviour
{
	public GameObject nextWaypoint;
	public Vector3 direction;
	public float lastDistance;
	public float speed = 5f;
	public BaseEnemy eBase;

	//public bool isMovingRight = true;
	public bool isMovingUp = false;

	// References to child objects
	private GameObject feet;
	private Animator anim;

	void Awake()
	{
		anim = GetComponent<Animator>();
		eBase = GetComponent<BaseEnemy>();
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.Translate(direction * Time.deltaTime * eBase.moveSpeed);
	}

	public void CalculateDirection()
	{
		if(feet == null)
		{
			feet = this.transform.FindChild("Feet").gameObject;
		}

		direction = nextWaypoint.transform.position - feet.transform.position;
		direction.Normalize();

		Vector3 tempScale = this.transform.localScale;

		//isMovingRight = (direction.x > 0) ? true : false;
		tempScale.x = (direction.x > 0) ? 1 : -1;

		// Equivalent to the above tertiary
		if(direction.y > 0)
		{
			isMovingUp = true;
		}
		else
		{
			isMovingUp = false;
		}

		this.transform.localScale = tempScale;

		anim.SetBool("MovingUp", isMovingUp);
		//anim.SetBool("MovingRight", isMovingRight);
	}
}
