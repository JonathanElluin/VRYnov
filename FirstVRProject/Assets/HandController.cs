using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {
    
    public Transform takenPos;
    public Transform HandHolder;
    private IUsable myUsableItem;
    public bool canCatch = false;
    private bool hasUsableItem;
    public GameObject catchable;
    private Transform InitialTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(canCatch == true && catchable != null)
        {
            if (Input.GetKey(KeyCode.Mouse0) && myUsableItem == null && catchable != null )
            {
                InitialTransform = catchable.transform;
                catchable.gameObject.transform.SetParent(HandHolder);
                catchable.gameObject.transform.position = takenPos.position;
                catchable.gameObject.transform.rotation = takenPos.rotation;
                catchable.GetComponent<Collider>().isTrigger = true;
                catchable.GetComponent<Rigidbody>().useGravity = false;
                try
                {
                    myUsableItem = catchable.GetComponent<GunController>() as IUsable;
                }
                catch(Exception ex)
                {
                  
                }
            }            
        }
        if(myUsableItem != null && Input.GetKeyDown(KeyCode.Mouse0)){
            myUsableItem.Use();
        }

        if(catchable != null && myUsableItem != null && Input.GetKeyDown(KeyCode.Mouse1))
        {
            catchable.gameObject.transform.parent = null;
            catchable.GetComponent<Collider>().isTrigger = false;
            catchable.gameObject.GetComponent<Rigidbody>().useGravity = true;
            myUsableItem.Throw();
            catchable = null;
            myUsableItem = null;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("catchable"))
        {
            canCatch = true;
            catchable = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canCatch = false;
        catchable = null;
    }

}
