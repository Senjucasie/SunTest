using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_Dropdown))]
public class DropDownUI : MonoBehaviour
{
    private Dictionary<string, bool> _isManager = new();
    [SerializeField]private UIManager _uiManager;
    private TMP_Dropdown  _dropDown;
    private void Awake()
    {
        _isManager.Add("ManagersOnly", true);
        _isManager.Add("NonManagers", false);
        
    }

    private void Start()
    {
        _dropDown = GetComponent<TMP_Dropdown>();
        _dropDown.onValueChanged.AddListener(delegate { DropDownOnClick(_dropDown); });
    }

    void DropDownOnClick(TMP_Dropdown dropdown)
    {
        if(_isManager.ContainsKey(dropdown.options[dropdown.value].text))
        {
            _uiManager.FilterClientButton(_isManager[dropdown.options[dropdown.value].text]);
        }
        else
        {
            _uiManager.ShowAllClientButton();
        }
    }
}
