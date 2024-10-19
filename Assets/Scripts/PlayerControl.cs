using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField]
    public Weapon wp;
    [SerializeField]
    private Transform transform; //player's transform
    [SerializeField]
    private Rigidbody2D rb; //player's rigidbody2d
    [SerializeField]
    private float moveSpeed, 
                  rotationSpeed;
    private float moveX, moveY;
    private bool walk = false,
                 readyFire = false,
                 firing = false;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        FireButtonCheck();
        SpeedFireControl();
        CombatFunc();
    }
    private void FixedUpdate()
    {
        WalkFunc();
        RotationFunc();
    }
    private void MoveFunc()
    {
        moveX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        moveY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        rb.velocity = new Vector2(moveX, moveY);       

    }
    private void WalkFunc()
    {
        if (Input.GetButton("Walk")){
            walk = true;
            moveSpeed = 15f;
            MoveFunc();
        }
        else
        {
            walk = false;
            moveSpeed = 30f;
            MoveFunc();
        }
    }
    private void RotationFunc()
    {
        Vector3 mouseScreenPos = Input.mousePosition;//get mouse screen pos

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos); //convert to world pos

        Vector2 direction = mouseWorldPos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //Cal angle, convert to Deg 
        Quaternion playerRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, Time.deltaTime * rotationSpeed);//smooth rotation
    }
    private void CombatFunc()
    {
        if (wp.weaponType != "auto")
        {
            if (Input.GetButtonDown("Fire1") && readyFire)
            {
                wp.FireFunc();
                Debug.Log(wp.weaponType + " semi fire mode");
                readyFire = false;
            }
        }
        else
        {
            if(readyFire == true && firing == true)
            {
                wp.FireFunc();
                Debug.Log("auto fire mode");
                readyFire = false;
            }
        }
    }
    private void SpeedFireControl()
    {
            timer += Time.deltaTime;
            if (timer > wp.weaponSpeedFire)
            {
                readyFire = true;
                timer = 0f;
            }
    }
    private void FireButtonCheck()
    {
        if (Input.GetButton("Fire1"))
        {
            firing = true;
        }
        else
        {
            firing = false;
        }
    }
}