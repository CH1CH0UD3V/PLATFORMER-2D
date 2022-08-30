using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mutton : MonoBehaviour
{
    [SerializeField] int _scoreValue;
    Score _score;

    private void Start()
    {
        _score = GameObject.FindObjectOfType<Score>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerTag foundTag = collision.attachedRigidbody.GetComponent<PlayerTag>();
        if (foundTag != null)
        {
            Debug.Log("AH!! UN JOUEUR");
            GameObject.Destroy(gameObject);
            _score.AddScoreMutton(_scoreValue);
        }
    }
}
