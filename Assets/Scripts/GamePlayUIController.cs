using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayUIController : MonoBehaviour
{
    public GameObject counterPanel;
    public GameObject _virtualKeyBoard;
    public Vector3 _offsetFromMouseToKeyBoard;
    private GameObject virtualKeyBoard;
    private void Awake()
    {
        CreateVirtualKeyBoard();
        NumPanel.OnShowVirtualPKeyBoard += ShowVirtualKeyBoard;
    }
    public void ShowOrHideCounterPanel() {
        GameObject panel = GameObject.Find("CounterPanel");
        if (panel.activeSelf)
        {
            panel.SetActive(false);
        }
        else {
            panel.SetActive(true);
        }
        
        //if (panel.GetComponent<Renderer>().enabled)
        //{
        //    panel.GetComponent<Renderer>().enabled = false;
        //}
        //else
        //{
        //    panel.GetComponent<Renderer>().enabled = true;
        //}
    }

    public void CreateVirtualKeyBoard() {
        virtualKeyBoard = Instantiate(_virtualKeyBoard);
        virtualKeyBoard.transform.SetParent(gameObject.transform, false);
        _virtualKeyBoard.SetActive(false);
    }

    private void ShowVirtualKeyBoard(Vector3 tarPos) {
        virtualKeyBoard.SetActive(true);
        //Vector3 a = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z))+_offsetFromMouseToKeyBoard;
        
        //a.Set(a.x, a.y, virtualKeyBoard.transform.position.z);

        virtualKeyBoard.transform.position = tarPos+_offsetFromMouseToKeyBoard;
    }
}
