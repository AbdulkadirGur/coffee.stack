using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
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

}
