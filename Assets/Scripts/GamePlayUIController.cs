using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public void ShowOrHideCounterPanel(Text t) {
        if (counterPanel.activeSelf)
        {
            t.text = "计数器";
            counterPanel.SetActive(false);
        }
        else {
            t.text = "返回";
            counterPanel.SetActive(true);
        }
    }

    public void CreateVirtualKeyBoard() {
        virtualKeyBoard = Instantiate(_virtualKeyBoard);
        virtualKeyBoard.transform.SetParent(gameObject.transform, false);
        _virtualKeyBoard.SetActive(false);
    }

    private void ShowVirtualKeyBoard(NumPanel np) {
        virtualKeyBoard.SetActive(true);
        //Vector3 a = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z))+_offsetFromMouseToKeyBoard;
        
        //a.Set(a.x, a.y, virtualKeyBoard.transform.position.z);

        virtualKeyBoard.transform.position = np.transform.position+_offsetFromMouseToKeyBoard;
        virtualKeyBoard.GetComponent<VirtualKeyBoard>().tarNumPanel = np;
        virtualKeyBoard.GetComponent<VirtualKeyBoard>().inputField.text = np.COUNT.ToString();
    }


}
