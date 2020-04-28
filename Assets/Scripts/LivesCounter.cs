using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LivesCounter : MonoBehaviour
{
    public int CurrentLives;
    public UnityEvent LivesCountChanged { get; } = new UnityEvent();

    void OnCollisionEnter(Collision collision)
    {
        CurrentLives--;
        LivesCountChanged.Invoke();
        Destroy(collision.gameObject);
        if (CurrentLives == 0)
        {
            Time.timeScale = 0;
        }
    }
}
