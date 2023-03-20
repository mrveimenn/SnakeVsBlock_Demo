using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour
{
    public ControlGame ControlGame;
    public enum State
    {
        Plaing,
        Won,
        Loss,
    }

    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Plaing) return;

        CurrentState = State.Loss;
        ControlGame.enabled = false;
        Debug.Log("Game Over");
        ReloadLevel();
    }

    public void OnPlayerReachFinish()
    {
        if (CurrentState != State.Plaing) return;

        CurrentState = State.Won;
        ControlGame.enabled = false;
        LevelIndex++;
        Debug.Log("You Won!");
        ReloadLevel();
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    private const string LevelIndexKey = "LevelIndex";

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
