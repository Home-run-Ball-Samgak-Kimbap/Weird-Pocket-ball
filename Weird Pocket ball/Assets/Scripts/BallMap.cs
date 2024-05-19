using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMap : MonoBehaviour
{
    public GameObject[] maps = new GameObject[3];

    private void OnEnable() {

        Instantiate(maps[GameManager.gameManager.mapIndex]); 
        
    }
}
