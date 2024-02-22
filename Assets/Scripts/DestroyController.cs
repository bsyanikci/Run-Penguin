using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{
    private void Start() //Objelerin yok olma sistemi
    {
        Destroy(this.gameObject,14f);
    }
   
}
