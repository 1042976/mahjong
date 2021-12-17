using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterUnit : MonoBehaviour
{
    public NumPanel np;
    private char _typeOfCard;
    // Start is called before the first frame update
    private void Awake()
    {
        //SetVisible(false);
        CounterPanelUI.OnResetNum += ResetNum;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseByOne()
    {
        AddCount(1);

    }
    public void DecreaseByOne()
    {
        AddCount(-1);
    }
    public void AddCount(int operand) {
        np.COUNT += operand;
    }

    private void SetVisible(bool visible) {
        foreach (Transform child in transform)
        {
            child.GetComponent<Renderer>().enabled = visible;
        }
        //    transform.GetChild(0).GetComponent<Renderer>().enabled = visible;
        //transform.GetChild(1).GetComponent<Renderer>().enabled = visible;
    }

    public char TypeOfCard {
        get { return _typeOfCard; }
        set { _typeOfCard = value; }
    }

    public void ResetNum(char targetType)
    {
        Debug.Log("ResetNum");
        if (targetType == _typeOfCard) {
            AddCount(4);
        }
    }
}
