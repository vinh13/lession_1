using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{
    private Transform player;
    private Vector3 temPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;   
    }

    // Update is called once per frame
    void LastUpdate()
    {
        temPos = transform.position;
        temPos.x = player.position.x;

        transform.position = temPos;
    }
}
