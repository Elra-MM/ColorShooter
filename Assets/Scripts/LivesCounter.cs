using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class LivesCounter : MonoBehaviour
{
    public int CurrentLives;
    public GameObject explosionPrefab;
    public UnityEvent LivesCountChanged { get; } = new UnityEvent(); //prefer observable from Unirx
    public GameObject PanelLose;
    void OnCollisionEnter(Collision collision)
    {
        Sounds.PlaySound("explosion");
        CurrentLives--;
        LivesCountChanged.Invoke();
        var explosion = Instantiate(explosionPrefab, this.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        Destroy(explosion, 3);
        Destroy(collision.gameObject);
        if (CurrentLives == 0)
        {
            StartCoroutine(EndGame());
        }
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.5f);
        PanelLose.SetActive(true);
        Time.timeScale = 0;
    }
}
