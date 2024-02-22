using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] internal List<GameObject> traps = new List<GameObject>();
    private Vector3 spawpPosition;
    private GameObject randomTrap;
    bool ispause = false;
    private void Start()
    {
        InvokeRepeating(nameof(SpawnTraps), 3, Random.Range(3, 5)); //Traplerin spawnlama metodunu sürekli hale getirmek
                               //kaç sn sonra baþlasýn    //kaç sn aralýklarla gelsin
    }
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    internal void SpawnTraps()
        //Tuzaklarý Spawnlama Ýþlemi
    {
        if (PlayerController.Instance.startCondition)
        {
            randomTrap = traps[Random.Range(0, traps.Count)]; //Traplerin arasýndan random seçer
            spawpPosition = new Vector3(PlayerController.Instance.player.transform.position.x + Random.Range(25, 30), randomTrap.transform.position.y, PlayerController.Instance.player.transform.position.z); //Trapin spawnlancaðý pozisyonu belirle
            Instantiate(randomTrap, spawpPosition, Quaternion.identity); //Trapi spawnla
        }
    }
    public void SwitchGameState() //oyunu durduran metod
    {
        if (!ispause)
        {
            ispause = true;
            Time.timeScale = 0;
        }
        else
        {
            ispause = false;
            Time.timeScale = 1;
        }
        UIController.Instance.GamePaused(ispause);
            
    }
}
