using UnityEngine;
using System.Collections;

public class unitController : MonoBehaviour {

	public float attackSpeed = 1.0F;
	public float projectileSpeed = 1.0F;
	public GameObject projectile;
	public float rangeSQRT = 7.0f;

	private bool attacking;
	private GameObject target;
	private float timeSinceLastFire;


	// Use this for initialization
	void Start () {
        timeSinceLastFire = attackSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		//Check for enemies to attack.
		var currentTarget = FindClosestEnemy ();


        timeSinceLastFire += Time.deltaTime;
		
		if (currentTarget != null) {
            Debug.Log(currentTarget.name.ToString());
            if (timeSinceLastFire >= attackSpeed)
            {
				var shot = (GameObject) Instantiate (projectile, this.transform.position, this.transform.rotation);
				shot.GetComponent<HomingProjectile> ().ttl = 5.0F; 
				shot.GetComponent<HomingProjectile>().target = this.target;
                timeSinceLastFire = 0;
			}
		}
        else
        {
            Debug.Log("nothing found");
        }
	}

	//returns the closest obj with given tag.
	GameObject FindClosestEnemy() {

		var army = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;
        float distance = rangeSQRT;

		foreach (var enemy in army) 
        {
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

}
