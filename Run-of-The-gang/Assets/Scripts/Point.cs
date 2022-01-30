using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private GameObject _object;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        _boxCollider = GetComponent<BoxCollider>();

    }
    private void Start()
    {

        StartCoroutine(Controller());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Area"))
        {
            _object = other.gameObject;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Area"))
        {
            _object = other.gameObject;
        }
    }

    public IEnumerator Controller()
    {
        if (_object != null)
        {
            string _name = this.gameObject.name.ToString();
            if (_object.activeInHierarchy)
            {
                playerController.PointController(true, int.Parse(_name.ToString()),
                    this.gameObject.transform);
            }
            if (!_object.activeInHierarchy)
            {
                playerController.PointController(false,int.Parse(_name.ToString()),null);
            }
        }
        yield return new WaitForSeconds(.5f);
        StartCoroutine(Controller());
    }

}
