using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPower : MonoBehaviour
{
   private Rigidbody2D rb2;
    void Start() //Sarkaçlý tuzaðý sallandýrýr
    {
        rb2 = GetComponent<Rigidbody2D>();
        rb2.AddForce(Vector3.right * -300);
    }
}
