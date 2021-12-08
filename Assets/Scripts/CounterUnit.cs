using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterUnit : MonoBehaviour
{
    private int _count;
    // Start is called before the first frame update
    private void Awake()
    {
        SetVisible(false);
    }
    void Start()
    {
        _count = DataCenter.DC.numOfCards;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCount(int operand) {
        _count += operand;
        Debug.Log("_count: " + _count);
        transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = GameObject.Find("CounterPanel").GetComponent<CounterPanel>().digits[_count];
    }

    private void SetVisible(bool visible) {
        transform.GetChild(0).GetComponent<Renderer>().enabled = visible;
        transform.GetChild(1).GetComponent<Renderer>().enabled = visible;
    }

    
}
