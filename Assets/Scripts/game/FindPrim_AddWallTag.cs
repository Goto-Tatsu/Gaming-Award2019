using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPrim_AddWallTag : MonoBehaviour
{
    private GameObject FindPrim;
    // Start is called before the first frame update
    void Start()
    {
        FindPrim = transform.GetChild(0).GetChild(0).gameObject;
        FindPrim.tag = "Wall";
    }
}
