using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTriger : MonoBehaviour
{
    [SerializeField] Transform _respawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // PlayerTag
        PlayerTag myTag = collision.attachedRigidbody.GetComponent<PlayerTag>();
        if (myTag != null)
        {
            collision.attachedRigidbody.transform.position = _respawnPoint.position;
        }
    }
}
