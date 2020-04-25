using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LivesCounter : MonoBehaviour
{
    public int CurrentLives;
    public UnityEvent LivesCountChanged { get; } = new UnityEvent();
    private const string enemyTag = "Enemy";
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision)
    {
        CurrentLives--;
        LivesCountChanged.Invoke();
        Destroy(collision.gameObject);
    }
}
