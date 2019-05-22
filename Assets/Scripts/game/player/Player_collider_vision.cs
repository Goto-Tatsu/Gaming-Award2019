using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_collider_vision : MonoBehaviour
{
    
    Color color;
    new Renderer renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Wall")
        {
            renderer.material.SetColor("_Color", new Color(150, 150, 0, 0.15f));
            //Debug.Log("Hit");
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Wall")
        {
            renderer.material.SetColor("_Color", new Color(150, 150, 0, 0.0f));
        }
    }
}
