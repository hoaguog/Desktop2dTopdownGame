using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField]
    public Weapon wp;
    [SerializeField]
    private Transform transform;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed, 
        rotationSpeed;
    private float moveX, moveY;
    private bool walk = false;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        combatFunc();
    }
    private void FixedUpdate()
    {
        walkFunc();
        rotationFunc();
    }
    private void moveFunc()
    {
        moveX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        moveY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        rb.velocity = new Vector2(moveX, moveY);       

    }
    private void walkFunc()
    {
        if (Input.GetButton("Walk")){
            walk = true;
            moveSpeed = 15f;
            moveFunc();
        }
        else
        {
            walk = false;
            moveSpeed = 30f;
            moveFunc();
        }
    }
    private void rotationFunc()
    {
        Vector3 mouseScreenPos = Input.mousePosition;//get mouse screen pos

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos); //convert to world pos

        Vector2 direction = mouseWorldPos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //Cal angle, convert to Deg 
        Quaternion playerRotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, playerRotation, Time.deltaTime * rotationSpeed);//smooth rotation
    }
    private void combatFunc()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            wp.fireFunc();
        }
    }
}