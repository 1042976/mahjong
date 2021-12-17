using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterUnit : MonoBehaviour
{
    private int _count;
    private char _typeOfCard;
    // Start is called before the first frame update
    private void Awake()
    {
        //SetVisible(false);
        CounterPanelUI.OnResetNum += ResetNum;
    }
    void Start()
    {
        _count = DataCenter.DC.numOfCards;
        BroadcastMessage("SetCount", _count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseByOne()
    {
        AddCount(1);
        BroadcastMessage("SetCount", _count);
    }
    public void DecreaseByOne()
    {
        Debug.Log("DecreaseByOne()");
        AddCount(-1);
        BroadcastMessage("SetCount", _count);
    }
    public void AddCount(int operand) {
        _count += operand;
        if (_count < 0)
        {
            _count = 0;
        }
        else if (_count > 4) {
            _count = 4;
        }
        BroadcastMessage("SetCount", _count);
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
