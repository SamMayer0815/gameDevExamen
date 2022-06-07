using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    [Header("Camera")]
    public Camera lookDir;

    [Header("UI")]
    public UIManager uiManager;

    [Header("Targets")]
    public int enemiesKilled;
    public int civiliansKilled;

    [Header("gameObject")]
    public GameObject impactEffect;

    public void shoot()
    {
            //Saves the information of hit target
            RaycastHit hit;
            //Checks if i hit something
            if (Physics.Raycast(lookDir.transform.position, lookDir.transform.forward, out hit))
            {
                //Checks if i hit the target body
                if(hit.transform.name == "targetBody")
                {
                    //if i hit enemy target update the enemy killed text
                    if (hit.transform.parent.name == "targetEnemy" && hit.transform.parent.parent.GetComponent<targetHit>().canBeHit == true)
                    {
                        enemiesKilled++;
                        uiManager.enemyHit(enemiesKilled);
                    }
                    //if i hit civilian target update the civilian killed text
                    if (hit.transform.parent.name == "targetCivilian" && hit.transform.parent.parent.GetComponent<targetHit>().canBeHit == true)
                    {
                        civiliansKilled++;
                        uiManager.civilianHit(civiliansKilled);
                    }
                    //Checks if i hit an enemy and if it could be hit
                    if (hit.transform.tag == "Target" && hit.transform.parent.parent.GetComponent<targetHit>().canBeHit == true)
                    {
                        //Tells the target it has been hit
                        hit.transform.parent.parent.GetComponent<targetHit>().isHit = true;
                    }
                //spawns hit effect on target hit location
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                //starts a wait timer
                StartCoroutine(wait());
            }
            }
        }

    IEnumerator wait()
    {
        //after 0.1 seconds delete the impact clone
        yield return new WaitForSeconds(0.1f);
        Destroy(GameObject.Find("impact(Clone)"));

    }
}