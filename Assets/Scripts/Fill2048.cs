using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fill2048 : MonoBehaviour
{
    public int value;
    [SerializeField] Text valueDisplay;
    [SerializeField] float speed = 5;
    public Vector3 moveTowards;

    bool hasCombine; 
    public void FillValueUpdate(int valueIn)
    {
        value = valueIn;
        valueDisplay.text = value.ToString();
    }
    public void removeFromBoard()
    {
        Destroy(transform.parent.GetChild(0).gameObject);
    }
    public void removeFromBoard(Cell2048 destinationCell)
    {    
        StartCoroutine(MoveNumber(destinationCell));
    }
    IEnumerator MoveNumber(Cell2048 destinationCell)
    {
        while (Vector3.Distance(transform.position, destinationCell.fill.transform.position) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, destinationCell.fill.transform.position, speed * Time.deltaTime);
            yield return null;
        }
        Destroy(transform.parent.GetChild(0).gameObject);
        //TODO: We need to make it so that the cells don't appear before the cell gets there.
    }
    public void Start()
    {
        moveTowards = transform.localPosition;
    }
    public void Update()
    {
        /*if(transform.localPosition != Vector3.zero)
        {
            hasCombine = false; 
            transform.localPosition = Vector3.MoveTowards(moveTowards, Vector3.zero, speed * Time.deltaTime);
        }
        else if(hasCombine == false)
        {
            if(transform.parent.GetChild(0) != this.transform)
            {
                Destroy(transform.parent.GetChild(0).gameObject);
            }
            hasCombine = true;
        }*/
    }
    public void Double()
    {
        value *= 2;
        valueDisplay.text = value.ToString();
    }
}
