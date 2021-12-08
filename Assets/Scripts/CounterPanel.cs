using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterPanel : MonoBehaviour
{
    private bool visible;
    public Vector3 lefttop, xinterval, yinterval;
    public GameObject counterunit;
    public Sprite[] digits; // index->digit: 0-zero, 1-one, 2-two, 3-three, 4-four
    [HideInInspector]
    public CounterUnit[] counterunits;  // id->unit
    private void Awake()
    {
        visible = false;
        SetVisible();
    }
    // Start is called before the first frame update
    void Start()
    {
        //instantiate each unit on the counter panel.
        counterunits = new CounterUnit[DataCenter.DC.EWSNKFZ.Length + DataCenter.DC.FromOneToNine_I.Length + DataCenter.DC.FromOneToNine_II.Length + DataCenter.DC.FromOneToNine_III.Length];
        int i = 0;
        createCounterUnits(ref i, ref DataCenter.DC.EWSNKFZ, lefttop, xinterval);
        createCounterUnits(ref i, ref DataCenter.DC.FromOneToNine_I, lefttop+yinterval, xinterval);
        createCounterUnits(ref i, ref DataCenter.DC.FromOneToNine_II, lefttop+2*yinterval, xinterval);
        createCounterUnits(ref i, ref DataCenter.DC.FromOneToNine_III, lefttop+3*yinterval, xinterval);

    }

    // Update is called once per frame
    void Update()
    {
    }

    void createCounterUnits(ref int curIndex, ref Sprite[] sps, Vector3 startPos, Vector3 interval) {
        GameObject spawnedCounterUnit;
        for(int i = 0; i < sps.Length; i++)
        {
            spawnedCounterUnit = Instantiate(counterunit, startPos + i*interval, Quaternion.identity);
            spawnedCounterUnit.transform.SetParent(gameObject.transform, true);
            //set sprite of card
            spawnedCounterUnit.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = sps[i];
            counterunits[curIndex] = spawnedCounterUnit.GetComponent<CounterUnit>();
            ++curIndex;
        }
    }

    public void ShowOrHidePanel() {
        if (visible)
        {
            visible = false;
        }
        else {
            visible = true;
        }
        BroadcastMessage("SetVisible", visible);
    }

    private void SetVisible() {
        gameObject.GetComponent<Renderer>().enabled = visible;
    }
}
