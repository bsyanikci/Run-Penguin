using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] internal List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField] private TextMeshProUGUI gameOverFishText, gameoverScoreText, finalScoreText;
    public static UIController Instance { get; private set; }
    

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (PlayerController.Instance.deathCheck)
        {
            gameoverScoreText.text = PlayerController.Instance.scoreText.text;
            gameOverFishText.text = PlayerController.Instance.fishText.text;
            finalScoreText.text = PlayerController.Instance.finalText.text;
            gameObjects[7].SetActive(true);

        }
    }
    public void ButtonController(int id)
    {
        switch (id)
        {
            case 0:
                AnimationController.Instance.AnimationConditionControl(id);
                break;
            case 1: //start olduğu case
                AnimationController.Instance.AnimationConditionControl(id);
                PlayerController.Instance.startCondition = true;
                for (int i = 0; i < gameObjects.Count; i++)
                {
                    if (i == 0 || i == 1)
                    {
                        gameObjects[i].SetActive(false);
                    }
                    else if (i != 7)
                        gameObjects[i].SetActive(true);
                }
                break;
            case 2:
                AnimationController.Instance.AnimationConditionControl(id);
                break;
            case 3:
                PlayerController.Instance.Jump();
                break;
        }
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(0);
    }
    public void GamePaused(bool ispaused)
    {
        gameObjects[1].SetActive(ispaused);
        gameObjects[2].SetActive(!ispaused);
        gameObjects[3].SetActive(!ispaused);
    }
}
