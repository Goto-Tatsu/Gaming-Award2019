using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPrimChildren_AddCeilingTag : MonoBehaviour
{
    private GameObject FindPrim;

    // Start is called before the first frame update
    void Start()
    {
        FindPrim = transform.GetChild(0).gameObject;
        FindPrim.tag = "Ceiling";
    }
}
