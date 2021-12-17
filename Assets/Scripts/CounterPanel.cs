using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CounterPanel : MonoBehaviour
{
    private char[] typeOfCards;
    private bool visible;
    public Vector3 lefttop, xinterval, yinterval;
    public GameObject counterunit;
    public GameObject virtualKeyBoard;
    public Sprite[] digits; // index->digit: 0-zero, 1-one, 2-two, 3-three, 4-four
    public Sprite[] digits_color;
    [HideInInspector]
    public CounterUnit[] counterunits;  // id->unit

    public delegate void ResetNum(char typeOfCard);
    public static event ResetNum OnResetNum;

    private void Awake()
    {
        //visible = false;
        SetVisible();
        typeOfCards = new char[4];
        for (int i = 0; i < typeOfCards.Length; i++) {
            typeOfCards[i] = (char)('0' + i);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //instantiate each unit on the counter panel.
        counterunits = new CounterUnit[DataCenter.DC.EWSNKFZ.Length + DataCenter.DC.FromOneToNine_I.Length + DataCenter.DC.FromOneToNine_II.Length + DataCenter.DC.FromOneToNine_III.Length];
        int i = 0;
        //createCounterUnits(ref i, ref DataCenter.DC.EWSNKFZ, lefttop, xinterval);
        //createCounterUnits(ref i, ref DataCenter.DC.FromOneToNine_I, lefttop+yinterval, xinterval);
        //createCounterUnits(ref i, ref DataCenter.DC.FromOneToNine_II, lefttop+2*yinterval, xinterval);
        //createCounterUnits(ref i, ref DataCenter.DC.FromOneToNine_III, lefttop+3*yinterval, xinterval);
            createCounterUnits(ref i, ref DataCenter.DC.EWSNKFZ, 0, 3, lefttop + DataCenter.DC.FromOneToNine_I.Length * xinterval + 0.5f * yinterval, xinterval, typeOfCards[0]);
        createCounterUnits(ref i, ref DataCenter.DC.EWSNKFZ, 4, 6, lefttop + DataCenter.DC.FromOneToNine_I.Length * xinterval + 1.5f * yinterval + 0.5f * xinterval, xinterval, typeOfCards[0]);
        createCounterUnits(ref i, ref DataCenter.DC.FromOneToNine_I, lefttop, xinterval, typeOfCards[1]);
        createCounterUnits(ref i, ref DataCenter.DC.FromOneToNine_II, lefttop + yinterval, xinterval, typeOfCards[2]);
        createCounterUnits(ref i, ref DataCenter.DC.FromOneToNine_III, lefttop + 2 * yinterval, xinterval, typeOfCards[3]);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void createCounterUnits(ref int curIndex, ref Sprite[] sps, Vector3 startPos, Vector3 interval, char type)
    {
        GameObject spawnedCounterUnit;
        for (int i = 0; i < sps.Length; i++)
        {
            spawnedCounterUnit = Instantiate(counterunit, startPos + i * interval, Quaternion.identity);
            spawnedCounterUnit.transform.SetParent(gameObject.transform, false);
            //set sprite of card
            //spawnedCounterUnit.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = sps[i];
            spawnedCounterUnit.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = sps[i];
            counterunits[curIndex] = spawnedCounterUnit.GetComponent<CounterUnit>();
            counterunits[curIndex].TypeOfCard = type;
            ++curIndex;
        }
    }

    void createCounterUnits(ref int curIndex, ref Sprite[] sps, int startIndex, int endIndex, Vector3 startPos, Vector3 interval, char type)
    {
        GameObject spawnedCounterUnit;
        int j = 0;
        for (int i = startIndex; i <= endIndex && i < sps.Length; i++)
        {
            spawnedCounterUnit = Instantiate(counterunit, startPos + j * interval, Quaternion.identity);
            spawnedCounterUnit.transform.SetParent(gameObject.transform, false);
            //set sprite of card
            //spawnedCounterUnit.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = sps[i];
            spawnedCounterUnit.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = sps[i];
            //spawnedCounterUnit.transform.parent = GameObject.Find("CounterPanel").transform;
            counterunits[curIndex] = spawnedCounterUnit.GetComponent<CounterUnit>();
            counterunits[curIndex].TypeOfCard = type;
            ++curIndex;
            ++j;
        }
    }

    public void ShowOrHidePanel()
    {
        //if (visible)
        //{
        //    visible = false;
        //}
        //else
        //{
        //    visible = true;
        //}
        //BroadcastMessage("SetVisible", visible);
    }

    private void SetVisible()
    {
        //gameObject.GetComponent<Renderer>().enabled = visible;
    }

    public void ResetEWSNKFZ() {
        OnResetNum(typeOfCards[0]);
    }
    public void ResetFromOneToNine_I()
    {
        OnResetNum(typeOfCards[1]);
    }
    public void ResetFromOneToNine_II()
    {
        OnResetNum(typeOfCards[2]);
    }
    public void ResetFromOneToNine_III()
    {
        OnResetNum(typeOfCards[3]);
    }

    public void SetActiveOrNot() {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else {
            gameObject.SetActive(true);
        }
    }
    public void CreateVirtualKeyBoard(Vector3 position) {
        GameObject _virtualKeyBoard;
        _virtualKeyBoard = Instantiate(virtualKeyBoard);

        _virtualKeyBoard.transform.SetParent(GameObject.Find("Canvas").transform, false);
        Debug.Log("CreateVirtualKeyBoard()");
    }
}
