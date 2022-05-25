using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetHit : MonoBehaviour
{
    public bool isHit = false;
    public bool canBeHit = false;
    public bool rotateDown = false;
    public bool rotateUp = false;
    public bool enteredZone = false;
    public float rotSpeedUp = -0.2f;
    public float rotSpeedDown = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        //sets the rotation to down when it starts
        transform.Rotate(0, 0, 90);
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit && canBeHit)
        {
            canBeHit = false;
            rotateDown = true;
            rotateUp = false;
        }

        if (enteredZone)
        {
            rotateUp = true;
            enteredZone = false;
        }
        //starts rotating up
        if (rotateUp)
        {
            transform.Rotate(0, 0, rotSpeedUp);
        }
        // if it has rotated far enough it stops retating and stops the rotating
        if (transform.rotation.z < 0 && rotateUp)
        {
            transform.Rotate(0, 0, 0);
            rotateUp = false;
            // if person entered the zone it goes up then when it has reached the correct rotation it can be shot
            canBeHit = true;
        }
        //starts rotating down
        if (rotateDown)
        {
            transform.Rotate(0, 0, rotSpeedDown);
        }
        // if it has rotated far enough it stops retating and stops the rotating
        if (transform.rotation.z > 0.6 && rotateDown)
        {
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 90);
            //transform.Rotate(0, 0, 90.0f);
            rotateDown = false;
        }
    }
}
