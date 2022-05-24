using UnityEngine;

public class shootScript : MonoBehaviour
{
    public Camera lookDir;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Saves the information of hit target
            RaycastHit hit;
            //Checks if i hit something
            if (Physics.Raycast(lookDir.transform.position, lookDir.transform.forward, out hit))
            {
                //Checks if i hit an enemy and if it could be hit
                if (hit.transform.tag == "Target" && hit.transform.parent.parent.GetComponent<targetHit>().canBeHit == true)
                {
                    //Tells the target it has been hit
                    hit.transform.parent.parent.GetComponent<targetHit>().isHit = true;
                }
            }
        }
    }
}