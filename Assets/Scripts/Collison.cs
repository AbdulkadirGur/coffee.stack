using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
  
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            if (!MechanicalManager.instance.objeler.Contains(other.gameObject))// objeler ýcý ýce gýrmemsýný engellemek ve yený objenýn dýger objelerý yakalayabýlmesýný saglayan kod.
            {
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Untagged";
                other.gameObject.AddComponent<Collision>();
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                MechanicalManager.instance.StackObje(other.gameObject, MechanicalManager.instance.objeler.Count - 1);


            }
        }
    }
}
