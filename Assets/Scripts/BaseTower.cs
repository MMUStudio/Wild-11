using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseTower : MonoBehaviour 
{
	public GameObject currentTarget;
	public float cooldown;
	public bool canShoot = true;
	public float damage = 1;

	public enum TargetSearchType { Closest, Weakest, Strongest };
	public TargetSearchType searchType;

	public List<GameObject> targets;

	private Animator anim;
	private bool isFacingDown = true;
	private bool shootAnimDone = true;
	private Vector3 direction;
	private Transform towerBase;

	// Use this for initialization
	void Start () 
	{
		targets = new List<GameObject>();
		anim = GetComponent<Animator>();
		towerBase = this.transform.FindChild("Base");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(canShoot == true && currentTarget != null)
		{
			StartCoroutine(Shoot());
		}
		else
		{
			anim.SetBool("CanShoot", false);
		}

		if(currentTarget == null && targets.Count > 0)
		{
			FindNextTarget();
		}

		FindFacing();
	}

	public IEnumerator Shoot()
	{
		print("Bam");

		canShoot = false;

		

		FireProjectile();

		yield return new WaitForSeconds(cooldown);

		canShoot = true;
	}

	public void ShootAnimDone()
	{
		shootAnimDone = true;
		anim.SetBool("ShootAnimDone", shootAnimDone);
	}

	private void FindFacing()
	{
		// Special case
		if(currentTarget == null)
		{
			anim.SetBool("isFacingDown", true);
			return;
		}

		direction = currentTarget.transform.position - towerBase.transform.position;
		direction.Normalize();

		Vector3 tempScale = this.transform.localScale;

		

		isFacingDown = (direction.y <= 0) ? true : false;

		if(isFacingDown == true)
		{
			tempScale.x = (direction.x >= 0) ? 1 : -1;
		}
		else
		{
			tempScale.x = (direction.x >= 0) ? -1 : 1;
		}

		this.transform.localScale = tempScale;

		anim.SetBool("isFacingDown", isFacingDown);
	}

	protected virtual void FireProjectile()
	{
		// This function will be overridden in the subclasses for each tower.
		shootAnimDone = false;
		anim.SetBool("ShootAnimDone", shootAnimDone);
		// HACK: I'll need to flip/decide the art later
		anim.SetBool("CanShoot", true);
	}

	public void SetTarget(GameObject tar)
	{
		if(currentTarget == null)
		{
			currentTarget = tar;
		}
	}

	public void EnemyEnterRange(GameObject tar)
	{
		if(targets.Contains(tar) == false)
			targets.Add(tar);
	}

	public void EnemyExitRange(GameObject enemy)
	{
		targets.Remove(enemy);
		if(enemy == currentTarget && targets.Count > 0)
		{
			currentTarget = null;
			FindNextTarget();
		}
	}

	public void FindNextTarget()
	{
		// Different enum values will determine the type of search algorithm used to target the next enemy
		switch(searchType)
		{
			case TargetSearchType.Closest:
				FindClosestTarget();
				break;
			case TargetSearchType.Weakest:
				FindWeakestTarget();
				break;
			case TargetSearchType.Strongest:
				FindStrongestTarget();
				break;
		}
	}

	/////////////// SORTING FUNCTIONS //////////////////
	private void FindClosestTarget()
	{
		targets.Sort(delegate(GameObject o1, GameObject o2)
		{
			return (this.transform.position - o1.transform.position).sqrMagnitude.CompareTo((
				this.transform.position - o2.transform.position).sqrMagnitude);
		});

		currentTarget = targets[0];
	}

	private void FindWeakestTarget()
	{

	}

	private void FindStrongestTarget()
	{

	}
}
