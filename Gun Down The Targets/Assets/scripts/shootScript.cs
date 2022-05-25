using UnityEngine;

public class shootScript : MonoBehaviour
{
    public Camera lookDir;

    private UIManager uiManager;
    private int enemiesKilled;
    private int civiliansKilled;

    void Start()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
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
                //Checks if i hit the target body
                if(hit.transform.name == "targetBody")
                {
                    //if i hit enemy target update the enemy killed text
                    if (hit.transform.parent.name == "targetEnemy" && hit.transform.parent.parent.GetComponent<targetHit>().canBeHit == true)
                    {
                        Debug.Log("test");
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
                }
            }
        }
    }
}