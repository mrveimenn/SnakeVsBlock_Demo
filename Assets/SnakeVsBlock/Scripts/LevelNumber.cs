using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelNumber : MonoBehaviour
{
    public Text Text;
    public MainGame MainGame;

    public void Start()
    {
        Text.text = "Level " + (MainGame.LevelIndex + 1).ToString();
    }
}
