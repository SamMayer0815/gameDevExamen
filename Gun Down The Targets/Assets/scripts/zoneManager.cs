using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneManager : MonoBehaviour
{
    private bool hasBeenEntered = false;
    Collider collider;
    private void Start()
    {
        collider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider col)
    {
        //checks if the player entered the zone and if he hasent entered it before
        if (col.gameObject.tag == "Player" && !hasBeenEntered)
        {
            hasBeenEntered = true;
            collider.enabled = !collider.enabled;
            //sets childs to ammount of targets in zone
            int childs = transform.childCount;
            //for each target in the area it sets that the player has entered the zone so that the target goes up
            for(int i = 0; i < childs; i++)
            {
                transform.GetChild(i).GetChild(0).GetComponent<targetHit>().enteredZone = true;
            }
        }
    }
}
    