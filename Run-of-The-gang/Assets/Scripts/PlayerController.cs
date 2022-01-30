using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speedPower;
    [SerializeField] private Vector3 _moveDirection;

    [SerializeField] private VariableJoystick _variableJoystick;
    [SerializeField] private float _joystickSensitivity;

    [SerializeField] private Transform[] _fibonacciArray;
    [SerializeField] private GameObject[] _allObject;
    [SerializeField] private int _count = -1;

    [SerializeField] private bool bollen;


    public void FixedUpdate()
    {
        transform.position += _moveDirection * Time.deltaTime * _speedPower;
        transform.position = new Vector3(transform.position.x +
            (_variableJoystick.Horizontal / 3), transform.position.y,
            this.transform.position.z);

        this.gameObject.transform.eulerAngles =
            new Vector3(0, _variableJoystick.Horizontal * _joystickSensitivity, 0);

        if (bollen)
        {
            NewAllSphreePosition();
            bollen = false;
        }
    }

    public void PointController(bool boolen, int name, Transform _transform)
    {
        if (boolen)
        {
            for (int i = 0; i < _fibonacciArray.Length; i++)
            {
                if (_fibonacciArray[i] == null)
                {
                    _fibonacciArray[name] = _transform.transform;
                }
            }
        }
        else
        {
            _fibonacciArray[name] = null;
        }
    }

    public void NewAllSphreePosition()
    {
        int x = 0;
        for (int i = 0; i < _allObject.Length; i++)
        {
            if (_allObject[i] != null)
            {
                for (int a = i; a < _fibonacciArray.Length; a++)
                {
                    if (_fibonacciArray[i + x] == null)
                    {
                        x++;
                    }
                }

                _allObject[i].gameObject.GetComponent<FriendScript>().SetPosition(
                    _fibonacciArray[i + x].transform, this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Friend"))
        {
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            _count++;
            for (int i = _count; i < _fibonacciArray.Length; i++)
            {
                if (_fibonacciArray[_count] != null)
                {
                    other.gameObject.GetComponent<FriendScript>().SetPosition(
                        _fibonacciArray[_count].transform, this.gameObject);
                }
            }

            for (int a = 0; a < _allObject.Length; a++)
            {
                if (_allObject[a] == null)
                {
                    _allObject[a] = other.gameObject;
                    break;
                }
            }
        }
    }
}
