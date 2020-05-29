using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WASDMovement : MonoBehaviour
{

    public float walkSpeed = 5f;
    private Rigidbody rigidbody;

    private Vector3 playerPosition;

    // Movement indicators
    public Text playerInfo;
    public GameObject idleIndicator;
    public GameObject walkingIndicator;
    public GameObject runningIndicator;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerPosition = transform.position;
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;

        // Move the player using WASD
        var moveVector = new Vector3(walkSpeed * Input.GetAxis("Horizontal") * Time.fixedDeltaTime, 0f,
            walkSpeed * Input.GetAxis("Vertical") * Time.fixedDeltaTime);
        

        // If the player is walking normally
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (Math.Abs(moveVector.sqrMagnitude) > 0.001f)
            {
                walkSpeed = 5f;
                Footsteps.WalkingFootsteps();

                playerInfo.text = "Walking";
                idleIndicator.SetActive(false);
                walkingIndicator.SetActive(true);
                runningIndicator.SetActive(false);
            }
            else
            {
                playerInfo.text = "Idle";
                idleIndicator.SetActive(true);
                walkingIndicator.SetActive(false);
                runningIndicator.SetActive(false);
            }
        }
        // If the player is running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Math.Abs(moveVector.sqrMagnitude) > 0.001f)
            {
                walkSpeed = 10f;

                playerInfo.text = "Running";
                Footsteps.RunningFootsteps();
                idleIndicator.SetActive(false);
                walkingIndicator.SetActive(false);
                runningIndicator.SetActive(true);
            }
            else
            {
                playerInfo.text = "Idle";
                idleIndicator.SetActive(true);
                walkingIndicator.SetActive(false);
                runningIndicator.SetActive(false);
            }
        }

        rigidbody.MovePosition(transform.position + transform.TransformDirection( moveVector));
    }

    // Function to be called from the DayNightCycle script when changing day
    public void RespawnPlayer()
    {
        transform.position = playerPosition;
    }
}
