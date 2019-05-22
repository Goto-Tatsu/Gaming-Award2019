using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_rotate : MonoBehaviour
{

    Vector3 rigid_rotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rigid_rotate = transform.eulerAngles;
        transform.Rotate(new Vector3(0, 5, 0));

        //Debug.Log(rigid_rotate);
    }
}
