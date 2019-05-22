using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleShederAlpha : MonoBehaviour
{
    private float meshAlpha;
    MeshRenderer meshRenderer;

    private Gancho ganchoScript;
    private float length_DistanciaDoPlayer;
    private float length_TamanhoCorda;
    private float length_OlharParaDir;


    // Start is called before the first frame update
    void Start()
    {
        // 透過度を動的に増減させるために、
        // フックとプレイヤー間の距離(distanciaDoPlayer)と
        // 伸びる距離(tamanhoCorda)を使う。
        

        // レンダラー関係
        meshAlpha = 0.00f;
        meshRenderer = GetComponent<MeshRenderer>();    // コンポーネント
        meshRenderer.material.color = new Color(0, 0, 0, meshAlpha);

    }

    // Update is called once per frame
    void Update()
    {
        // 必要なものを格納
        length_DistanciaDoPlayer = ganchoScript.GetDintanciaDoPlayer();
        length_TamanhoCorda = ganchoScript.GetTamanhoCorda();

        // 伸びてる距離ぶん÷伸びる最大長で、割合が出せる
        meshAlpha = length_DistanciaDoPlayer / length_TamanhoCorda;
    }
}
