using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UniRx;


public class StatusView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _statusText;
    private HealthService _healthService;


    private void Awake()
    {
        _healthService = FindFirstObjectByType<HealthService>();
    }

    private void Start()
    {
        //SubscribeHealthOnly();
        SubscribeHealthArmor();
    }

    private void SubscribeHealthOnly()
    {
        _healthService.Health
            .Subscribe(value =>
            {
                _statusText.text = $"Health: {value}";
            })
            .AddTo(this);
    }

    private void SubscribeHealthArmor()
    {
        _healthService.Health
            .CombineLatest(_healthService.Armor, (hp, ar) => (hp, ar))
            .Subscribe(tuple =>
            {
            var (hp, ar) = tuple;
            _statusText.text = $"HP: {hp} / Armor: {ar}";
            })
            .AddTo(this);
    }
}