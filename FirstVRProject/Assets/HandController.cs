using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {
    
    public Transform takenPos;
    public bool canCatch = false;
    public GameObject catchable;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(canCatch == true && catchable != null)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                catchable.gameObject.transform.SetParent(gameObject.transform);
                catchable.GetComponent<Collider>().isTrigger = true;
                catchable.transform.position = takenPos.position;
                catchable.transform.rotation = gameObject.transform.rotation;
            }            
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        canCatch = true;
        catchable = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        canCatch = false;
        catchable = null;
    }

}
