using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HissControl : MonoBehaviour
{

#if UNITY_EDITOR
    public bool TestFire = false;
    public bool TestReload = false;
    //You can have multiple booleans here
    private void OnValidate()
    {
        if (TestFire)
        {
            foreach (Transform child in transform)
            {
                StartCoroutine(FireHissGroup());
            }
        }
        if (TestReload)
        {
            foreach (Transform child in transform)
            {
                StartCoroutine(ResetHissGroup());
            }
        }
    }
#endif

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            foreach (Transform child in transform)
            {
                StartCoroutine(FireHissGroup());
            }
        }
        if (Input.GetButtonDown("Fire2"))
        {
            foreach (Transform child in transform)
            {
                StartCoroutine(ResetHissGroup());
            }
        }
    }



    public IEnumerator FireHissGroup()
    {
        foreach (Transform child in transform)
        {
            yield return new WaitForSeconds(0.1f);
            child.gameObject.GetComponent<HissCube>().Reload = false;
            child.gameObject.GetComponent<HissCube>().Fire = true;
        }
    }

    public IEnumerator ResetHissGroup()
    {
        foreach (Transform child in transform)
        {
            yield return new WaitForSeconds(0.1f);
            child.gameObject.GetComponent<HissCube>().Fire = false;
            child.gameObject.GetComponent<HissCube>().Reload = true;
        }
    }
}
