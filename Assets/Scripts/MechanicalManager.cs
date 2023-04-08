using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MechanicalManager : MonoBehaviour
{
    public static MechanicalManager instance;
    public float movementDelay = 0.25f;// Gelen objelerin hareketlerinin delay suresi

    public List<GameObject> objeler = new List<GameObject>();
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

   
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            MoveListElements();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            MoveOrgin();
        }
    }

    public void StackObje(GameObject other, int index)          // Objeler toplaninca neler olsun? other olmasinin sebebi collisondaki otherdan geldigini anlamak icin.
    {
        other.transform.parent = transform;                      // other'in Parentini AllObjects  yapiyoruz.Tum kuplerin AllObjects altina siralanmasi icin.
        Vector3 newPos = objeler[index].transform.localPosition; 
        newPos.z += 1;
        other.transform.localPosition = newPos;
        objeler.Add(other);
        StartCoroutine(MakeObjectsBigger());

    }

    private IEnumerator MakeObjectsBigger() // kucuk býr delay vererek toplanan objelerýn anýden buyuyup kuculmesýný saglýyoruz.
    {
        for (int i = objeler.Count-1; i > 0; i--)
        {
            int index = i;   // DoScale icine i degeri yanlis gelebilir bunu onlemek icin bir onlem.
            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 1.5f;

            objeler[index].transform.DOScale(scale, 0.1f).OnComplete(() => objeler[index].transform.DOScale(new Vector3(1, 1, 1), 0.1f));
        yield return new WaitForSeconds(0.05f);
        }
    }
    
    private void MoveListElements()
    {
        for (int i = 1; i < objeler.Count; i++)
        {
            Vector3 pos = objeler[i].transform.localPosition;
            pos.x = objeler[i - 1].transform.localPosition.x;
            objeler[i].transform.DOLocalMove(pos, movementDelay);

        }
    }
    private void MoveOrgin()
    {
        for (int i = 1; i < objeler.Count; i++)
        {
            Vector3 pos = objeler[i].transform.localPosition;
            pos.x = objeler[0].transform.localPosition.x;
            objeler[i].transform.DOLocalMove(pos, 0.70f );

        }
    }
}
