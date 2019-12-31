using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PutO : MonoBehaviour
{
    [SerializeField] GameObject O;
    CellHandler cellHandler;
    void Start()
    {
        cellHandler = GetComponentInParent<CellHandler>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!cellHandler.Turn && transform.childCount == 0 && !CellHandler.Win)
        {
            List<GameObject> Index = new List<GameObject>();
            foreach (GameObject i in CellHandler.CellGo)
            {
                if(i.transform.childCount == 0)
                {
                    Index.Add(i);
                }
            }
            Thread.Sleep(1500);
            GetComponent<AudioSource>().PlayOneShot(FindObjectOfType<AudioClip>());
            Instantiate(O, Index[Random.Range(0,Index.Count)].transform);
            cellHandler.Check();
        }
    }
 
}
