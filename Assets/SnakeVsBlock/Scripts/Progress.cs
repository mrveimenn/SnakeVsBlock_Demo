using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    public Player Player;
    public Transform Finish;
    public Slider Slider;
    public float FinishPlayerDisstance = 1f;

    private float _startY;
    private float _currentY;

    private void Start()
    {
        _startY = Player.transform.position.x;
    }

    private void Update()
    {
        _currentY = Mathf.Max(_currentY, Player.transform.position.x);
        float finishY = Finish.position.x;

        float t = Mathf.InverseLerp(_startY, finishY + FinishPlayerDisstance, _currentY);
        Slider.value = t;
    }
}
