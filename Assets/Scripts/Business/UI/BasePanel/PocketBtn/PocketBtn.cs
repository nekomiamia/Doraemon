using Assets.Scripts.Framework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocketBtn : MonoBehaviour
{

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(BtnClick);
    }

    private void OnDisable()
    {
        GetComponent<Button>().onClick.RemoveListener(BtnClick);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BtnClick()
    {
        EventSingle.Instance.SendEvent(EventDefine.ClickStartBtn);
    }
}
