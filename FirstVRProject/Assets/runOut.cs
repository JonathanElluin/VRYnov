using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runOut : MonoBehaviour
{

    public GameObject player;
    public int speed = 6;
    public float minDistance = 6;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        //transform.position = Vector3.MoveTowards(transform.position, new Vector3((transform.position.x - player.transform.position.x), 0, (transform.position.z - player.transform.position.z)), step);
        //transform.LookAt(transform.position);

        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, player.transform.position.z), step);
        if (Vector3.Distance(player.transform.position, transform.position) < minDistance)
        {

            transform.position = Vector3.MoveTowards(transform.position, new Vector3((transform.position.x - player.transform.position.x), 0, (transform.position.z - player.transform.position.z)), step);
            transform.LookAt(transform.position);

        }
    }
}
