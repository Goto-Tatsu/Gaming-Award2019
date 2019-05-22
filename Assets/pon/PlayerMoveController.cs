using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public float speed;
    public float jump;
    private Rigidbody rb;
    private Vector3 force;

    public Trace trace;

    public float velMover;
    public float velmoverAr;
    public float forcaBalancar;

    private bool noChao;
    private bool pendurado;

    public Status status;
    public float PlayerHP;
    public float scoreCoin;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        PlayerHP = status.Get_PLAYER_HP;

    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit ralo;
        noChao = Physics.Raycast(this.transform.position, -transform.up, out ralo, 1.5f);
        pendurado = Gancho.cordaColidiu;

        // コントローラー入力
        float h = Input.GetAxis("Horizontal");
        if (h != 0)
        {
            force = new Vector3(h * speed, 0.0f, 0.0f);
            rb.AddForce(force);
        }

        // キーボード入力
        if (Input.GetKey(KeyCode.A)) {
            force = new Vector3(-speed, 0.0f, 0.0f);
            rb.AddForce(force);
        }
        else if (Input.GetKey(KeyCode.D)) {
            force = new Vector3(speed, 0.0f, 0.0f);
            rb.AddForce(force);
        }

        else if (Input.GetKeyDown(KeyCode.W) && trace.Get_OtherPlayer()) {
            //force = new Vector3(0.0f, speed, 0.0f);
            force = new Vector3(0.0f, jump, 0.0f);
            rb.AddForce(force);
        }
        else if (Input.GetKeyDown(KeyCode.JoystickButton1) && trace.Get_OtherPlayer())
        {
            //force = new Vector3(0.0f, speed, 0.0f);
            force = new Vector3(0.0f, jump, 0.0f);
            rb.AddForce(force);
        }
        else if (Input.GetKey(KeyCode.S)) {
            force = new Vector3(0.0f, -speed, 0.0f);
            rb.AddForce(force);
        }

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Norma_Coin")
        {
            scoreCoin += status.Get_ScoreCoin;
        }
    }

    public float Get_PlayerHP
    {
        get { return PlayerHP; }
    }

    public float Get_NormaCoin
    {
        get { return scoreCoin; }
    }

}
