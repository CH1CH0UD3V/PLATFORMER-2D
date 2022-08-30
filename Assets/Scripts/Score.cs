using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textAle;
    [SerializeField] TextMeshProUGUI _textMutton;
    int _scoreAle;
    int _scoreMutton;

    public void AddScoreMutton(int scoreToAdd)
    {
        Debug.Log("C'est bon ca....ouais");

        _scoreMutton += scoreToAdd ;
        _textMutton.text = _scoreMutton.ToString();
    }

    public void AddScoreAle(int scoreToAdd)
    {
        Debug.Log("C'est bon ca....ouais");

        _scoreAle += scoreToAdd;
        _textAle.text = _scoreAle.ToString();
    }
}
