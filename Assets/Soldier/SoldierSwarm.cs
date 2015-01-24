using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ClickControl))]
public class SoldierSwarm : MonoBehaviour {

    private ClickControl soldierMouse;

    private static List<SoldierAI> allSoldiers;
    private static List<SoldierAI> selectedSoliers;

	// Use this for initialization
	void Start () {
        allSoldiers = new List<SoldierAI>();
        selectedSoliers = new List<SoldierAI>();

        soldierMouse = this.GetComponent<ClickControl>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(soldierMouse.validPoint)
        {
            handleSoldierSelection();
            handleOrderDelegation();
        }
	}

    public void registerSolder(SoldierAI me)
    {
        allSoldiers.Add(me);
    }

    private void handleSoldierSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var thing = soldierMouse.thingClicked;
            if (thing.GetComponent<SoldierAI>() != null)
            {
                foreach (var soldier in selectedSoliers)
                {
                    soldier.wasDeSelected();
                }
                selectedSoliers = new List<SoldierAI>();
            }
        }

        if (Input.GetMouseButton(0))
        {
            var mousedSoldier = soldierMouse.thingClicked.GetComponent<SoldierAI>();
            if (mousedSoldier != null)
            {
                if (!selectedSoliers.Contains(mousedSoldier))
                {
                    selectedSoliers.Add(mousedSoldier);
                    mousedSoldier.wasSelected();
                    Debug.Log("Soldier selected");
                }
            }
        }
    }

    private void handleOrderDelegation()
    {
        if (Input.GetMouseButtonUp(1))
        {
            //interestingly, we want to *not* click a soldier this way
            var mousedSoldier = soldierMouse.thingClicked.GetComponent<SoldierAI>();
            if (mousedSoldier == null)
            {
                foreach(var soldier in selectedSoliers)
                {
                    soldier.recieveOrderTo(soldierMouse.clickedPoint);
                    Debug.Log("Set orders to " + selectedSoliers.Count.ToString());
                }
            }
        }
    }

}
