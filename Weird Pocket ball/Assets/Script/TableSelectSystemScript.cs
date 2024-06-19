using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSelectSystemScript : MonoBehaviour
{
    public GameObject object_FireTable;
    public GameObject objectAB;
    public GameObject objectAC;
    public GameObject objectBA;
    public GameObject objectBB;
    public GameObject objectBC;
    public GameObject objectCA;
    public GameObject objectCB;

    void Start()
    {
        objectAA.SetActive(false);
        objectAB.SetActive(false);
        objectAC.SetActive(false);

        objectBA.SetActive(false);
        objectBB.SetActive(false);
        objectBC.SetActive(false);

        objectCA.SetActive(false);
        objectCB.SetActive(false);
    }

    void Update()
    {
        
    }
}
