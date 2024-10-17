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
    private int weaponType;
    [SerializeField]
    private string weaponName;
    [SerializeField]
    private float rateFire;

    private bool countinueFire = true;
    private float timer = 0f;

    public Transform weaponPosFire;

    

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
        //if(timer > rateFire)
        //{
        //    fireFunc();
        //    timer = 0f;
        //}
    }
    private void FixedUpdate()
    {
        
    }
    private void mouseCheck()
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
    public void fireFunc()
    {
        GameObject bullets = (Instantiate(bulletPrefab, weaponPosFire.position, weaponPosFire.rotation));
        bullets.GetComponent<Rigidbody2D>().AddForce(weaponPosFire.up * bulletPrefab.GetComponent<Bullet>().getAmmoSpeed, ForceMode2D.Impulse);
        //bullets.GetComponent<Rigidbody2D>().gravityScale = 0;
        Debug.Log("ammospeed is" + bulletPrefab.GetComponent<Bullet>().getAmmoSpeed);
    }
    
}

