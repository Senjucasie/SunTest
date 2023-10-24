using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ClientButton : MonoBehaviour
{

    [SerializeField]private TextMeshProUGUI ClientText;
    private Client _client;
    private Button _button;
    [SerializeField] private UIManager _uiManager;
    private void Awake()
    {
    _button = GetComponent<Button>();
    _button.onClick.AddListener(OnClick);
    }

    public void SetClientText(Client client)
    {
        _client = client;
        ClientText.text = _client.label;
        ToggleButton(true);
    }

   public void CheckClientButton(bool ismanager)
    {
        if(_client.isManager == ismanager)
        {
            ToggleButton(true);
        }
        else
        {
            ToggleButton(false);
        }
    }

    public void ToggleButton(bool show)
    {
        gameObject.SetActive(show);
    }

    void OnClick()
    {
        _uiManager.ShowClientInfo(_client.id);
    }

}
