using UnityEngine;
using System.Collections;


public class SoldierAI : MonoBehaviour, Ishootable {


    private bool selected = false;
    private bool onTheMove = false;
    public float speed = 1.0f;
    public float stopDist = .1f;
    Vector3 targetLocation;

    private Animation anim;
    private CharacterController controller;
    
	// Use this for initialization
	void Start () {
        anim = this.GetComponentInChildren<Animation>();
        if (anim == null)
            throw new System.Exception("No animator!");
        controller = this.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
	
        if(onTheMove)
        {
            anim.Play("run");

            //rotate
            var newRotation = Vector3.RotateTowards(controller.transform.forward, targetLocation, Mathf.PI, Mathf.PI);
            //this.transform.LookAt(targetLocation, Vector3.up);
            controller.transform.LookAt(targetLocation, Vector3.up);

            //move
            var step = speed * Time.deltaTime;
            var floatingDirection = (targetLocation - controller.transform.position).normalized * step;
            var finalDirection = new Vector3(floatingDirection.x, -3, floatingDirection.z);
            controller.Move(finalDirection);


            //Don't get too close
            if(Vector3.Distance(this.transform.position, targetLocation) <= stopDist)
            {
                onTheMove = false;
            }
        }
        else
        {
            anim.Play("idle");
        }
	}

    public void wasSelected()
    {
        selected = true;
    }

    public void wasDeSelected()
    {
        selected = false;
    }

    public void recieveOrderTo(Vector3 location)
    {
        if (selected)
        {
            targetLocation = new Vector3(location.x, controller.transform.position.y, location.z);
            onTheMove = true;
        }
    }

    public void takeDamage(int damage)
    { 
		var stats = this.gameObject.GetComponent<Stats> ();
        if(stats != null)
		    stats.hit (damage);
		//if (stats.dead == true)
			//GameObject.Find ("SoldierController").GetComponent<SoldierSwarm> ().deregisterSolder (this);

	}
}
