using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GunScript : MonoBehaviour
{
    public float dmg = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;
    public float ammo;
    public float maxAmmo;
    public float ammoClipAmount;

    public Camera fpsCam;

    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public TextMeshProUGUI displayAmmo;
    public TextMeshProUGUI displayReload;
    public Vector3 gunRecoil;
    public Vector3 originalRecoil;

    public GameObject enemy;
    public GameObject hitmarker;

    private float timeToFire = 0f;

    private InputManager inputManager;

    void Start()
    {
        //inputManager = GetComponent<InputManager>();
        hitmarker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && Time.time >= timeToFire && ammo > 0 && ammoClipAmount >= 0) // todo: change to new input
        {
            timeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && ammoClipAmount > 0 && ammo != maxAmmo) // todo: change to new input
        {
            Reload();
        }

        if (Input.GetMouseButtonUp(0))
        {
            transform.localPosition = originalRecoil;
        }

        displayAmmo.text = ammo.ToString() + " / " + (maxAmmo * ammoClipAmount);
        
        if (ammo == 0)
        {
            displayReload.text = "Press [R] to Reload";
        } else
        {
            displayReload.text = null;
        }

    }

    public void Shoot()
    {
        ammo -= 1;
        muzzleFlash.Play();
        RaycastHit hit;

        transform.localPosition = gunRecoil;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.takeDmg(dmg);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactObject =  Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactObject, 2f);
            hitMarker();
        }
    }

    public void Reload()
    {
        ammo = maxAmmo;
        ammoClipAmount -= 1;
    }

    private void hitMarker()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.name == enemy.name)
            {
                Debug.Log("Hitmarker: " + hit.collider.tag);
                hitmarker.SetActive(true);
                Invoke("hitRemove", 0.2f);
            } else
            {
                hitmarker.SetActive(false);
            }
        }
    }

    private void hitRemove()
    {
        hitmarker.SetActive(false);
    }

    //private void gunInput()
    //{
    //    if (GetComponent<InputManager>().onFoot.WeaponFire.triggered && Time.time >= timeToFire && ammo > 0 && ammoClipAmount >= 0)
    //    {
    //        timeToFire = Time.time + 1f / fireRate;
    //        Shoot();
    //    }

    //    if (GetComponent<InputManager>().onFoot.Reload.triggered && ammoClipAmount > 0)
    //    {
    //        Reload();
    //    }

    //    if (GetComponent<InputManager>().onFoot.WeaponFire.triggered)
    //    {
    //        transform.localPosition = originalRecoil;
    //    }
    //}
}
