using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesGenerator : MonoBehaviour
{
    public List<GameObject> EnemiesPrefabs;
    public float SecondsBetweenEnnemies = 0.5f;

    private readonly Vector3 positionUp = new Vector3(0, 0, 7);
    private readonly Vector3 positionDown = new Vector3(0, 0, -7);
    private readonly Vector3 positionLeft = new Vector3(-7, 0, 0);
    private readonly Vector3 positionRight = new Vector3(7, 0, 0);
    private readonly Vector3 rotationUp = new Vector3(0, 180, 0);
    private readonly Vector3 rotationDown = new Vector3(0, 0, 0);
    private readonly Vector3 rotationLeft = new Vector3(0, 90, 0);
    private readonly Vector3 rotationRight = new Vector3(0, 270, 0);
    private List<Tuple<Vector3, Vector3>> spawns;

    // Start is called before the first frame update
    void Start()
    {
        spawns = new List<Tuple<Vector3, Vector3>>
        {
            Tuple.Create(positionUp, rotationUp),
            Tuple.Create(positionDown, rotationDown),
            Tuple.Create(positionLeft, rotationLeft),
            Tuple.Create(positionRight, rotationRight)
        };

        StartCoroutine(nameof(GenerateEnnemies));
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
                Instantiate(enemyPrefab, positionRotation.Item1, Quaternion.Euler(positionRotation.Item2));
            }

            yield return new WaitForSeconds(SecondsBetweenEnnemies);
        }

    }

    private List<Tuple<Vector3, Vector3>> GetAvailableSpawns()
    {
        var res = new List<Tuple<Vector3, Vector3>>();
        foreach(var spawn in spawns)
        {
            if (!Physics.OverlapSphere(spawn.Item1, 1f).Any())
            {
                res.Add(spawn);
            }
        }
        return res;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
