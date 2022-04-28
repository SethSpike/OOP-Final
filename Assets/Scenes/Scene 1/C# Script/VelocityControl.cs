using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityControl : MonoBehaviour
{
    public float maxSpeed = 16f;//Max Speed
    public GameObject launchPoint;

    void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
    }

    void FixedUpdate()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude > maxSpeed)
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;;
        }
        if (GetComponent<Rigidbody>().velocity.magnitude > 1)
        {
            launchPoint.SetActive(false);
        }
        if (GetComponent<Rigidbody>().velocity.magnitude < 1)
        {
            launchPoint.SetActive(true);
        }
        /*Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);*/
    }
}

/*answers.unity.com/questions/265810/limiting-rigidbody-speed.html*/
