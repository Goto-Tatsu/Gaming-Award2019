using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    Transform cameraTrans;
    [SerializeField]
    Transform playerTrans;
    [SerializeField]
    Vector3 cameraVec;  //Vector3(0, 1, -1)
    [SerializeField]
    Vector3 cameraRot;  //Vector3(45, 0, 0)
    void Awake()
    {
        cameraTrans = transform;
        cameraTrans.rotation = Quaternion.Euler(cameraRot);
    }
    void LateUpdate()
    {
       // cameraTrans.position = playerTrans.position + cameraVec;
        cameraTrans.position = Vector3.Lerp(cameraTrans.position, playerTrans.position + cameraVec, 6.0f * Time.deltaTime);
    }
}