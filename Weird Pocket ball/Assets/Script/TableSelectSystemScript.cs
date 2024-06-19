using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSelectSystemScript : MonoBehaviour
{
    public GameObject object_FireBall;
    public GameObject object_8Ball;
    public GameObject object_IceBall;
    public GameObject objectBA;
    public GameObject objectBB;
    public GameObject objectBC;
    public GameObject objectCA;
    public GameObject objectCB;

    void Start()
    {
        object_FireBall.SetActive(false);
        object_8Ball.SetActive(false);
        object_IceBall.SetActive(false);

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
