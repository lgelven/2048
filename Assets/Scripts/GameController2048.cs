using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 


//TODO: Make the program manually set the values for us to test with
//Fix our infinite loop
public class GameController2048 : MonoBehaviour
{
    public static GameController2048 instance;
    public static int ticker; 

    [SerializeField] GameObject fillPrefab;
    [SerializeField] Transform[] allCells;

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
        //StartSpawnFill();
        //StartSpawnFill();
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
            SlideUp(allCells[0].GetComponent(typeof(Cell2048)) as Cell2048); //Pass the top left cell in
            //SlideUp(allCells[1]); //Pass the top left cell in
            //SlideUp(allCells[2]); //Pass the top left cell in
            //SlideUp(allCells[3]); //Pass the top left cell in

        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            //
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            DebugSpawnFill();
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

    public void DebugSpawnFill()
    {


        GameObject tempFill = Instantiate(fillPrefab, allCells[8]);
        Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
        allCells[8].GetComponent<Cell2048>().fill = tempFillComp;
        tempFillComp.FillValueUpdate(4);

        GameObject tempFill2 = Instantiate(fillPrefab, allCells[12]);   
        Fill2048 tempFillComp2 = tempFill2.GetComponent<Fill2048>();
        allCells[12].GetComponent<Cell2048>().fill = tempFillComp2;
        tempFillComp2.FillValueUpdate(2);

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
    private void SlideUp(Cell2048 headValue)
    {
        //Fill2048 value = (head.GetComponent(typeof(Cell2048)) as Cell2048).fill; //The number of our current cell
        //Cell2048 currentValue = head.GetComponent(typeof(Cell2048)) as Cell2048;
        //Cell2048 headValue = head.GetComponent(typeof(Cell2048)) as Cell2048;

        
        if (headValue.fill == null)
        {
            //Do stuff
        }
        else
        {
            //Do other stuff
            Debug.Log("The value is " + headValue.fill.value);
            //headValue.fill.removeFromBoard();
        }
        

        if (headValue.fill == null)
        {
            //TODO - this is probably the problem
            Cell2048 currentCell = (headValue.GetComponent(typeof(Cell2048)) as Cell2048).down; //The cell below it
            while(currentCell.fill == null && currentCell.down != null)
            {
                currentCell = currentCell.down;
            }
            if (currentCell != null)
            {
                Debug.Log("Attempting to change to " + currentCell.fill.value);
                headValue.fill = makeCell(currentCell.fill.value, headValue.postionInArray);
                headValue.fill.FillValueUpdate(currentCell.fill.value);
                currentCell.fill.removeFromBoard();
            }
        }
        SlideUp(headValue.down);


    }
    public Fill2048 makeCell(int valueToFill, int positionInGrid)
    {
        GameObject tempFill = Instantiate(fillPrefab, allCells[positionInGrid]);
        Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
        allCells[positionInGrid].GetComponent<Cell2048>().fill = tempFillComp;
        tempFillComp.FillValueUpdate(valueToFill);
        return tempFillComp;
    }
}
