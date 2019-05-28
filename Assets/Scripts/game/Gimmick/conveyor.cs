using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyor : MonoBehaviour
{
    private float m_uvSpeed = -0.5f;
    private float m_movePower = 300.0f;
    GameObject player;
    /// <summary>
    /// テクスチャのUV値をスクロールさせて、ベルトコンベアの見た目を表現する
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var material = GetComponent<Renderer>().material;
        Vector2 offset = material.mainTextureOffset;
        offset += Vector2.up * m_uvSpeed * Time.deltaTime;
        material.mainTextureOffset = offset;
    }

    //void OnCollisionEnter(Collision other)
    //{
    //    var body = player.gameObject.GetComponent<Rigidbody>();
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Vector3 addPower = transform.forward * m_movePower;
    //        body.AddForce(addPower, ForceMode.Acceleration);
    //    }
    //}

    //void OnCollisionExit(Collision other)
    //{
    //    var body = other.gameObject.GetComponent<Rigidbody>();
    //    if (body != null)
    //    {
    //        Vector3 addPower = -transform.forward * m_movePower;
    //        body.AddForce(addPower, ForceMode.Acceleration);
    //    }
    //}

    void OnCollisionEnter(Collision other)
    {
        var body = other.gameObject.GetComponent<Rigidbody>();
        if (body != null)
        {
            Vector3 addPower = -transform.right * m_movePower;
            body.AddForce(addPower, ForceMode.Acceleration);
        }
    }

    void OnCollisionExit(Collision other)
    {
        var body = other.gameObject.GetComponent<Rigidbody>();
        if (body != null)
        {
            Vector3 addPower = -transform.forward * m_movePower;
            body.AddForce(addPower, ForceMode.Acceleration);
        }
    }

}
