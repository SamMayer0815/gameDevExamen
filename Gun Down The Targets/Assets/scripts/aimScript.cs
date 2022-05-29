using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimScript : MonoBehaviour
{
    [SerializeField] private Animator aiming;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            aiming.SetBool("isAiming", true);
        }else
        {
            aiming.SetBool("isAiming", false);
        }
    }
}
//(0.33, -0.28, 0.56)
