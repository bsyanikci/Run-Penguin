using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    #region Singleton
    private static PlayerController _instance;

    public static PlayerController Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<PlayerController>();

            return _instance;
        }
    }
    #endregion
    [SerializeField] private int playerJumpSpeed;
    [SerializeField] private float playerWalkSpeed;
    private Rigidbody2D rb2D;
    [SerializeField] internal bool startCondition;
    [SerializeField] private GameObject smokeEffect;
    [SerializeField] internal GameObject player;
    [SerializeField] internal int fishCount = 0;
    [SerializeField] internal TextMeshProUGUI scoreText, fishText, finalText;
    [SerializeField] internal bool deathCheck;
    [SerializeField] internal bool groundCheck;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //InvokeRepeating(nameof(AddWalkSpeed), 20, 15); //karakter sürekli hızı artsın istiyorsak aktif hale glebilir.
    }
    private void FixedUpdate()
    {
        scoreText.text = ((int)player.transform.position.x / 5).ToString();
        finalText.text = ((((int)player.transform.position.x / 5) * fishCount)).ToString();
        if (startCondition)
            Walk();
    }
    internal void Walk()
    {
        transform.Translate(Vector3.right * playerWalkSpeed);
    }
    internal void Jump() //animasyonu oynatan kodu jump fonksiyonunun içine aldık
    {
        if (groundCheck)
        {
            rb2D.AddForce(Vector3.up * playerJumpSpeed,ForceMode2D.Impulse);
            AnimationController.Instance.AnimationConditionControl(3);
        }              
    }
    internal void Die()
    {
        Instantiate(smokeEffect, transform.position, Quaternion.identity);
        this.gameObject.SetActive(false);
        deathCheck = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            Die();
        }
        if (collision.CompareTag("Fish"))
        {
            fishCount++;
            fishText.text = fishCount.ToString();
            collision.gameObject.SetActive(false);
            Instantiate(smokeEffect, collision.transform.position, Quaternion.identity);

        }
        
        
    }
    //internal void AddWalkSpeed() //Karakterimiz sürekli hızı artsın istiyorsak kullanılabilir
    //{
    //    playerWalkSpeed += 0.01f;
    //}
    private void OnCollisionEnter2D(Collision2D collision) //fizik updatesinin yetişmemesini önlemek için geç update aldırdık
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Invoke("ActivateGroundCheck", Time.fixedDeltaTime);
        }
       
    }
    private void ActivateGroundCheck()
    {
        groundCheck = true;

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            groundCheck = false;
        }
    }
}
