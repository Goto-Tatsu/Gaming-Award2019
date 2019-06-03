using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trace : MonoBehaviour
{

    private GameObject player = null;
    private Vector3 offset = Vector3.zero;
    private bool other_player;
    private double FrameCount;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;

        other_player = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = player.transform.position.x + offset.x;
        newPosition.y = player.transform.position.y + offset.y;
        // newPosition.z = player.transform.position.z + offset.z;
        transform.position = newPosition;
        this.transform.rotation = Quaternion.Euler(0,0,0);
        
        Debug.Log(other_player);

        if (FrameCount >= 15)
        {
            other_player = true;
            FrameCount = 0;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag != "Player")
        {
            other_player = true;
            FrameCount++;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag != "Player")
        {
            other_player = false;
            FrameCount = 0;
        }
    }

    public bool Get_OtherPlayer()
    {
        return other_player;
    }

}
