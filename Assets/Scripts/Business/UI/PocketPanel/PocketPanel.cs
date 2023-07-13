using Assets.Scripts.Framework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketPanel : MonoBehaviour
{
    public GameObject pocketPanel;

    private void OnEnable()
    {
        EventSingle.Instance.AddListener(EventDefine.ClickStartBtn, ShowPocketPanel);
    }

    private void OnDisable()
    {
        EventSingle.Instance.RemoveListener(EventDefine.ClickStartBtn, ShowPocketPanel);
    }

    void ShowPocketPanel()
    {
        pocketPanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
