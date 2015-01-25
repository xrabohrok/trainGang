using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class trainEngine : MonoBehaviour {

    public string deadlyLayer;
    public bool dead = false;
    public float deathDelay;

    GameObject deathEffect;

    private float timeDead = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (dead)
        {
            timeDead += Time.deltaTime;
            if(timeDead >= deathDelay)
            {
                GameObject.Destroy(this);
                //probably load the next level here.
            }
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        var layerNum = LayerMask.NameToLayer(deadlyLayer);

        if(layerNum == collision.gameObject.layer)
        {
            dead = true;
            if (deathEffect != null)
                GameObject.Instantiate(deathEffect);
        }
    }
}
