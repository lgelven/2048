using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class GameController2048old : MonoBehaviour
{
    public static GameController2048old instance;
    public static int ticker; 

    [SerializeField] GameObject fillPrefab;
    [SerializeField] Transform[] allCells;

    public static Action<string> slide;

    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this; 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartSpawnFill();
        StartSpawnFill();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnFill();
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ticker = 0;
            slide("w");
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            ticker = 0;
            slide("d");
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ticker = 0;
            slide("s");
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ticker = 0;
            slide("a");
        }
    }
    public void SpawnFill()
    {
        int whichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        if(allCells[whichSpawn].childCount != 0)
        {
            Debug.Log(allCells[whichSpawn].name + " is already filled");
            SpawnFill();
            return; 
        }
        float chance = UnityEngine.Random.Range(0f, 1f);
        Debug.Log("The random number was "+chance);
        /*if (chance < .2f)
        {
            return;
        }
        */
        if (chance < .5f)
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn]);
            Debug.Log("Becuase the random number was " + chance + " we spawned a 2");
            Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
            allCells[whichSpawn].GetComponent<Cell2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(2);
        }
        else
        {
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn]);
            Debug.Log("Becuase the random number was " + chance + " we spawned a 4");
            Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
            allCells[whichSpawn].GetComponent<Cell2048>().fill = tempFillComp; 
            tempFillComp.FillValueUpdate(4); 
        }
    }

    public void StartSpawnFill()
    {
        int whichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        if (allCells[whichSpawn].childCount != 0)
        {
            Debug.Log(allCells[whichSpawn].name + " is already filled");
            SpawnFill();
            return;
        }
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn]);
            Debug.Log(2);
            Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
            allCells[whichSpawn].GetComponent<Cell2048>().fill = tempFillComp;
            tempFillComp.FillValueUpdate(2);       
    }
}
