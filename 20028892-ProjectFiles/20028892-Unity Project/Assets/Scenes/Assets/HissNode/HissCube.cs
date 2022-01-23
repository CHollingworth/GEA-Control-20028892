using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HissCube : MonoBehaviour
{
    [SerializeField] public Vector3 Direction;
    [SerializeField] public int Distance;
    [SerializeField] public bool Fire = false;
    [SerializeField] public bool Reload = false;


    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    private Vector3 startPoint;
    private Vector3 endPoint;

    private bool temp = false;
    void Update()
    {

        if (Fire)
            {
                if (!temp)
                {
                    startPoint = gameObject.transform.position;
                    endPoint = startPoint + (Direction * Distance);
                    journeyLength = Vector3.Distance(startPoint, endPoint);

                    startTime = Time.time;
                    temp = !temp;
                }
                float distCovered = (Time.time - startTime) * speed;
                float fractionOfJourney = distCovered / journeyLength;
                transform.position = Vector3.Lerp(startPoint, endPoint, fractionOfJourney);
                if (transform.position == endPoint)
                {
                temp = !temp;
                Fire = false;
                Reload = false;
                }
        }

            if (Reload)
            {
                if (!temp)
                {
                    startPoint = gameObject.transform.position;
                    endPoint = startPoint - (Direction * Distance);
                    journeyLength = Vector3.Distance(startPoint, endPoint);

                    startTime = Time.time;
                    temp = !temp;
                }
                float distCovered = (Time.time - startTime) * speed;
                float fractionOfJourney = distCovered / journeyLength;
                transform.position = Vector3.Lerp(startPoint, endPoint, fractionOfJourney);
            if (transform.position == endPoint)
            {
                temp = !temp;
                Fire = false;
                Reload = false;
            }
        }
    }

}
