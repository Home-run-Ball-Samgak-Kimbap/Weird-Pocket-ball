using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScrollView : MonoBehaviour
{
   public Transform contentTrans;
   public GameObject itemPrefab;

   public void AddItem()
   {
        //프리팹 인스턴스 생성, 
        var go = Instantiate(this.itemPrefab);
   }
}
