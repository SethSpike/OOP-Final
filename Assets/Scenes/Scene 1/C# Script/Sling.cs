using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour
{
    public Vector2 holdPoint;
    public Vector2 releasePoint;
    public float power;
    public Vector2 direction = new Vector2(999, 999);
    public bool held = false;
    public bool holdSwitch = false;
    //Squish
    /*public GameObject MainCharacter;*/
    //grounded
    public bool isGrounded;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        detectHold();
        detectRelease();
    }

    void detectHold()
    {
        if (held == false & holdSwitch == false)
        {
            holdPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            applyForce();
            //Squish
            /* MainCharacter = GameObject.FindWithTag("MainCharacter");
             MainCharacter.transform.localScale = new Vector3(100, 100, 100);*/
        }
        if (Input.GetMouseButton(0))
        {
            held = true;
            holdSwitch = true;
            //Squish
            /* MainCharacter = GameObject.FindWithTag("MainCharacter");
             MainCharacter.transform.localScale = new Vector3(100, 100, 75);*/
        }
        else
        {
            held = false;
        }
    }

    void detectRelease()
    {
        if (held == false & holdSwitch == true && isGrounded)
        {
            holdSwitch = false;
            releasePoint = cam.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(Vector2.Distance(releasePoint, holdPoint));
            power = Vector2.Distance(releasePoint, holdPoint);
            Debug.Log(power);
            direction = new Vector2(releasePoint.x - holdPoint.x, releasePoint.y - holdPoint.y);
            //Grounded
            isGrounded = false;
        }
    
    }

    void directRatio()
    {
        if (direction.x != 999 & direction.y != 999)
        {
            direction.x /= Mathf.Abs(direction.x);
            direction.y /= Mathf.Abs(direction.x);
            Debug.Log(direction);
        }
    }

    void applyForce()
    {
        //directRatio();

        if (direction.x != 999 & direction.y != 999)
        {
            Vector3 velocity = new Vector3(direction.x, direction.y, 0);
            gameObject.GetComponent<Rigidbody>().velocity = velocity;
            direction = new Vector2(999, 999);
        }
    }
    //Grounded
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("ground") && isGrounded == false)
        {
            isGrounded = true;
        }
    }
}


//Wayne
/*answers.unity.com/questions/1170474/i-need-jump-only-one-time.html*/