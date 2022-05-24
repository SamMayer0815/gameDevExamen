using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            int childs = transform.childCount;
            for(int i = 0; i < childs; i++)
            {
                transform.GetChild(i).GetChild(0).GetComponent<targetHit>().enteredZone = true;
            }
        }
    }
}
