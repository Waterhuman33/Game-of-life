using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class GameOfLife : MonoBehaviour
{
    public GameObject workerPrefab;
    Worker[,] workers;
    //int[,] intworkers;
    public Grid[,] intWorkers;
    float workerSize = 0.09f;
    int numberOfColums, numberOfRows;
    //int spawnChancePercentage = 15;
    public int firstGeneration;
    public int currentAlive=0;
    public int usedToBeAlive;
    public int dadUsedToBeAlive;
        public int grandDadusedToBeAlive;



    int howManyAlive;
    int frames;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;   

        numberOfColums = (int)Mathf.Floor(Camera.main.orthographicSize * Camera.main.aspect * 2 / workerSize);
        numberOfRows = (int)Mathf.Floor(Camera.main.orthographicSize * 2 / workerSize);

        workers = new Worker[numberOfColums, numberOfRows];
        ThisIsTheCurrentField();
        firstGeneration = 1;
    }






    void Update()
    {
        
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {
                if (x == 0 || x == numberOfColums - 1 || y == 0 || y == numberOfRows - 1)
                {
                    List<int> onlythese = new List<int>();
                    onlythese.Add(0);
                    onlythese.Add(1);
                    onlythese.Add(2);
                    onlythese.Add(3);
                    onlythese.Add(5);
                    onlythese.Add(6);
                    onlythese.Add(7);
                    onlythese.Add(8);
                    if (x == 0)
                    {
                        onlythese.Remove(0);
                        onlythese.Remove(1);
                        onlythese.Remove(2);
                    }
                    if (x == numberOfColums - 1)
                    {
                        onlythese.Remove(6);
                        onlythese.Remove(7);
                        onlythese.Remove(8);
                    }
                    if (y == numberOfRows - 1)
                    {
                        onlythese.Remove(2);
                        onlythese.Remove(5);
                        onlythese.Remove(8);
                    }
                    if (y == 0)
                    {
                        onlythese.Remove(0);
                        onlythese.Remove(3);
                        onlythese.Remove(6);
                    }

                       
                    CheckNeighbors(x, y, onlythese);
                    

                }



                else if ((x > 0) && (y > 0) && (y < numberOfRows - 1) && (x < numberOfColums - 1))
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
                if (Random.Range(0, 100) < StaticVariables.spawnChancePercentage && (firstGeneration == 0))
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
        grandDadusedToBeAlive = dadUsedToBeAlive;
        dadUsedToBeAlive = usedToBeAlive;
        usedToBeAlive = currentAlive;
        
        currentAlive= 0;
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {
                workers[x, y].alive = workers[x, y].willLive;
                if(workers[x, y].willLive)
                {
                    currentAlive++;
                }
            }
            
        }
        if (usedToBeAlive == currentAlive||dadUsedToBeAlive==currentAlive && grandDadusedToBeAlive==usedToBeAlive )
        {
            ; 
        }
        else
            firstGeneration += 1;  
            
               
        
    }
    void CheckNeighbors(int x, int y)
    {
        int howManyAlive = 0;
        for (int i = 0; i < 9; i++)
        {
            if (i == 4) continue;

            if (workers[x - 1 + i / 3, y - 1 + (i % 3)].alive == true)
            {

                howManyAlive++;

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
           
        }
    }
    void CheckNeighbors(int x, int y, List<int> onlythese)
    {
        int howManyAlive = 0;

        foreach (int i in onlythese)
        {


            if (workers[x - 1 + i / 3, y - 1 + (i % 3)].alive == true)
            {

                howManyAlive++;

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
            
        }
    }
}