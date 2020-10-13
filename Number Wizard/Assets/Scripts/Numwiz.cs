using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Numwiz : MonoBehaviour
{
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guesstext;
    int guess;
    
    void Start()
    {
        startGame();
    }
    void startGame()
    {

        nextGuess();
        guesstext.text = guess.ToString();
    }
    public void pressHigher()
    {
        min = guess;
        nextGuess();
    }
    public void pressLower()
    {
        max = guess;
        nextGuess();
    }
    public void nextGuess()
    {
        guess = (max + min) / 2;
        guesstext.text = guess.ToString();

    }


}
