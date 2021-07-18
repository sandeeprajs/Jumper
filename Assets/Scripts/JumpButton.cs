using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    #region Varibles
    #endregion

    #region Main Methods
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Unity Utilities
    public void OnPointerDown(PointerEventData data)
    {
        Debug.Log("Pointer Down");
        PlayerJump.Instance.SetPower(true);
    }

    public void OnPointerUp(PointerEventData data)
    {
        Debug.Log("Pointer Up");
        PlayerJump.Instance.SetPower(false);
    }
    #endregion
}
