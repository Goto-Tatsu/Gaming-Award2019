using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour
{
    new Rigidbody rigidbody;
    Vector3 tras;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        tras = new Vector3(this.transform.position.x - 0.5f, this.transform.position.y, this.transform.position.z);
    }

    public Vector3 Get_Pos()
    {
        return tras;
    }
}
