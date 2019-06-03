using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class walkman : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    public Transform target3;
    public Transform target4;
    public Transform target5;
    public Transform target6;
    public Transform boss;
    NavMeshAgent agent;

    

    public player player;
    

    bool flag = false;
    private new Rigidbody rigidbody;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }


    void Update()
    {
        //移動処理
        // Stage1
        if (transform.position.x == target1.position.x && transform.position.z == target1.position.z)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetAxisRaw("PS4LeftStickX") > 0.5 || Input.GetAxisRaw("XBOX LeftStickX") > 0.5 )
            {
                flag = false;
                agent.SetDestination(target2.position);
            }
            if (Input.GetButtonDown("XBOX B"))
            {
                FadeManager.FadeOut("1-1");
            }
            
        }
        // Stage2
        if (transform.position.x == target2.position.x && transform.position.z == target2.position.z)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetAxisRaw("PS4LeftStickYPause") > 0.5 || Input.GetAxisRaw("XBOXLeftStickYPause") > 0.5 )
            {
                flag = true;
                agent.SetDestination(target3.position);
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetAxisRaw("PS4LeftStickX") < -0.5 || Input.GetAxisRaw("XBOX LeftStickX") < -0.5)
            {
                flag = false;
                agent.SetDestination(target1.position);
            }
            if (Input.GetButtonDown("XBOX B"))
            {
                FadeManager.FadeOut("1-2");
            }
        }
        // Stage3
        if (transform.position.x == target3.position.x && transform.position.z == target3.position.z)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetAxisRaw("PS4LeftStickX") > 0.5 || Input.GetAxisRaw("XBOX LeftStickX") > 0.5)
            {
                flag = false;
                agent.SetDestination(target4.position);
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetAxisRaw("PS4LeftStickYPause") < -0.5 || Input.GetAxisRaw("XBOXLeftStickYPause") < -0.5)
            {
                flag = true;
                agent.SetDestination(target2.position);
            }
            if (Input.GetButtonDown("XBOX B"))
            {
                FadeManager.FadeOut("1-3");
            }

        }
        // Stage4
        if (transform.position.x == target4.position.x && transform.position.z == target4.position.z)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetAxisRaw("PS4LeftStickYPause") < -0.5 || Input.GetAxisRaw("XBOXLeftStickYPause") < -0.5)
            {
                flag = true;
                agent.SetDestination(target5.position);
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetAxisRaw("PS4LeftStickX") < -0.5 || Input.GetAxisRaw("XBOX LeftStickX") < -0.5)
            {
                flag = false;
                agent.SetDestination(target3.position);
            }
            if (Input.GetButtonDown("XBOX B"))
            {
                FadeManager.FadeOut("1-4");
            }
        }
        // Stage5
        if (transform.position.x == target5.position.x && transform.position.z == target5.position.z)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetAxisRaw("PS4LeftStickX") > 0.5 || Input.GetAxisRaw("XBOX LeftStickX") > 0.5 )
            {
                flag = false;
                agent.SetDestination(target6.position);
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetAxisRaw("PS4LeftStickYPause") > 0.5 || Input.GetAxisRaw("XBOXLeftStickYPause") > 0.5)
            {
                flag = true;
                agent.SetDestination(target4.position);
            }
            if (Input.GetButtonDown("XBOX B"))
            {
                FadeManager.FadeOut("1-5");
            }
        }
        // Stage6
        if (transform.position.x == target6.position.x && transform.position.z == target6.position.z)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D) || Input.GetAxisRaw("PS4LeftStickYPause") > 0.5 || Input.GetAxisRaw("XBOXLeftStickYPause") > 0.5)
            {
                flag = true;
                agent.SetDestination(boss.position);
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetAxisRaw("PS4LeftStickX") < -0.5 || Input.GetAxisRaw("XBOX LeftStickX") < -0.5)
            {
                flag = false;
                agent.SetDestination(target5.position);
            }
            if (Input.GetButtonDown("XBOX B"))
            {
                FadeManager.FadeOut("1-6");
            }
        }
        // Stage7
        if (transform.position.x == boss.position.x && transform.position.z == boss.position.z)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetAxisRaw("PS4LeftStickYPause") < -0.5 || Input.GetAxisRaw("XBOXLeftStickYPause") < -0.5)
            {
                flag = true;
                agent.SetDestination(target6.position);
            }
            if (Input.GetButtonDown("XBOX B"))
            {
                FadeManager.FadeOut("1-7");
            }
        }


        //移動向き管理
        if (flag == false)   //正面
        {
            transform.rotation = new Quaternion(0, 0, 0, 1);
        }
        if (flag == true)    //側面
        {
            transform.rotation = new Quaternion(0, 1, 0, 1);
        }
    }

    
}