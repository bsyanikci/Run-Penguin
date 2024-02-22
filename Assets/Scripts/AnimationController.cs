using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    #region Singleton 

    //Clas� statik hale getirerek s�n�fa eri�mek i�in referans olu�turmaya gerek kalm�yor.

    private static AnimationController _instance;

    public static AnimationController Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<AnimationController>();

            return _instance;
        }
    }
    #endregion 

    internal Animator playerAnimator;
    [SerializeField] internal List<string> animationNames = new List<string>();

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }
    internal void AnimationControllerFunction(string animationName, bool condition, Animator animator) 
        //Karakterin animasyonlarına bütün classlardan erişip o animasyonları kullanılmasını saglayan metod
    {
        animator.SetBool(animationName, condition);
    }
    internal void AnimationConditionControl(int id) 
        //calismasi gereken animasyonu secer
    {
        for (int i = 1; i < 4; i++)
        {
            if(id == i) continue;
            // Debug.Log("i");
            playerAnimator.SetBool(animationNames[i], false);
        }
        AnimationControllerFunction(animationNames[id], true, playerAnimator);
    }
}
