using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    public GameObject player;
    private LivesCounter livesCounter;
    public GameObject heartPrefab;
    private readonly List<GameObject> hearts = new List<GameObject>();
    private Vector3 firstHeartPosition = new Vector3(7.2f, 0, 5.3f);
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
            var pos = firstHeartPosition;
            pos.x = firstHeartPosition.x - i;
            var heart = Instantiate(heartPrefab, pos, Quaternion.Euler(new Vector3(90, 0, 0)));
            hearts.Add(heart);
        }
    }
}
