using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform target2;
    [SerializeField] private float cameraFollowSpeed = 5f;
    private Vector3 offesetVektor;
      

    void Start()
    {
       
        offesetVektor = CalculatorOffset(target);
        
    }
    
    // Update is called once per frame
    private void FixedUpdate()
    {

        if (target != null)
        {
            MoveTheCamera();
          
        }
        MoveTheSecondCamera();

    }

    private void MoveTheCamera()
    {
        Vector3 targetMove = target.position + offesetVektor;
        transform.position = Vector3.Lerp(transform.position, targetMove, cameraFollowSpeed * Time.deltaTime);
        transform.LookAt(target.transform.position);
    }

    private Vector3 CalculatorOffset(Transform newTarget)
    {
        return transform.position - newTarget.position;
    }
    private void MoveTheSecondCamera()
    {
        //GetComponent<CinemachineVirtualCamera>().Follow = Colison.instance.paralar[Colison.instance.paralar.Count - 1].transform;
        //GetComponent<CinemachineVirtualCamera>().LookAt = Colison.instance.paralar[Colison.instance.paralar.Count - 1].transform;

       /* target2 = Colison.instance.paralar[Colison.instance.paralar.Count - 1].transform;
        Vector3 targetMove = target2.position + offesetVektor;
        transform.position = Vector3.Lerp(transform.position, targetMove, cameraFollowSpeed * Time.deltaTime);
        transform.LookAt(target2.transform.position);*/
        
    }

}
