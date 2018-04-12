using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour {

    public GameObject wayPoint1;
    public GameObject wayPoint2;
    public GameObject wayPoint3;
    private GameObject way1;
    private GameObject way2;
    private GameObject way3;
    private Vector3 wayPointPos;
    public int speed = 6;
    // Use this for initialization
    void Start () {
        way1 = wayPoint1;
        way2 = null;
        way3 = null;
    }
	
	// Update is called once per frame
	void Update () {
        if (way1 != null)
        {
            wayPointPos = new Vector3(way1.transform.position.x, transform.position.y, way1.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
            if(transform.position == way1.transform.position)
            {
                way1 = null;
                way2 = wayPoint2;
                transform.LookAt(way2.transform.position);
            }
        }
        if (way2 != null)
        {
            wayPointPos = new Vector3(way2.transform.position.x, transform.position.y, way2.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
            if (transform.position == way2.transform.position)
            {
                way2 = null;
                way3 = wayPoint3;
                transform.LookAt(way3.transform.position);
            }
        }

        if (way3 != null)
        {
            wayPointPos = new Vector3(way3.transform.position.x, transform.position.y, way3.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
            if (transform.position == way3.transform.position)
            {
                way3 = null;
                way1 = wayPoint1;
                transform.LookAt(way1.transform.position);
            }
        }
    }
}
