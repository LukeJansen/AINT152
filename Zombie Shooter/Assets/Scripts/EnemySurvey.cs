using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySurvey : MonoBehaviour {

    public bool up, right, down, left;
    public float moveSpeed;
    public float startDelay = 0;

    private string currentDirection;
    private Vector3 currentRotation;
    private float lastMoveTime;

    private Vector3 upRot, rightRot, downRot, leftRot;
    private Vector3 newRot;
    
	// Use this for initialization
	void Start () {

        upRot = (new Vector3(0, 0, 0));
        rightRot = (new Vector3(0, 0, 270));
        downRot = (new Vector3(0, 0, 180));
        leftRot = (new Vector3(0, 0, 90));


        if (up)
        {
            newRot = upRot;
            currentDirection = "up";
        } else if (right)
        {
            newRot = rightRot;
            currentDirection = "right";
        } else if (down)
        {
            newRot = downRot;
            currentDirection = "down";
        } else if (left)
        {
            newRot = leftRot;
            currentDirection = "left";
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (GetComponent<AgentBehaviour>().player == null)
        {
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, newRot, Time.deltaTime * 3);
            if (Time.realtimeSinceStartup > startDelay)
            {
                
                if ((Time.time - lastMoveTime) > moveSpeed)
                {
                    if (currentDirection == "up")
                    {
                        if (right)
                        {
                            currentDirection = "right";
                            newRot = rightRot;

                        }
                        else if (down)
                        {
                            newRot = downRot;
                            currentDirection = "down";
                        }
                        else if (left)
                        {
                            newRot = leftRot;
                            currentDirection = "left";
                        }
                    }

                    else if (currentDirection == "right")
                    {
                        if (down)
                        {
                            newRot = downRot;
                            currentDirection = "down";
                        }
                        else if (left)
                        {
                            newRot = leftRot;
                            currentDirection = "left";
                        }
                        else if (up)
                        {
                            currentDirection = "up";
                            newRot = upRot;
                        }
                    }

                    else if (currentDirection == "down")
                    {
                        if (left)
                        {
                            newRot = leftRot;
                            currentDirection = "left";
                        }
                        else if (up)
                        {
                            newRot = upRot;
                            currentDirection = "up";
                        }
                        else if (right)
                        {
                            newRot = rightRot;
                            currentDirection = "right";
                        }
                    }

                    else if (currentDirection == "left")
                    {
                        if (up)
                        {
                            newRot = upRot;
                            currentDirection = "up";
                        }
                        else if (right)
                        {
                            newRot = rightRot;
                            currentDirection = "right";
                        }
                        else if (down)
                        {
                            newRot = downRot;
                            currentDirection = "down";
                        }
                    }

                    lastMoveTime = Time.time;
                }
            }
        }
	}
}
