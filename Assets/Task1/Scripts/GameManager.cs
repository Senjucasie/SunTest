using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action<Client[]> JsonDataLoaded;
    public SunBaseData sunBaseData;
    void Start()
    {
        LoadClientata();
    }

    private async void LoadClientata()
    {
        APIDataLoader dataloader = new APIDataLoader();
        sunBaseData = await dataloader.DeserializeClientData("https://qa2.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data");
        if(sunBaseData != null)
            JsonDataLoaded?.Invoke(sunBaseData.clients);
        
    }

    public Dictionary<int,ClientData> GetClientInfo()
    {
        return sunBaseData.data;
    }

}
