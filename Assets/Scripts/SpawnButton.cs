using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class SpawnButton : MonoBehaviour
{
    public GameObject TestPrefab;
    public ARPlaneManager planeManager;
    ARPlane plane;

    public Button start;

    [SerializeField] Image image;

    public void OnStartClick()
    {
        plane = null;

        foreach (ARPlane aRPlane in planeManager.trackables)
        {
            if (plane == null || plane.size.x <= aRPlane.size.x)
            {
                plane = aRPlane;
            }
        }
        Vector3 scaler = new Vector3(plane.size.x, plane.size.x / 10f, plane.size.x);
        TestPrefab.transform.localScale = scaler;

        Instantiate(TestPrefab, plane.center, Quaternion.identity);

        planeManager.enabled = false;

        foreach (ARPlane aRPlane in planeManager.trackables)
        {
            aRPlane.gameObject.SetActive(false);
        }

        start.gameObject.SetActive(false);
        image.gameObject.SetActive(true);
    }
}