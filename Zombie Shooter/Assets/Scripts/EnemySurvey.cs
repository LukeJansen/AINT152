using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySurvey : MonoBehaviour {

    public bool up, right, down, left;
    public float moveSpeed;

    public string currentDirection;
    private Vector3 currentRotation;
    private float lastMoveTime;

    private Vector3 upRot, rightRot, downRot, leftRot;
    private Quaternion newRot;
    
	// Use this for initialization
	void Start () {

        upRot = (new Vector3(0, 0, 0));
        rightRot = (new Vector3(0, 0, 270));
        downRot = (new Vector3(0, 0, 180));
        leftRot = (new Vector3(0, 0, 90));


        if (up)
        {
            transform.Rotate(new Vector3(0, 0, 0));
            currentDirection = "up";
        } else if (right)
        {
            transform.Rotate(new Vector3(0, 0, -90));
            currentDirection = "right";
        } else if (down)
        {
            transform.Rotate(new Vector3(0, 0, -180));
            currentDirection = "down";
        } else if (left)
        {
            transform.Rotate(new Vector3(0, 0, -270));
            currentDirection = "left";
        }
	}
	
	// Update is called once per frame
	void Update () {

        if ((Time.time - lastMoveTime) > moveSpeed)
        {
            if (currentDirection == "up")
            {
                if (right)
                {
                    currentDirection = "right";
                    transform.eulerAngles = rightRot;

                }
                else if (down)
                {
                    transform.eulerAngles = downRot;
                    currentDirection = "down";
                }
                else if (left)
                {
                    transform.eulerAngles = leftRot;
                    currentDirection = "left";
                }
            }

            else if (currentDirection == "right")
            {
                if (down)
                {
                    transform.eulerAngles = downRot;
                    currentDirection = "down";
                }
                else if (left)
                {
                    transform.eulerAngles = leftRot;
                    currentDirection = "left";
                }
                else if (up)
                {
                    currentDirection = "up";
                    transform.eulerAngles = upRot;
                }
            }

            else if (currentDirection == "down")
            {
                if (left)
                {
                    transform.eulerAngles = leftRot;
                    currentDirection = "left";
                }
                else if (up)
                {
                    transform.eulerAngles = upRot;
                    currentDirection = "up";
                }
                else if (right)
                {
                    transform.eulerAngles = rightRot;
                    currentDirection = "right";
                }
            }

            else if (currentDirection == "left")
            {
                if (up)
                {
                    transform.eulerAngles = upRot;
                    currentDirection = "up";
                }
                else if (right)
                {
                    transform.eulerAngles = rightRot;
                    currentDirection = "right";
                }
                else if (down)
                {
                    transform.eulerAngles = downRot;
                    currentDirection = "down";
                }
            }

            lastMoveTime = Time.time;
        }
	}
}
