using UnityEngine;

public class zoneManager : MonoBehaviour
{
    private bool hasBeenEntered = false;
    Collider collider_;

    private void Start()
    {
        collider_ = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider col)
    {
        //checks if the player entered the zone and if he hasent entered it before
        if (col.gameObject.tag == "Player" && !hasBeenEntered)
        {
            hasBeenEntered = true;
            //turns collider off
            collider_.enabled = !collider_.enabled;
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
    