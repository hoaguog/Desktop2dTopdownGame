using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float ammoSpeed = 10f;
    [SerializeField]
    private enum AmmoType
    {
        melee, //0
        pistol, //1
        smg, //2
        rifle, //3
        shotgun //4
    }
    [SerializeField]
    private AmmoType currentAmmoType;
    public int GetAmmoType
    {
        get { return ((int)currentAmmoType); } 
    }
    public int SetAmmoType
    {
        set { currentAmmoType = (AmmoType)value; } 
    }

    public float getAmmoSpeed { get { return ammoSpeed; } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BOT"))
        {
            Destroy(other.gameObject);
            Debug.Log("enemy destroy");
        }

        if(other.gameObject.tag != "Bullet")
        {
            Destroy(gameObject);
        }
        Debug.Log("bullet destroy");
    }

}
