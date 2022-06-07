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

    [Header("ammo")]
    public int curAmmo = 30;
    public bool allowFire = true;
    public bool isReloading = false;

    [Header("script")]
    public shootScript shoot_;

    [Header("Audio")]
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
        //if right click move gun to downsight location
        if (Input.GetButton("Fire2"))
        {
            aimPosition.transform.localPosition = new Vector3(-0.262f, 0.1602f, -0.366f);
        }
        else if (!Input.GetButton("Fire2"))
        {
            aimPosition.transform.localPosition = new Vector3(0, 0, 0);
        }
        //if press r and not currently reloading start reloading
        if (Input.GetKeyDown("r") && !isReloading)
        {
            isReloading = true;
            reloading.Play("Base Layer.reload", 0, 0);
            aimPosition.transform.localPosition = new Vector3(0, 0, 0);
            source.PlayOneShot(reloadSound);
            StartCoroutine(reloadWait());
        }
        //if left click, can fire, ammo is more than 0 and arent currently reloading shoot
        if (Input.GetButton("Fire1") && allowFire && curAmmo > 0 && !isReloading)
        {
            shoot_.shoot();
            muzzleFlash.Play();
            source.PlayOneShot(gunShot);
            StartCoroutine(fire());
        }
    }
    //waits for 2 seconds before giving the ammo and updating ammo
    IEnumerator reloadWait()
    {
        yield return new WaitForSeconds(2f);
        isReloading = false;
        curAmmo = 30;
        uiManager.currentAmmo(curAmmo);
    }
    //limits fire rate
    IEnumerator fire()
    {
        allowFire = false;
        curAmmo = curAmmo - 1;
        uiManager.currentAmmo(curAmmo);
        yield return new WaitForSeconds(0.15f);
        allowFire = true;
    }
}
