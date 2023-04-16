using UnityEngine.UI;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int Amount { get; private set; }
    public Text amountText;
    public Vector3 RotationVelocity;
    public float Speed;

    [SerializeField]
    private int minAmount = 1;
    [SerializeField]
    private int maxAmount = 5;

    private void Start()
    {
        Amount = Random.Range(minAmount, maxAmount);
        amountText.text = Amount.ToString();
    }

    public void Update()
    {
        transform.Rotate(RotationVelocity * Speed);
    }
}
