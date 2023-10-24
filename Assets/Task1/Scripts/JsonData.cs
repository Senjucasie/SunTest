using System;
using System.Collections.Generic;

public class SunBaseData
{
    public Client[] clients;
    public Dictionary<int, ClientData> data;
    public string label;
}

[Serializable]
public class Client
{
    public bool isManager;
    public int id;
    public string label;
}

[Serializable]
public class ClientData
{
    public string address;
    public string name;
    public int points;
}

