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
            transform.Rotate(0, 0, 90);
            canBeHit = false;
            rotated = true;
            Debug.Log("werkt");
        }

        if (rotated)
        {
            transform.Rotate(0, 0, Rotspeed);
            Debug.Log("werkt3");
        }
        if (transform.rotation.y >= 90)
        {
            transform.Rotate(0, 0, 90);
            Debug.Log("werkt90");
            rotated = true;
        }
    }
}
