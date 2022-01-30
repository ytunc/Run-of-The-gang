using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody),typeof(SphereCollider))]


public class FriendScript : MonoBehaviour
{
    public bool move;
    public Transform startMarker;
    public Transform goToPosition;
    public GameObject parentobject;

    public float speed = 2f;
    private float startTime;
    private float journeyLength;

    public void SetPosition(Transform position, GameObject parentobject)
    {
        this.parentobject = parentobject;
        goToPosition = position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, goToPosition.position);
        move = true;


        StartCoroutine(SetParent());
    }

    void FixedUpdate()
    {
        if (move)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, goToPosition.position, fractionOfJourney);
        }

    }

    public IEnumerator SetParent()
    {
        yield return new WaitForSeconds(1f);

        this.transform.parent = parentobject.transform;
        move = false;
    }
}
