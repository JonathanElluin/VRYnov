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
    public GameObject player;
    public float minDistance = 20;
    public int speed = 6;
    private bool isAfraid = false;
    // Use this for initialization
    void Start () {
        way1 = wayPoint1;
        way2 = null;
        way3 = null;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Vector3.Distance(player.transform.position, transform.position) < minDistance)
        {
            runAway();
            isAfraid = true;
        }
        else if(isAfraid == false)
        {
            moov();
        }
    }

    void runAway()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3((transform.position.x - player.transform.position.x), 0, (transform.position.z - player.transform.position.z)), step);
        transform.LookAt(transform.position);
    } 

    void moov()
    {
        if (way1 != null)
        {
            wayPointPos = new Vector3(way1.transform.position.x, transform.position.y, way1.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
            if (transform.position.z == way1.transform.position.z)
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
            if (transform.position.z == way2.transform.position.z)
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
            if (transform.position.z == way3.transform.position.z)
            {
                way3 = null;
                way1 = wayPoint1;
                transform.LookAt(way1.transform.position);
            }
        }
    }

}
