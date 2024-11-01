using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class CameraFolow : MonoBehaviour
{
    public Transform playerTransform;
    public Transform tranform;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        Vector3 cameraPosition = playerTransform.position + offset;

        Vector3 smootedPosiotion = Vector3.Lerp(transform.position, cameraPosition, smoothSpeed * Time.deltaTime);

        tranform.position = smootedPosiotion;

        tranform.LookAt(playerTransform);
    }
}
