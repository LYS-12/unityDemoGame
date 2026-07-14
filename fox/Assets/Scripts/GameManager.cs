using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private enum State
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }
}