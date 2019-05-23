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
        if (transform.position.x == target1.position.x && transform.position.z == target1.position.z)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                flag = false;
                agent.SetDestination(target2.position);
            }
        }
        if (transform.position.x == target2.position.x && transform.position.z == target2.position.z)
        {
            
            if (Input.GetKeyDown(KeyCode.W))
            {
                flag = true;
                agent.SetDestination(target3.position);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                flag = false;
                agent.SetDestination(target1.position);
            }
        }
        if (transform.position.x == target3.position.x && transform.position.z == target3.position.z)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                flag = false;
                agent.SetDestination(target4.position);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                flag = true;
                agent.SetDestination(target2.position);
            }
        }
        if (transform.position.x == target4.position.x && transform.position.z == target4.position.z)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                flag = true;
                agent.SetDestination(target5.position);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                flag = false;
                agent.SetDestination(target3.position);
            }
        }
        if (transform.position.x == target5.position.x && transform.position.z == target5.position.z)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                flag = false;
                agent.SetDestination(target6.position);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                flag = true;
                agent.SetDestination(target4.position);
            }
        }
        if (transform.position.x == target6.position.x && transform.position.z == target6.position.z)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.D))
            {
                flag = true;
                agent.SetDestination(boss.position);
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S))
            {
                flag = false;
                agent.SetDestination(target5.position);
            }
        }
        if (transform.position.x == boss.position.x && transform.position.z == boss.position.z)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                flag = true;
                agent.SetDestination(target6.position);
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

        if(agent.speed <= 0)
        {
            Debug.Log("MNST");
            transform.rotation = new Quaternion(0, 0, 0, 1);
        }


        //停止しているか確認
        //transform.rotation = new Quaternion(0, 0, 0, 1);
    }
}