using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellHandler : MonoBehaviour
{
    [SerializeField] GameObject Cell;
    public static GameObject[] CellGo = new GameObject[9];
    [SerializeField] public bool Turn = true;
    public static bool Win = false;
    string WinnerName;

    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            CellGo[i] = Instantiate(Cell);
            CellGo[i].transform.SetParent(gameObject.transform);
            CellGo[i].AddComponent<BoxCollider2D>().size = new Vector2(250, 250);
            CellGo[i].name = $"Клеточка {i}";
        }
    }

    public void Check()
    {
        for (int index = 1; index < 8; index += 3)
        {
            if (CellGo[index - 1].transform.childCount != 0 && CellGo[index].transform.childCount != 0 && CellGo[index + 1].transform.childCount != 0)
                if (CellGo[index - 1].transform.GetChild(0).name == CellGo[index].transform.GetChild(0).name && CellGo[index].transform.GetChild(0).name == CellGo[index + 1].transform.GetChild(0).name)
                {
                    WinnerName = CellGo[index].transform.GetChild(0).name;
                    Win = true;
                }
        } // HORIZONTAL CHECK
        for (int index = 0; index < 3; index++)
        {
            if (CellGo[index].transform.childCount != 0 && CellGo[index + 3].transform.childCount != 0 && CellGo[index + 6].transform.childCount != 0)
                if (CellGo[index].transform.GetChild(0).name == CellGo[index + 3].transform.GetChild(0).name && CellGo[index + 3].transform.GetChild(0).name == CellGo[index + 6].transform.GetChild(0).name)
                {
                    WinnerName = CellGo[index].transform.GetChild(0).name;
                    Win = true;
                }
        } // VERTICAL CHECK
        if (CellGo[0].transform.childCount != 0 && CellGo[4].transform.childCount != 0 && CellGo[8].transform.childCount != 0)
        {
            if (CellGo[0].transform.GetChild(0).name == CellGo[4].transform.GetChild(0).name && CellGo[4].transform.GetChild(0).name == CellGo[8].transform.GetChild(0).name)
            {
                Win = true;
                WinnerName = CellGo[4].transform.GetChild(0).name;
            }
        }// CHECK \
        if (CellGo[2].transform.childCount != 0 && CellGo[4].transform.childCount != 0 && CellGo[6].transform.childCount != 0)
        {
            if (CellGo[2].transform.GetChild(0).name == CellGo[4].transform.GetChild(0).name && CellGo[4].transform.GetChild(0).name == CellGo[6].transform.GetChild(0).name)
            {
                Win = true;
                WinnerName = CellGo[4].transform.GetChild(0).name;
            }

        } // CHECK /

        if (!Win)
        {
            Turn = !Turn;
        }
        else
        {
            Debug.Log(WinnerName);
            if (WinnerName == "X(Clone)")
            {
                Debug.Log("Player WIN");
            }   
            else
            {
                Debug.Log("Bot WIN");
            }
        }
    }


}
