using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAndSpaceController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject _gameObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Wall"))
        {
            _gameObject.SetActive(false);
            playerController.NewAllSphreePosition();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Wall"))
        {
            _gameObject.SetActive(false);
            playerController.NewAllSphreePosition();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Wall"))
        {
            _gameObject.SetActive(true);
            playerController.NewAllSphreePosition();
        }
    }
}
