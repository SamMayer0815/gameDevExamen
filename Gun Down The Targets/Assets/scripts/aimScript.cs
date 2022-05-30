using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimScript : MonoBehaviour
{
    private Animator reloading;
    public GameObject aimPosition;

    private void Start()
    {
        reloading = GameObject.Find("reload").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            aimPosition.transform.localPosition = new Vector3(-0.262f, 0.162f, 0);
        }
        else if (!Input.GetButton("Fire2"))
        {
            aimPosition.transform.localPosition = new Vector3(0, 0, 0);
            Debug.Log("t");
        }

        if (Input.GetKeyDown("r"))
        {
            reloading.Play("Base Layer.reload", 0, 0);
            aimPosition.transform.localPosition = new Vector3(0, 0, 0);
            reloadWait();
        }
    }
    IEnumerator reloadWait()
    {
        yield return new WaitForSeconds(3);
    }
}
