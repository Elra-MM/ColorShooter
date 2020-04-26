using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesGenerator : MonoBehaviour
{
    public List<GameObject> EnemiesPrefabs;
    public float MinSecondsBetweenEnnemies;
    public float MaxSecondsBetweenEnnemies;

    private const int startingDistance = 9;
    private readonly Vector3 positionUp = new Vector3(0, 0, startingDistance);
    private readonly Vector3 positionDown = new Vector3(0, 0, -startingDistance);
    private readonly Vector3 positionLeft = new Vector3(-startingDistance, 0, 0);
    private readonly Vector3 positionRight = new Vector3(startingDistance, 0, 0);

    private readonly Vector3 rotationUp = new Vector3(0, 180, 0);
    private readonly Vector3 rotationDown = new Vector3(0, 0, 0);
    private readonly Vector3 rotationLeft = new Vector3(0, 90, 0);
    private readonly Vector3 rotationRight = new Vector3(0, -90, 0);
    private List<Tuple<Vector3, Vector3>> spawns;
    private UnityEvent scoreHasIncreased;
    private float currentEnemySpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        this.scoreHasIncreased = this.GetComponent<Score>().ScoreHasIncreased;
        this.scoreHasIncreased.AddListener(DecreaseSpawnDelay);
        this.scoreHasIncreased.AddListener(IncreaseCurrentEnemySpeed);
        spawns = new List<Tuple<Vector3, Vector3>>
        {
            Tuple.Create(positionUp, rotationUp),
            Tuple.Create(positionDown, rotationDown),
            Tuple.Create(positionLeft, rotationLeft),
            Tuple.Create(positionRight, rotationRight)
        };

        StartCoroutine(nameof(GenerateEnnemies));
    }

    private void DecreaseSpawnDelay()
    {
        MinSecondsBetweenEnnemies *= 0.95f;
        MaxSecondsBetweenEnnemies *= 0.95f;
    }

    private void IncreaseCurrentEnemySpeed()
    {
        currentEnemySpeed += 0.5f;
    }


    IEnumerator GenerateEnnemies()
    {
        while (true)
        {
            var availabeSpawns = GetAvailableSpawns();
            if (availabeSpawns.Any())
            {
                var enemyPrefab = EnemiesPrefabs[UnityEngine.Random.Range(0, EnemiesPrefabs.Count)];
                var positionRotation = availabeSpawns[UnityEngine.Random.Range(0, availabeSpawns.Count)];
                var enemyCreated = Instantiate(enemyPrefab, positionRotation.Item1, Quaternion.Euler(positionRotation.Item2));
                var enemyMovement = enemyCreated.GetComponent<EnemyMovement>();
                scoreHasIncreased.AddListener(enemyMovement.IncreaseSpeed);
                enemyMovement.Speed = currentEnemySpeed;

            }

            var secondsbeforeNextEnemy = UnityEngine.Random.Range(MinSecondsBetweenEnnemies, MaxSecondsBetweenEnnemies);
            yield return new WaitForSeconds(secondsbeforeNextEnemy);
        }

    }

    private List<Tuple<Vector3, Vector3>> GetAvailableSpawns()
    {
        var res = new List<Tuple<Vector3, Vector3>>();
        foreach (var spawn in spawns)
        {
            if (!Physics.OverlapSphere(spawn.Item1, 1f).Any())
            {
                res.Add(spawn);
            }
        }
        return res;
    }
}
