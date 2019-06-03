using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkman_rotation : MonoBehaviour
{
   void OnTriggerEnter(Collider other)  //ふれてる間
   {
       if (other.gameObject.tag == ("stage"))
       {
           float y = other.gameObject.transform.root.transform.localRotation.y;
           transform.rotation = Quaternion.Euler(0.0f, -y, 0.0f);
        
           Debug.Log("HIT");

            
       }

       
   }


   void OnTriggerExit(Collider other)  //ふれた状態から離れたら
   {
       if (other.gameObject.tag == ("stage"))
       {
           float y = other.transform.localRotation.y;
           transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

           Debug.Log("EX");
       }
   }
}
