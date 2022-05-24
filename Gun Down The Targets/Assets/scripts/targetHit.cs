using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetHit : MonoBehaviour
{
    public bool isHit = false;
    public bool canBeHit = false;
    public bool rotatedDown = false;
    public bool rotatedUp = false;
    public bool enteredZone = false;
    public float rotSpeedUp = -2f;
    public float rotSpeedDown = 2f;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        if(isHit && !canBeHit)
        {
            isHit = false;
        }

        if (isHit && canBeHit)
        {
            canBeHit = false;
            rotatedDown = true;
            rotatedUp = false;
        }

        if (enteredZone)
        {
            rotatedUp = true;
            enteredZone = false;
        }

        if (rotatedUp)
        {
            transform.Rotate(0, 0, rotSpeedUp);
        }

        if (transform.rotation.z < 0 && rotatedUp)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rotatedUp = false;
            canBeHit = true;
        }

        if (rotatedDown)
        {
            transform.Rotate(0, 0, rotSpeedDown);
        }

        if (transform.rotation.z > 0.7 && rotatedDown)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            rotatedDown = false;
        }
    }
}
