using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [field: SerializeField]
    public List<ClientButton> ClientButtonList
    {
        get;
        private set;
    }
    [SerializeField] private ClientInfoUI _clientinfoUI;
    [SerializeField] private GameManager _gameManager;
    
    private void OnEnable()
    {
        _gameManager.JsonDataLoaded += ShowAllClientButton;
    }
    public void ShowAllClientButton(Client[] clientarray)
    {
        for(int i =0;i<clientarray.Length;i++)
        {
            ClientButtonList[i].SetClientText(clientarray[i]);
        }
    }

    private void OnDisable()
    {
        _gameManager.JsonDataLoaded -= ShowAllClientButton;
    }

    public void FilterClientButton(bool ismanager)
    {
        foreach (ClientButton button in ClientButtonList)
        {
            button.CheckClientButton(ismanager);
        }
    }
    public void ShowAllClientButton()
    {
        foreach (ClientButton button in ClientButtonList)
        {
            button.ToggleButton(true);
        }
    }

    public void ShowClientInfo(int id)
    {
        var clientinfo = _gameManager.GetClientInfo();
        if(clientinfo.ContainsKey(id))
        {
            ClientData clientdata = clientinfo[id];
            _clientinfoUI.ShowClientInfoPanel(clientdata.address, clientdata.points.ToString(), clientdata.name);
        }
    }
}
