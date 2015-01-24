using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ClickControl))]
public class SoldierSwarm : MonoBehaviour {

    private ClickControl mouseInstance;

    private List<SoldierAI> allSoldiers;
    private List<SoldierAI> selectedSoliers;

	// Use this for initialization
	void Start () {
        allSoldiers = new List<SoldierAI>();
        selectedSoliers = new List<SoldierAI>();

        mouseInstance = this.GetComponent<ClickControl>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(mouseInstance.validPoint)
        {
            if(Input.GetMouseButtonDown(0))
            {
                foreach(var soldier in selectedSoliers)
                {
                    soldier.wasDeSelected();
                }
                selectedSoliers = new List<SoldierAI>();
            }

            if(Input.GetMouseButton(0))
            {
                var mousedSoldier = mouseInstance.thingClicked.GetComponent<SoldierAI>();
                if(!selectedSoliers.Contains(mousedSoldier))
                {
                    selectedSoliers.Add(mousedSoldier);
                    mousedSoldier.wasSelected();
                }
            }
        }
	}

    public void registerSolder(SoldierAI me)
    {
        allSoldiers.Add(me);
    }

}
