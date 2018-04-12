using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public int speed;
    private float distance = 0;
    public float maxDistance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        distance += Time.deltaTime;

        if(distance >= maxDistance)
        {
            Destroy(gameObject);
        }
	}
}
