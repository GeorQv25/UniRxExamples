using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UniRx;


public class HealthView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private Slider _healthSlider;
    private HealthService _healthService;


    private void Awake()
    {
        _healthService = FindFirstObjectByType<HealthService>();
    }

    private void Start()
    {
        // ������������� �� ��������� Health � ����� ��������� UI
        _healthService.Health
            .Subscribe(value =>
            {
                _healthText.text = $"Health: {value}";
                _healthSlider.value = value;
            })
            .AddTo(this);  // ������� ��� ����������� �������
    }
}