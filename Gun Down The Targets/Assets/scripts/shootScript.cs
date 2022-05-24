using UnityEngine;

public class shootScript : MonoBehaviour
{
    public Camera lookDir;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }

    void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(lookDir.transform.position, lookDir.transform.forward, out hit))
        {
            if(hit.transform.tag == "Enemy")
            {
                hit.transform.parent.parent.GetComponent<targetHit>().isHit = true;
            }
        }


    }
}