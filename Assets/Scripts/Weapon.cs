using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

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
    private float rateFire = 20f;

    private bool countinueFire = true;

    public Transform weaponPosFire;
    public float weaponSpeedFire { get { return rateFire; } }
    public string weaponType { get { return typeOfWeapon; } }



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
    private void MouseCheck()
    {
        if (Input.GetMouseButton(0))
        {
            countinueFire = true;
        }
        else
        {
            countinueFire = false;
        }
    }
    public void FireFunc()
    {
        GameObject bullets = (Instantiate(bulletPrefab, weaponPosFire.position, weaponPosFire.rotation));
        bullets.GetComponent<Rigidbody2D>().AddForce(weaponPosFire.up * bulletPrefab.GetComponent<Bullet>().getAmmoSpeed, ForceMode2D.Impulse);
        Debug.Log("ammospeed is" + bulletPrefab.GetComponent<Bullet>().getAmmoSpeed);
    }
    
}

