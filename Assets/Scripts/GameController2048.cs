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
    public static int movementTicker;
    public static int counter; 

    

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
        SpawnFill();
        SpawnFill();
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
            SlideUp(allCells[1].GetComponent(typeof(Cell2048)) as Cell2048); //Pass the top left cell in
            SlideUp(allCells[2].GetComponent(typeof(Cell2048)) as Cell2048); //Pass the top left cell in
            SlideUp(allCells[3].GetComponent(typeof(Cell2048)) as Cell2048); //Pass the top left cell in
            
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            SlideRight(allCells[3].GetComponent(typeof(Cell2048)) as Cell2048); //Pass the top left cell in
            SlideRight(allCells[7].GetComponent(typeof(Cell2048)) as Cell2048); //Pass the top left cell in
            SlideRight(allCells[11].GetComponent(typeof(Cell2048)) as Cell2048); //Pass the top left cell in
            SlideRight(allCells[15].GetComponent(typeof(Cell2048)) as Cell2048); //Pass the top left cell in 
            
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SlideDown(allCells[12].GetComponent(typeof(Cell2048)) as Cell2048); //Pass the top left cell in
            SlideDown(allCells[13].GetComponent(typeof(Cell2048)) as Cell2048); //Pass the top left cell in
            SlideDown(allCells[14].GetComponent(typeof(Cell2048)) as Cell2048); //Pass the top left cell in
            SlideDown(allCells[15].GetComponent(typeof(Cell2048)) as Cell2048); //Pass the top left cell in 
            
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SlideLeft(allCells[0].GetComponent(typeof(Cell2048)) as Cell2048); //Pass the top left cell in
            SlideLeft(allCells[4].GetComponent(typeof(Cell2048)) as Cell2048); //Pass the top left cell in
            SlideLeft(allCells[8].GetComponent(typeof(Cell2048)) as Cell2048); //Pass the top left cell in
            SlideLeft(allCells[12].GetComponent(typeof(Cell2048)) as Cell2048); //Pass the top left cell in 
            
        }
        if (movementTicker != 0)
        {
            SpawnFill();
            endGame();
            
        }
        movementTicker = 0;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            DebugSpawnFill();
        }
    }
    public void endGame()
    {
        counter = 0;
        for (int i = 0; i < allCells.Length; i++)
        {
            if (allCells[i].GetComponent<Cell2048>().fill != null)
            {
                counter++;
            }
            if (counter == 16)
            {
                checkValues();
                if(checkValues()==false)
                {
                    Debug.Log("GAME OVER");
                }
            }
        }
    }

    public bool checkValues()
    {
        
        for(int i=0; i<allCells.Length; i++)
        {
            if (allCells[i].GetComponent<Cell2048>().left != null && allCells[i].GetComponent<Cell2048>().fill.value ==allCells[i].GetComponent<Cell2048>().left.fill.value)
            {
                return true; 
            }
            if (allCells[i].GetComponent<Cell2048>().right != null && allCells[i].GetComponent<Cell2048>().fill.value ==allCells[i].GetComponent<Cell2048>().right.fill.value)
            {
                return true; 
            }
            if (allCells[i].GetComponent<Cell2048>().down != null && allCells[i].GetComponent<Cell2048>().fill.value == allCells[i].GetComponent<Cell2048>().down.fill.value)
            {
                return true; 
            }
            if (allCells[i].GetComponent<Cell2048>().up != null && allCells[i].GetComponent<Cell2048>().fill.value == allCells[i].GetComponent<Cell2048>().up.fill.value)
            {
                return true; 
            }
        }
        return false; 
    }

    //Need to find a way to choose the values that are going to be able to spawn. Then use the random generator to pick one of those values. 
    public void SpawnFill()
    {
        ArrayList cellCounter = new ArrayList();
        for (int i = 0; i<allCells.Length; i++)
        {
            if (allCells[i].GetComponent<Cell2048>().fill == null){
                //This if statement does not work. The cells are not null?
                //Debug.Log("blah");
                cellCounter.Add(i);
            }
        }
        int spawnIndexOfArray = UnityEngine.Random.Range(0, cellCounter.Count);
        //Debug.Log(spawnIndexOfArray);
        int whichSpawn = (int)cellCounter[spawnIndexOfArray];


        float chance = UnityEngine.Random.Range(0f, 1f);
            //Debug.Log("The random number was "+chance);
            /*if (chance < .2f)
            {
                return;
            }
            */
            if (chance < .5f)
            {
                GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn]);
                //Debug.Log("Becuase the random number was " + chance + " we spawned a 2");
                Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
                allCells[whichSpawn].GetComponent<Cell2048>().fill = tempFillComp;
                tempFillComp.FillValueUpdate(2);
            }
            else
            {
                GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn]);
                //Debug.Log("Becuase the random number was " + chance + " we spawned a 4");
                Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
                allCells[whichSpawn].GetComponent<Cell2048>().fill = tempFillComp; 
                tempFillComp.FillValueUpdate(4); 
            }
            return;
    }
        
    

    public void DebugSpawnFill()
    {
        spawnFillAt(0, 2);
        spawnFillAt(4, 4);
        spawnFillAt(8, 4);
        spawnFillAt(12, 4);
    }
    public void spawnFillAt(int position, int value )
    {
        GameObject tempFill = Instantiate(fillPrefab, allCells[position]);
        Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
        allCells[position].GetComponent<Cell2048>().fill = tempFillComp;
        tempFillComp.FillValueUpdate(value);
    }
    public void StartSpawnFill()
    {
        int whichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        if (allCells[whichSpawn].childCount != 0)
        {
            //Debug.Log(allCells[whichSpawn].name + " is already filled");
            SpawnFill();
            return;
        }
            GameObject tempFill = Instantiate(fillPrefab, allCells[whichSpawn]);
            //Debug.Log(2);
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
            //Slides up values
            Cell2048 currentCell = (headValue.GetComponent(typeof(Cell2048)) as Cell2048).down; //The cell below it
            while (currentCell.fill == null && currentCell.down != null)
            {
                currentCell = currentCell.down;
            }
            if (currentCell != null && currentCell.fill != null)
            {
                //Debug.Log("Attempting to change to " + currentCell.fill.value);
                headValue.fill = makeCell(currentCell.fill.value, headValue.postionInArray);
                headValue.fill.FillValueUpdate(currentCell.fill.value);
                currentCell.fill.removeFromBoard(headValue);
                //currentCell.fill.removeFromBoard();
                currentCell.fill = null;
                movementTicker++;
            }
        }

        if (headValue.fill != null)
        {
            //Combines values
            Cell2048 currentCell = (headValue.GetComponent(typeof(Cell2048)) as Cell2048).down; //The cell below it
            while (currentCell.fill == null && currentCell.down != null)
            {
                currentCell = currentCell.down;
            }
            if (currentCell.fill != null)
            {
                if (headValue.fill.value == currentCell.fill.value)
                {
                    headValue.fill.Double();
                    headValue.fill.FillValueUpdate(headValue.fill.value);
                    currentCell.fill.removeFromBoard();
                    currentCell.fill = null;
                    movementTicker++;
                }
            }
            
        }
        if((headValue.GetComponent(typeof(Cell2048)) as Cell2048).down.down != null)
        {
            SlideUp((headValue.GetComponent(typeof(Cell2048)) as Cell2048).down);
        }
        
        
    }
    private void SlideRight(Cell2048 headValue)
    {
        //Fill2048 value = (head.GetComponent(typeof(Cell2048)) as Cell2048).fill; //The number of our current cell
        //Cell2048 currentValue = head.GetComponent(typeof(Cell2048)) as Cell2048;
        //Cell2048 headValue = head.GetComponent(typeof(Cell2048)) as Cell2048;
        if (headValue.fill == null)
        {
            //Slides up values
            Cell2048 currentCell = (headValue.GetComponent(typeof(Cell2048)) as Cell2048).left; //The cell below it
            while (currentCell.fill == null && currentCell.left != null)
            {
                currentCell = currentCell.left;
            }
            if (currentCell != null && currentCell.fill != null)
            {
                //Debug.Log("Attempting to change to " + currentCell.fill.value);
                headValue.fill = makeCell(currentCell.fill.value, headValue.postionInArray);
                headValue.fill.FillValueUpdate(currentCell.fill.value);
                currentCell.fill.removeFromBoard();
                currentCell.fill = null;
                movementTicker++;
            }
        }

        if (headValue.fill != null)
        {
            //Combines values
            Cell2048 currentCell = (headValue.GetComponent(typeof(Cell2048)) as Cell2048).left; //The cell below it
            while (currentCell.fill == null && currentCell.left != null)
            {
                currentCell = currentCell.left;
            }
            if (currentCell.fill != null)
            {
                if (headValue.fill.value == currentCell.fill.value)
                {
                    headValue.fill.Double();
                    headValue.fill.FillValueUpdate(headValue.fill.value);
                    currentCell.fill.removeFromBoard();
                    currentCell.fill = null;
                    movementTicker++;
                }
                
            }

        }
        if ((headValue.GetComponent(typeof(Cell2048)) as Cell2048).left.left != null)
        {
            SlideRight((headValue.GetComponent(typeof(Cell2048)) as Cell2048).left);
        }
        
    }

    private void SlideDown(Cell2048 headValue)
    {
        //Fill2048 value = (head.GetComponent(typeof(Cell2048)) as Cell2048).fill; //The number of our current cell
        //Cell2048 currentValue = head.GetComponent(typeof(Cell2048)) as Cell2048;
        //Cell2048 headValue = head.GetComponent(typeof(Cell2048)) as Cell2048;
        if (headValue.fill == null)
        {
            //Slides up values
            Cell2048 currentCell = (headValue.GetComponent(typeof(Cell2048)) as Cell2048).up; //The cell below it
            while (currentCell.fill == null && currentCell.up != null)
            {
                currentCell = currentCell.up;
            }
            if (currentCell != null && currentCell.fill != null)
            {
                //Debug.Log("Attempting to change to " + currentCell.fill.value);
                headValue.fill = makeCell(currentCell.fill.value, headValue.postionInArray);
                headValue.fill.FillValueUpdate(currentCell.fill.value);
                currentCell.fill.removeFromBoard();
                currentCell.fill = null;
                movementTicker++;
            }
        }

        if (headValue.fill != null)
        {
            //Combines values
            Cell2048 currentCell = (headValue.GetComponent(typeof(Cell2048)) as Cell2048).up; //The cell below it
            while (currentCell.fill == null && currentCell.up != null)
            {
                currentCell = currentCell.up;
            }
            if (currentCell.fill != null)
            {
                if (headValue.fill.value == currentCell.fill.value)
                {
                    headValue.fill.Double();
                    headValue.fill.FillValueUpdate(headValue.fill.value);
                    currentCell.fill.removeFromBoard();
                    currentCell.fill = null;
                    movementTicker++;
                }
            }

        }
        if ((headValue.GetComponent(typeof(Cell2048)) as Cell2048).up.up != null)
        {
            SlideDown((headValue.GetComponent(typeof(Cell2048)) as Cell2048).up);
        }
        
    }

    private void SlideLeft(Cell2048 headValue)
    {
        //Fill2048 value = (head.GetComponent(typeof(Cell2048)) as Cell2048).fill; //The number of our current cell
        //Cell2048 currentValue = head.GetComponent(typeof(Cell2048)) as Cell2048;
        //Cell2048 headValue = head.GetComponent(typeof(Cell2048)) as Cell2048;
        if (headValue.fill == null)
        {
            //Slides up values
            Cell2048 currentCell = (headValue.GetComponent(typeof(Cell2048)) as Cell2048).right; //The cell below it
            while (currentCell.fill == null && currentCell.right != null)
            {
                currentCell = currentCell.right;
            }
            if (currentCell != null && currentCell.fill != null)
            {
                //Debug.Log("Attempting to change to " + currentCell.fill.value);
                headValue.fill = makeCell(currentCell.fill.value, headValue.postionInArray);
                headValue.fill.FillValueUpdate(currentCell.fill.value);
                currentCell.fill.removeFromBoard();
                currentCell.fill = null;
                movementTicker++;
            }
        }

        if (headValue.fill != null)
        {
            //Combines values
            Cell2048 currentCell = (headValue.GetComponent(typeof(Cell2048)) as Cell2048).right; //The cell below it
            while (currentCell.fill == null && currentCell.right != null)
            {
                currentCell = currentCell.right;
            }
            if (currentCell.fill != null)
            {
                if (headValue.fill.value == currentCell.fill.value)
                {
                    headValue.fill.Double();
                    headValue.fill.FillValueUpdate(headValue.fill.value);
                    currentCell.fill.removeFromBoard();
                    currentCell.fill = null;
                    movementTicker++; 
                }
            }

        }
        if ((headValue.GetComponent(typeof(Cell2048)) as Cell2048).right.right != null)
        {
            SlideLeft((headValue.GetComponent(typeof(Cell2048)) as Cell2048).right);
        }
        
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
