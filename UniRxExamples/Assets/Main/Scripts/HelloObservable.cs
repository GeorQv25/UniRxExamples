using UniRx;
using UnityEngine;


public class HelloObservable : MonoBehaviour
{
    private void Start()
    {
        // ������ ���� ����� ���������� ������ � � ������� ����� Log
        Observable
            .EveryUpdate()
            .Subscribe(_ => Debug.Log("Hello, UniRx! frame: " + Time.frameCount))
            .AddTo(this);   // ������������� ������������ ��� ����������� �������
    }
}
