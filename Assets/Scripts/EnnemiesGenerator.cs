using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiesGenerator : MonoBehaviour
{
    public List<GameObject> ennemiesPrefabs;
    private readonly Vector3 positionUp = new Vector3(0, 0, 400);
    // Start is called before the first frame update
    void Start()
    {
        var ennemyPrefab = ennemiesPrefabs[Random.Range(0, ennemiesPrefabs.Count -1)];

        var ennemy = Instantiate(ennemyPrefab, positionUp, Quaternion.identity);
        ennemy.transform.Rotate(new Vector3(0, 180, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
