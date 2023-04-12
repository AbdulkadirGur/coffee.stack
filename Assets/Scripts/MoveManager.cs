using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    [SerializeField] private float swipeSpeed; //kaydýrma hýzý deðiþkeni
    [SerializeField] private float moveSpeed; //hareket hýzý deðiþkeni
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject SecondCam;
    bool stopflag=false;


    public static MoveManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopflag)
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
            if (Input.GetButton("Fire1"))
            {
                Move();
            }
        }
        else
        {
            transform.position += Vector3.forward * 0 * Time.deltaTime;
        }
        
    }

    private void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.position.z;

        Ray ray = cam.ScreenPointToRay(mousePos);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject firstCube = MechanicalManager.instance.objeler[0];// hit.point degerini degistirebilmek icin hitVec olusturuldu;
            Vector3 hitVec = hit.point;
            hitVec.y = firstCube.transform.localPosition.y;
            hitVec.z = firstCube.transform.localPosition.z;

            firstCube.transform.localPosition = Vector3.MoveTowards(firstCube.transform.localPosition, hitVec, Time.deltaTime * swipeSpeed);
            // local olmasinin sebebi player objesinin bir parenti olmasi ve tum childler ayni davranmasini istedigimiz icin
        }
    }
    public void StopGame()
    {
        stopflag = true;
    }
}
