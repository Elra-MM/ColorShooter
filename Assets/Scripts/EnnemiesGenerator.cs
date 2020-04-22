using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiesGenerator : MonoBehaviour
{
    public List<GameObject> ennemiesPrefabs;
    private readonly Vector3 positionUp = new Vector3(0, 0, 7);
    private readonly Vector3 positionDown = new Vector3(0, 0, -7);
    private readonly Vector3 positionLeft = new Vector3(-7, 0, 0);
    private readonly Vector3 positionRight = new Vector3(7, 0, 0);
    private readonly Vector3 rotationUp = new Vector3(0, 180, 0);
    private readonly Vector3 rotationDown = new Vector3(0, 0, 0);
    private readonly Vector3 rotationLeft = new Vector3(0, 90, 0);
    private readonly Vector3 rotationRight = new Vector3(0, 270, 0);
    private List<Tuple<Vector3, Vector3>> positionsRotations;
    public float secondsBetweenEnnemies;

    // Start is called before the first frame update
    void Start()
    {
        positionsRotations = new List<Tuple<Vector3, Vector3>>
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
            var ennemyPrefab = ennemiesPrefabs[UnityEngine.Random.Range(0, ennemiesPrefabs.Count)];
            var positionRotation = positionsRotations[UnityEngine.Random.Range(0, positionsRotations.Count)];
            Instantiate(ennemyPrefab, positionRotation.Item1, Quaternion.Euler(positionRotation.Item2));

            yield return new WaitForSeconds(secondsBetweenEnnemies);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
