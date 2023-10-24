using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(CanvasGroup))]
public class ClientInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _pointsText;
    [SerializeField] private TextMeshProUGUI _addressText;
    [SerializeField] private Button _backButton;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
    _canvasGroup = GetComponent<CanvasGroup>();
    }
    public void  ShowClientInfoPanel(string address,string point,string name)
    {
        
        _nameText.text = name;
        _pointsText.text = point;
        _addressText.text = address;
        
        gameObject.SetActive(true);
        _canvasGroup.DOFade(1, 0.8f);
    }

    public void HideInfoPanel()
    {
        _canvasGroup.DOFade(0, 0.8f);
        StartCoroutine(Delay(0.8f));
    }
    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
