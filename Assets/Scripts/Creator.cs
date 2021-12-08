using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    [HideInInspector]
    public LineCardList CardListOwned;


    private GameObject spawnedCard;
    // Start is called before the first frame update


    public delegate void FinishedCreation(string tarName);
    public static event FinishedCreation OnFinishedCreation;
    private void Awake()
    {
        CardListOwned = GameObject.Find(DataCenter.DC.onHand).GetComponent<LineCardList>();
    }


    void Start()
    {
        //Randomly instantiate the first 13 cards to the player at the begging of game
        StartCoroutine("RandomlyInstantiate", 13);
    }

    // Update is called once per frame
    void Update()
    {
        if (CardListOwned.IsEmpty()) {
            StartCoroutine("RandomlyInstantiate", 13);
        }
    }

    //Randomly instantiate k cards for the player
    private IEnumerator RandomlyInstantiate(int k)
    {
        int availableNum = DataCenter.DC.getTotalAvailableNum();
        if (k > availableNum)
        {
            k = availableNum;
        }
        for (int i = 0; i < k; i++)
        {
            //Debug.Log("i: " + i);
            ////randomly get an index
            int randomIndex = Random.Range(0, DataCenter.DC.AVAILABLE.Count);
            //Debug.Log("randomIndex: " + randomIndex);
            //randomly select an ID
            int randomID = DataCenter.DC.AVAILABLE[randomIndex];
           // Debug.Log("randomID: " + randomID + "   counter: " + DataCenter.DC.COUNT_MAP[randomID]);

            //reduce the count of this id, if zero, move to unavailable list
            if (--DataCenter.DC.COUNT_MAP[randomID] == 0)
            {
                DataCenter.DC.AVAILABLE.RemoveAt(randomIndex);
                DataCenter.DC.UNAVAILABLE.Add(randomID);
            }

            //instantiate card;
            spawnedCard = Instantiate(DataCenter.DC.emptyCard);
            spawnedCard.GetComponent<Card>().CardID = randomID;
            spawnedCard.GetComponent<Card>().GroupName = DataCenter.DC.onHand;
            CardListOwned.SetMoveType(Card.flashedMove);
            CardListOwned.allCards.Add(spawnedCard.GetComponent<Card>());
            CardListOwned.NumToShow = i+1;
            yield return new WaitForSeconds(0.4f);
        }
        OnFinishedCreation(DataCenter.DC.onHand);
    }
}
