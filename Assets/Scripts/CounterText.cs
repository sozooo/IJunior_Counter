using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class CounterText : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _counter.CountChanged += ChangeText;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= ChangeText;
    }

    private void ChangeText(float count)
    {
        _text.text = count.ToString();
    }
}
