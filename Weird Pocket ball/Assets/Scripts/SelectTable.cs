using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTable : MonoBehaviour
{
    public Table Table;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseUpAsButton() 
    {
        DataMgr.instance.currentTable = Table;
    }

    void OnSelect()
    {
        sr.color = new Color(1f, 1f, 1f);
    }

}
