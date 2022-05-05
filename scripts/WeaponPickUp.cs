using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public Transform equipPostition;
    public float distance = 10f;
    GameObject currentWeapon;
    GameObject wp;

    bool canGrab;


    private void Update()
    {
        Checkweapons();

        if (canGrab)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (currentWeapon != null)
                    Drop();
                pickUp();
            }
        }

        if(currentWeapon != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                Drop();
        }
    }

    private void Checkweapons()
    {
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "canGrab")
            {
                canGrab = true;
                wp = hit.transform.gameObject;
            }
        }
        else
        
            canGrab = false;
        
    }

    private void pickUp()
    {
        currentWeapon = wp;  
        currentWeapon.transform.position = equipPostition.position;
        currentWeapon.transform.parent = equipPostition;
        currentWeapon.transform.localEulerAngles = new Vector3(0f, 90f, 0f);

        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon = null;
    }
}