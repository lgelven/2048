using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2048old : MonoBehaviour
{
    public Cell2048old right;
    public Cell2048old down;
    public Cell2048old left;
    public Cell2048old up;

    public Fill2048 fill;
    // Start is called before the first frame update
    private void OnEnable()
    {
        GameController2048old.slide += OnSlide;
    }
    private void OnDisable()
    {
        GameController2048old.slide -= OnSlide;
    }
    private void OnSlide(string whatWasSent)
    {
        Debug.Log(whatWasSent);
        if (whatWasSent == "w")
        {
            if (up != null)
                return;
            Cell2048old currentCell = this;
            SlideUp(currentCell);

        }
        if (whatWasSent == "d")
        {
            if (right != null)
                return;
            Cell2048old currentCell = this;
            SlideRight(currentCell);
        }
        if (whatWasSent == "s")
        {
            if (down != null)
                return;
            Cell2048old currentCell = this;
            SlideDown(currentCell);
        }
        if (whatWasSent == "a")
        {
            if (left != null)
                return;
            Cell2048old currentCell = this;
            SlideLeft(currentCell);
        }
        GameController2048old.ticker++;
        if(GameController2048old.ticker == 4)
        {
            GameController2048old.instance.SpawnFill();
        }
    }
        void SlideUp(Cell2048old currentCell)
        {
            if (currentCell.down == null)
                return;
            //Debug.Log(currentCell.gameObject);
            if (currentCell.fill != null)
            {
                Cell2048old nextCell = currentCell.down;
                while (nextCell.down != null && nextCell.fill == null)
                {
                    nextCell = nextCell.down;
                }
                if (nextCell.fill != null)
                {
                    if (currentCell.fill.value == nextCell.fill.value)
                    {
                        nextCell.fill.Double();
                        nextCell.fill.transform.parent = currentCell.transform;
                        currentCell.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if(currentCell.down.fill != nextCell.fill)
                    {
                        Debug.Log("!doubled");
                        nextCell.fill.transform.parent = currentCell.down.transform;
                        currentCell.down.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                }
            }
            else
            {
                Cell2048old nextCell = currentCell.down;
                while (nextCell.down != null && nextCell.fill == null)
                {
                    nextCell = nextCell.down;
                }
                if (nextCell.fill != null)
                {
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                    SlideUp(currentCell);
                    Debug.Log("Slide to Empty");
                }
                if (currentCell.down == null)
                    return;
                SlideUp(currentCell.down);
            }
        }

        void SlideRight(Cell2048old currentCell)
        {
            if (currentCell.left == null)
                return;
            Debug.Log(currentCell.gameObject);
            if (currentCell.fill != null)
            {
                Cell2048old nextCell = currentCell.left;
                while (nextCell.left != null && nextCell.fill == null)
                {
                    nextCell = nextCell.left;
                }
                if (nextCell.fill != null)
                {
                    if (currentCell.fill.value == nextCell.fill.value)
                    {
                        nextCell.fill.Double();
                        nextCell.fill.transform.parent = currentCell.transform;
                        currentCell.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if (currentCell.left.fill != nextCell.fill)
                    {
                        Debug.Log("!doubled");
                        nextCell.fill.transform.parent = currentCell.left.transform;
                        currentCell.left.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                }
            }
            else
            {
                Cell2048old nextCell = currentCell.left;
                while (nextCell.left != null && nextCell.fill == null)
                {
                    nextCell = nextCell.left;
                }
                if (nextCell.fill != null)
                {
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                    SlideRight(currentCell);
                    Debug.Log("Slide to Empty");
                }
                if (currentCell.left == null)
                    return;
                SlideRight(currentCell.left);
            }
        }
        void SlideDown(Cell2048old currentCell)
        {
            if (currentCell.up == null)
                return;
            Debug.Log(currentCell.gameObject);
            if (currentCell.fill != null)
            {
                Cell2048old nextCell = currentCell.up;
                while (nextCell.up != null && nextCell.fill == null)
                {
                    nextCell = nextCell.up;
                }
                if (nextCell.fill != null)
                {
                    if (currentCell.fill.value == nextCell.fill.value)
                    {
                        nextCell.fill.Double();
                        nextCell.fill.transform.parent = currentCell.transform;
                        currentCell.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if (currentCell.up.fill != nextCell.fill)
                    {
                        Debug.Log("!doubled");
                        nextCell.fill.transform.parent = currentCell.up.transform;
                        currentCell.up.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                }
            }
            else
            {
                Cell2048old nextCell = currentCell.up;
                while (nextCell.up != null && nextCell.fill == null)
                {
                    nextCell = nextCell.up;
                }
                if (nextCell.fill != null)
                {
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                    SlideDown(currentCell);
                    Debug.Log("Slide to Empty");
                }
                if (currentCell.up == null)
                    return;
                SlideDown(currentCell.up);
            }
        }
        void SlideLeft(Cell2048old currentCell)
        {
            if (currentCell.right == null)
                return;
            Debug.Log(currentCell.gameObject);
            if (currentCell.fill != null)
            {
                Cell2048old nextCell = currentCell.right;
                while (nextCell.right != null && nextCell.fill == null)
                {
                    nextCell = nextCell.right;
                }
                if (nextCell.fill != null)
                {
                    if (currentCell.fill.value == nextCell.fill.value)
                    {
                        nextCell.fill.Double();
                        nextCell.fill.transform.parent = currentCell.transform;
                        currentCell.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                    else if (currentCell.right.fill != nextCell.fill)
                    {
                        Debug.Log("!doubled");
                        nextCell.fill.transform.parent = currentCell.right.transform;
                        currentCell.right.fill = nextCell.fill;
                        nextCell.fill = null;
                    }
                }
            }
            else
            {
                Cell2048old nextCell = currentCell.right;
                while (nextCell.right != null && nextCell.fill == null)
                {
                    nextCell = nextCell.right;
                }
                if (nextCell.fill != null)
                {
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                    SlideLeft(currentCell);
                    Debug.Log("Slide to Empty");
                }
                if (currentCell.right == null)
                    return;
                SlideLeft(currentCell.right);
            }
        }
} 
