using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class aimScript : MonoBehaviour
{
    public UIManager uiManager;
    private Animator reloading;
    public GameObject aimPosition;
    public ParticleSystem muzzleFlash;
    public int curAmmo = 30;
    public bool allowFire = true;
    public bool isReloading = false;
    public shootScript shoot_;
    public AudioSource source;
    public AudioClip gunShot;
    public AudioClip reloadSound;
    private void Start()
    {
        reloading = GameObject.Find("reload").GetComponent<Animator>();
        shoot_ = GameObject.Find("player").GetComponent<shootScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            aimPosition.transform.localPosition = new Vector3(-0.262f, 0.1602f, -0.366f);
        }
        else if (!Input.GetButton("Fire2"))
        {
            aimPosition.transform.localPosition = new Vector3(0, 0, 0);
        }

        if (Input.GetKeyDown("r") && !isReloading)
        {
            isReloading = true;
            reloading.Play("Base Layer.reload", 0, 0);
            aimPosition.transform.localPosition = new Vector3(0, 0, 0);
            source.PlayOneShot(reloadSound);
            StartCoroutine(reloadWait());
        }

        if (Input.GetButton("Fire1") && allowFire && curAmmo > 0 && !isReloading)
        {
            shoot_.shoot();
            muzzleFlash.Play();
            source.PlayOneShot(gunShot);
            StartCoroutine(fire());
        }
    }
    IEnumerator reloadWait()
    {
        yield return new WaitForSeconds(2f);
        isReloading = false;
        curAmmo = 30;
        uiManager.currentAmmo(curAmmo);
    }

    IEnumerator fire()
    {
        allowFire = false;
        curAmmo = curAmmo - 1;
        uiManager.currentAmmo(curAmmo);
        yield return new WaitForSeconds(0.15f);
        allowFire = true;
    }
}
