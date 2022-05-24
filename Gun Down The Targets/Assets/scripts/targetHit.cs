using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetHit : MonoBehaviour
{
    public bool isHit = false;
    public bool canBeHit = true;
    public bool rotated = false;
    public float Rotspeed = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isHit && canBeHit)
        {
            canBeHit = false;
            rotated = true;
            Debug.Log("werkt");
        }

        if (rotated)
        {
            transform.Rotate(0, 0, Rotspeed);
            Debug.Log(transform.rotation.z);
        }
        if (transform.rotation.z > 0.7)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90); 
            rotated = false;
            Debug.Log("werkt90");
        }
    }
}
