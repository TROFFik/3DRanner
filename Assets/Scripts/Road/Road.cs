/*
    Laputski Trafim 12.08.2022 - 14.08.2022
    Test task for Junior Unity developer
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private Transform transferPoint;// Transfer point for objects on the scene
    [SerializeField] private Transform targetPoint;
    [SerializeField] private int speed; // Speed of objects on the sñene
    [SerializeField] private int roadPartsCount; // How many prefabs consist in road 
    [SerializeField] private List<GameObject> roadPartPrefabs;// Array of objects for building road
    private List<GameObject> movingObjects; // Array of objects to move
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.singleton;
        gameManager.gameOver += Dead;
        movingObjects = new List<GameObject>();
        CreateRoad();
    }

    void Update()
    {
        foreach (GameObject movingObject in movingObjects)
        {
            movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position, targetPoint.position, speed * Time.deltaTime);

            if (movingObject.transform.position == targetPoint.position)
            {
                movingObject.transform.position = transferPoint.position;
                movingObject.GetComponent<RoadPart>().FillRoad();
            }
        }
    }

    void CreateRoad()
    {
        for (int i = 0; i < roadPartsCount; i++)
        {
            int PrefabNumber = Random.Range(0, roadPartPrefabs.Count);
            GameObject NewRoadPart = Instantiate(roadPartPrefabs[PrefabNumber], transferPoint.position, Quaternion.identity, gameObject.transform);
            movingObjects.Add(NewRoadPart);
            transferPoint.position += new Vector3(0, 0, 10);
            if (i > 1)
            {
                NewRoadPart.GetComponent<RoadPart>().FillRoad();
            }
        }
        transferPoint.position -= new Vector3(0, 0, 10);
    }

    void Dead()
    {
        speed = 0;
    }
}
