using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerDown : MonoBehaviour
{
    [SerializeField] GameObject X;
    CellHandler cellHandler;
    private void Start()
    {
        cellHandler = GetComponentInParent<CellHandler>();
    }
    public void Click()
    { 
        if(transform.childCount == 0 && !CellHandler.Win)
        {
            Instantiate(X, transform);
            GetComponent<AudioSource>().PlayOneShot(FindObjectOfType<AudioClip>());
            cellHandler.Check();
        }
    }
}
