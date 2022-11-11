using TMPro;
using UnityEngine;

public class Display : MonoBehaviour
{
    [SerializeField] private GameObject _source;
    
    void Update()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = "Number:" + _source.GetComponent<Source>().Number;
    }
}
