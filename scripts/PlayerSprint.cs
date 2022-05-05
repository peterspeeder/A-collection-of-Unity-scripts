using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    PlayerMovement playerMovementScript;
    public float speedBoost = 10f;


    private void Start()
    {
        playerMovementScript = GetComponent<PlayerMovement>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerMovementScript.speed += speedBoost;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerMovementScript.speed -= speedBoost;
        }
    }
}
