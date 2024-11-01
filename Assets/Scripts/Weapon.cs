using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    [SerializeField]
    private float fireRange;
    [SerializeField]
    private string typeOfWeapon = "semi";
    [SerializeField]
    private string weaponName;
    [SerializeField]
    private float rateFire = 20f, reloadTime = 1f;
    [SerializeField]
    private int ammoCapacity = 24,
                magazineSize = 6,
                remainingAmmo = 6;
    private bool countinueFire = true,
                 reloading = false;

    //recoil control declare
    [SerializeField]
    private float recoilIntensity = 0.1f,
                  maxRecoil = 5f,
                  resetSpeed = 0.05f;
    private float currentRecoilAngle = 0f;



    public Transform weaponPosFire;

    public float weaponSpeedFire { get { return rateFire; } }
    public string weaponType { get { return typeOfWeapon; } }
    public float weaponReloadTime { get { return reloadTime; } }
    public bool isReloading
    {
        get { return reloading; }
        set { reloading = value; }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {

    }

    //recoi logic 


    public void FireFunc()
    {
        if (remainingAmmo > 0)
        {
            GameObject bullets = (Instantiate(bulletPrefab, weaponPosFire.position, weaponPosFire.rotation));
            bullets.GetComponent<Rigidbody2D>().AddForce(weaponPosFire.up * bulletPrefab.GetComponent<Bullet>().getAmmoSpeed, ForceMode2D.Impulse);
            //Debug.Log("ammospeed is" + bulletPrefab.GetComponent<Bullet>().getAmmoSpeed);
            remainingAmmo--;

        }
        else
        {
            Debug.Log("out ammo");
        }

    }
    public IEnumerator ReloadFunc()
    {
        if (ammoCapacity > 0)
        {
            if (ammoCapacity + remainingAmmo >= magazineSize)
            {
                reloading = true;
                yield return new WaitForSeconds(reloadTime);
                ammoCapacity = ammoCapacity + remainingAmmo - magazineSize;
                remainingAmmo = magazineSize;
                reloading = false;
                //Debug.Log("ammoCapacity: "+ ammoCapacity + " remainAmmo:  " + remainingAmmo);
            }
            else
            {
                reloading = true;
                yield return new WaitForSeconds(reloadTime);
                ammoCapacity = 0;
                remainingAmmo = ammoCapacity + remainingAmmo;
                reloading = false;
                //Debug.Log("ammoCapacity: " + ammoCapacity + " remainAmmo:  " + remainingAmmo);
                //Debug.Log("reloadding: " + reloading);
            }
        }

    }




}

