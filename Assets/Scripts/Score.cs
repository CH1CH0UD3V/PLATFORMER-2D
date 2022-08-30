using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] int _score;
    //int _score;

    public void AddScore()
    {
        Debug.Log("C'est bon ca....ouais");

        _score++;
        _text.text = _score.ToString();
    }
}
