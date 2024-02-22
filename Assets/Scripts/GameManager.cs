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
        InvokeRepeating(nameof(SpawnTraps), 3, Random.Range(3, 5)); //Traplerin spawnlama metodunu s�rekli hale getirmek
                               //ka� sn sonra ba�las�n    //ka� sn aral�klarla gelsin
    }
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    internal void SpawnTraps()
        //Tuzaklar� Spawnlama ��lemi
    {
        if (PlayerController.Instance.startCondition)
        {
            randomTrap = traps[Random.Range(0, traps.Count)]; //Traplerin aras�ndan random se�er
            spawpPosition = new Vector3(PlayerController.Instance.player.transform.position.x + Random.Range(25, 30), randomTrap.transform.position.y, PlayerController.Instance.player.transform.position.z); //Trapin spawnlanca�� pozisyonu belirle
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
