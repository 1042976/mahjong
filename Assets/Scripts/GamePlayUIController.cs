using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUIController : MonoBehaviour
{
    public void ShowOrHideCounterPanel() {
        GameObject panel = GameObject.Find("CounterPanel");
        if (panel.GetComponent<Renderer>().enabled)
        {
            panel.GetComponent<Renderer>().enabled = false;
        }
        else
        {
            panel.GetComponent<Renderer>().enabled = true;
        }
    }
}
