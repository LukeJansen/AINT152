using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySurvey : MonoBehaviour {

    // Defining public variables
    public bool up, right, down, left;
    public float moveSpeed;
    public float startDelay = 0;

    // Defining private variables
    private string currentDirection;
    private float lastMoveTime;
    private Vector3 currentRotation;
    private Vector3 upRot, rightRot, downRot, leftRot;
    private Vector3 newRot;
    
	// Use this for initialization
	void Start () {

        // Initialise all of the rotation variables with the correct values.
        upRot = (new Vector3(0, 0, 0));
        rightRot = (new Vector3(0, 0, 270));
        downRot = (new Vector3(0, 0, 180));
        leftRot = (new Vector3(0, 0, 90));

        // Set up first rotation.
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
        // If the agent has not detected a player
        if (GetComponent<AgentBehaviour>().player == null)
        {
            // Create a smooth transition to the new rotation.
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, newRot, Time.deltaTime * 3);

            // If the agent has a start delay make sure to wait before moving them
            if (Time.realtimeSinceStartup > startDelay)
            {
                // If it is time for the agent to move again
                if ((Time.time - lastMoveTime) > moveSpeed)
                {

                    // If statement blocks to figure out which direction should be next based upon the choices made.
                    // Order is Up -> Right -> Down -> Left.
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

                    // Reset move time counter.
                    lastMoveTime = Time.time;
                }
            }
        }
	}
}
