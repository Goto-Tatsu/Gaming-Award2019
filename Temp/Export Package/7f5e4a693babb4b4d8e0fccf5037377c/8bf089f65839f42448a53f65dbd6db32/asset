using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Title : MonoBehaviour
{
    public Player_Title PT;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PT.Get_Pon==false)
        {
            animator.SetBool("Bom", false);
        }
        if(PT.Get_Pon==true)
        {
            animator.SetBool("Bom", true);
        }
    }
}
