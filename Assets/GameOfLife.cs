using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{
    public GameObject workerPrefab;
    Worker[,] workers;
    //int[,] intworkers;
    public Grid[,] intWorkers;
    float workerSize = 0.1f;
    int numberOfColums, numberOfRows;
    int spawnChancePercentage = 15;
    int firstGeneration;
    int z;
    int howManyAlive;
    int frames;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 4;

        numberOfColums = (int)Mathf.Floor(Camera.main.orthographicSize * Camera.main.aspect * 2 / workerSize);
        numberOfRows = (int)Mathf.Floor(Camera.main.orthographicSize * 2 / workerSize);

        workers = new Worker[numberOfColums, numberOfRows];
        ThisIsTheCurrentField();
        firstGeneration = 1;
        Debug.Log("number of colums" + numberOfColums + "number of rows" + numberOfRows);
    }






    void Update()
    {
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {
                if (x == 0)
                {

                }
                if (y == 0)
                {

                }
                if ((x > 0) && (y > 0) && (y < numberOfRows - 1) && (x < numberOfColums - 1))
                {
                    CheckNeighbors(x, y);
                }
            }
        }

        NewGeneration();
    }

    private void ThisIsTheCurrentField()
    {
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {
                Vector2 newPos = new Vector2(x * workerSize - Camera.main.orthographicSize * Camera.main.aspect, y * workerSize - Camera.main.orthographicSize);

                var newWorker = Instantiate(workerPrefab, newPos, Quaternion.identity);
                newWorker.transform.localScale = Vector2.one * workerSize;
                workers[x, y] = newWorker.GetComponent<Worker>();
                if (Random.Range(0, 100) < spawnChancePercentage && (firstGeneration == 0))
                {
                    workers[x, y].UpdateStatus(true);
                }
                else workers[x, y].UpdateStatus(false);
            }
        }

        NewGeneration();
    }
    void NewGeneration()
    {
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {
                workers[x, y].alive = workers[x, y].willLive;
            }
        }
    }
    void CheckNeighbors(int x, int y)
    {
        int howManyAlive = 0;
        for (int i = 0; i < 9; i++)
        {
            if (i == 4) continue;

            if (workers[x - 1 + i / 3, y - 1 + (i % 3)].alive == true)
            {

                howManyAlive += 1;

            }

        }
        if (workers[x, y].alive == false)
        {
                workers[x, y].UpdateStatus(howManyAlive == 3);


        }
        else if (howManyAlive == 3 || howManyAlive == 2)
        {
            workers[x, y].UpdateStatus(true);

        }
        else
        {
            workers[x, y].UpdateStatus(false);
            //Debug.Log("its running wild kill it");
        }
    }

}