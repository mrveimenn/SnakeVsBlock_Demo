using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_V2 : MonoBehaviour
{
    [SerializeField] private List<Transform> _tails;
    [SerializeField] private float _bonesDistance;
    [SerializeField] private GameObject _bonesPrefab;

    [Range(0, 4), SerializeField] private float _moveSpeed;
    [Range(0, 10), SerializeField] private float _rotateSpeed;

    private Vector3 initialPosition;
    private bool isDragging = false;

    private void Update()
    {
        MoveHead(_moveSpeed);
        MoveTail();
        Rotate(_rotateSpeed);
    }

    private void MoveHead(float speed)
    {
        transform.position = transform.position + transform.right * speed * Time.deltaTime;
    }

    private void MoveTail()
    {
        float sqrDistance = Mathf.Sqrt(_bonesDistance);
        Vector3 previousPosition = transform.position;

        foreach (var bone in _tails)
        {
            if ((bone.position + previousPosition).sqrMagnitude > sqrDistance)
            {
                Vector3 currentBonePosition = bone.position;
                bone.position = previousPosition;
                previousPosition = currentBonePosition;
            }
            else
            {
                break;
            }
        }
    }

    private void Rotate(float speed)
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialPosition = Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 currentPosition = Input.mousePosition;
            Vector3 difference = currentPosition - initialPosition;

            transform.position += new Vector3(0, 0, -difference.x * (speed / 10) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Food eat))
        {
            Destroy(other.gameObject);

            GameObject bone = Instantiate(_bonesPrefab);
            _tails.Add(bone.transform);
        }
    }
}
