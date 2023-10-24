using System.Threading.Tasks;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class APIDataLoader  {
    

    private async Task<string> GetJsonString(string url)
    {
        using (UnityWebRequest webrequest = UnityWebRequest.Get(url))
        {
            await webrequest.SendWebRequest();
    
            if (webrequest.isHttpError || webrequest.isNetworkError)
            {
               
                return null;
            }
            else
            {
               
                return webrequest.downloadHandler.text;
            }
        }
    }

    public async Task<SunBaseData> DeserializeClientData(string url)
    {
        string jsonstring = await GetJsonString(url);
        if(jsonstring==null)
        {
            return null;
        }
        else
        {
    
            return JsonConvert.DeserializeObject<SunBaseData>(jsonstring);
        }
    }

    


}
