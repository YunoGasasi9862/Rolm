using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public EasyClockTimerBehaviour ClockReference;
    public static bool GameOver = false;
    [SerializeField] GameObject GOPrefab;
    void Start()
    {
        ClockReference.AttachActionToTimerEvent(TimerAction.END, GameOverScreenInstantiate);

    }


    void GameOverScreenInstantiate()
    {
        GameOver = true;
    }

    private void Update()
    {
        if(GameOver)
        {
            GOPrefab.SetActive(true);
           
        }
    }

    public void RestartLevel()
    {

        if(GameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Hello");
            GOPrefab.SetActive(false);
            GameOver = false;
        }
    }
}
