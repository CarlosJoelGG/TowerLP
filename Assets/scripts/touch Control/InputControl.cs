using UnityEngine;
using System.Collections.Generic;

public class InputControl : MonoBehaviour
{
   
    public Joystick joy; 
    public float speed, speedLimit, velStart,velEnd, acc, moveH, moveV;
    private Vector3 dir;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (velStart == 0) velStart = 7;
        if (velEnd == 0) velEnd = 15;
        if (acc == 0) acc = 2;
        

    }

    // Update is called once per frame
    void Update()
    {

        
        moveH = -joy.Horizontal;
        moveV = -joy.Vertical;

        if (moveH != 0 || moveV != 0)
        {
            /*
            if (speed == 0)
            {
                speed = velStart;
            }
            if (speed > 0)
            {
                speed += acc *Time.deltaTime;
            }
            if(speed > speedLimit)
            {
                speed = speedLimit;
            }
            */

            speed = speedLimit;


            dir = transform.forward*moveV+transform.right*moveH;

            

            
            
        }
        else
        {
            dir = Vector3.zero;
            float px = transform.position.x ;
            float ccx = Mathf.Abs(Mathf.Floor(px));
            float cx = Mathf.Abs(px) - ccx;
            if (cx > 0 || cx < 0.3f) cx = 0;
            if (cx >= 0.3f || cx < 0.7f) cx = 0.5f;
            if (cx >= 0.7f || cx < 1) cx = 1f;




            float pz = transform.position.z ;
            float ccz = Mathf.Abs(Mathf.Floor(pz));
            float cz = Mathf.Abs(pz) - ccz;
            if (cz > 0 || cz < 0.3f) cz = 0;
            if (cz >= 0.3f || cz < 0.7f) cz = 0.5f;
            if (cz >= 0.7f || cz < 1) cz = 1f;


            Vector3 newPosition = new Vector3(Mathf.Floor(px) + cx, 0, Mathf.Floor(pz) + cz);

            if (transform.position == newPosition)
            {
                speed = 0;
            }
            //Debug.Log(newPosition);

        }

        rb.MovePosition(transform.position + dir * speed * Time.deltaTime);

       

    }
}
