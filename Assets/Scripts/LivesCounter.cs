using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LivesCounter : MonoBehaviour
{
    public int CurrentLives;
    public GameObject explosionPrefab;
    public UnityEvent LivesCountChanged { get; } = new UnityEvent();

    void OnCollisionEnter(Collision collision)
    {
        CurrentLives--;
        LivesCountChanged.Invoke();
        var explosion = Instantiate(explosionPrefab, this.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        Destroy(explosion, 3);
        Destroy(collision.gameObject);
        if (CurrentLives == 0)
        {
            Time.timeScale = 0;
        }
    }
}
