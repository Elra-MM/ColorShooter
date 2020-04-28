using System.Collections.Generic;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    public GameObject player;
    private LivesCounter livesCounter;
    public GameObject heartPrefab;
    private readonly List<GameObject> hearts = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        livesCounter = player.GetComponent<LivesCounter>();
        livesCounter.LivesCountChanged.AddListener(UpdateLivesDisplay);
        UpdateLivesDisplay();
    }

    void UpdateLivesDisplay()
    {
        foreach (var heart in hearts)
        {
            Destroy(heart);
        }

        for (int i = 0; i < livesCounter.CurrentLives; i++)
        {
            var pos = this.transform.position;
            pos.x -= i*0.1f;
            var heart = Instantiate(heartPrefab, pos , Quaternion.Euler(new Vector3(90, 0, 0)));
            hearts.Add(heart);
        }
    }
}
