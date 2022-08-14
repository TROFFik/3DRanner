/*
    Laputski Trafim 12.08.2022 - 14.08.2022
    Test task for Junior Unity developer
*/

using System.Collections.Generic;
using UnityEngine;

public class RoadPart : MonoBehaviour
{
    [SerializeField] private List<GameObject> itemsPrefabs;
    [SerializeField] private Transform[] spawnPoint;
    private List<GameObject> items = new List<GameObject>();

    private void Awake()
    {
        items = new List<GameObject>();
    }
    public void FillRoad()
    {
        foreach (GameObject item in items)
        {
            Destroy(item);
        }

        items.Clear();


        for (int i = 0; i < spawnPoint.Length; i++)
        {
            int PrefabNumber = Random.Range(0, itemsPrefabs.Count);
            GameObject NewItems = Instantiate(itemsPrefabs[PrefabNumber], spawnPoint[i]);
            items.Add(NewItems);
        }
    }
}
    