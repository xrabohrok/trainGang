using UnityEngine;
using System.Collections;

public class unitController : MonoBehaviour, Ishootable {

	public float attackSpeed = 1.0F;
	public float projectileSpeed = 1.0F;
    public string enemyTag;
	public GameObject projectile;
    public Transform gunBarrel;
	public float rangeSQRT = 7.0f;

	private bool attacking;
	private float timeSinceLastFire;


	// Use this for initialization
	void Start () {
        timeSinceLastFire = attackSpeed;
        if (gunBarrel == null)
            throw new System.Exception("no gunBarrel defined!");
	}
	
	// Update is called once per frame
	void Update () {

		//Check for enemies to attack.
		var currentTarget = FindClosestEnemy ();


        timeSinceLastFire += Time.deltaTime;
		
		if (currentTarget != null) {
            if (timeSinceLastFire >= attackSpeed)
            {
				var shot = (GameObject) Instantiate (projectile, gunBarrel.transform.position, this.transform.rotation);
                shot.GetComponent<projectile>().target = currentTarget;
                timeSinceLastFire = 0;
			}
		}

	}

	//returns the closest obj with given tag.
	GameObject FindClosestEnemy() {

		var army = GameObject.FindGameObjectsWithTag(enemyTag);
		GameObject closest = null;
        float distance = rangeSQRT;

		foreach (var enemy in army) 
        {
            Debug.Log(enemy);
            Vector3 diff = enemy.transform.position - transform.position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) 
            {
				closest = enemy;
				distance = curDistance;
			}
		}
		return closest;
	}

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Mathf.Sqrt(rangeSQRT));
    }

    public void takeDamage(int damage)
    { }

}
