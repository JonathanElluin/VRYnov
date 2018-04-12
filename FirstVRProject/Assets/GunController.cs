using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour,IUsable {

    public GameObject Bullet;
    public Transform BulletSpawn;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Throw()
    {
        gameObject.transform.parent = null;
        GetComponent<Collider>().isTrigger = false;
        gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 500);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    public void Use()
    {
        Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
    }

}
