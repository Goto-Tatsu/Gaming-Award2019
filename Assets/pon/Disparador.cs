using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    // フックのオブジェクトを設定
    public GameObject gancho;
    private GameObject auxGancho;

    // カメラのやつ
    public Camera m_camera;

    // クリックしたとこのやつ
    public Transform dirDoClique;
    private Transform auxDirDoClique;

    // 
    private Vector3 localDoClique;
    private Vector3 posMouse;
    private Quaternion olharParaDir;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        posMouse = Input.mousePosition;
        posMouse.z = Vector3.Distance(m_camera.transform.position, this.transform.position);
        posMouse = m_camera.ScreenToWorldPoint(posMouse);


        // フックの軸が無い状態で
        if (auxGancho == null)
        {
            // マウスクリックしたら
            if (Input.GetMouseButtonDown(0))
            {
                // クリックしたところに補助クリック位置を生み出す
                auxDirDoClique = Instantiate(dirDoClique, posMouse, Quaternion.identity) as Transform;
                // クリックした方向を格納(単位ベクトル)
                localDoClique = (auxDirDoClique.transform.position - this.transform.position).normalized;
                // localDoCliqueの場所を任意軸として設定
                olharParaDir = Quaternion.LookRotation(localDoClique);

                // フックを、フックのポジションに、任意軸の向きでGameObjectとして生み出す
                auxGancho = Instantiate(gancho, this.transform.position, olharParaDir) as GameObject;
                Destroy(auxDirDoClique.gameObject);
            }
        }
    }


    // コーンをフック方向に伸ばす


    // コーンに拡大方向を教える
    public Vector3 GetLocalDoClique()
    {
        return localDoClique;
    }
}
