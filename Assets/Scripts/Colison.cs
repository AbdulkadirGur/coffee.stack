using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colison : MonoBehaviour
{
    public static Colison instance;


    public GameObject Secondcamera;
    public GameObject yoket;
    public Transform kamera;

    //Puan sistemi
    public Transform container;
    public Transform moneyObje;
    public Transform startPos;

    public int numberOfRows;
    public int objectsPerRow;
    public float Space;

    public List<Transform> paralar = new List<Transform>();


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
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
                other.gameObject.AddComponent<Colison>();
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                MechanicalManager.instance.StackObje(other.gameObject, MechanicalManager.instance.objeler.Count - 1);


            }
        }
        if (other.gameObject.tag == "Finish")
        {
            Secondcamera.SetActive(true);
           
                          
            
        }
        if (other.gameObject.tag == "MoneyTag")
        {
            
            Destroy(yoket); 

            StartCoroutine(MakeMoneyFoc());
            MoveManager.instance.StopGame();



        }

    }

    private IEnumerator MakeMoneyFoc()
    {
        for (int row = 0; row < numberOfRows; row++)
        {
            for (int col = 0; col < objectsPerRow; col++)
            {
                Vector3 staringPos = new Vector3(startPos.position.x, startPos.position.y + col * Space, startPos.position.z);
                Transform money = Instantiate(moneyObje, staringPos, Quaternion.identity);
                paralar.Add(money);
                kamera= money;
                money.SetParent(container);
            }
        }

        for (int i = 0; i < paralar.Count; i++)
        {
            int index = i;   // DoScale icine i degeri yanlis gelebilir bunu onlemek icin bir onlem.
            Vector3 scale = new Vector3(1.5f, 1.5f, 1.5f);
            scale *= 3f;

            paralar[index].transform.DOScale(scale, 0.1f).OnComplete(() => paralar[index].transform.DOScale(new Vector3(3f, 3f,3f), 0.1f));
            yield return new WaitForSeconds(0.05f);
        }
    }
}



        
    
                
        




        
    

