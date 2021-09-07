using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    [Header("Set In Inspector")]
    public GameObject   prefabProjectile;


    [Header("Set Dynamically")]
    public GameObject   launchPoint;
    private Transform   LaunchPointTransform;
    public Vector3      launchPos;
    public GameObject   projectile;
    public bool         aimingMode;

    private void Awake()
    {
        LaunchPointTransform = transform.Find("LaunchPoint");
        launchPoint = LaunchPointTransform.gameObject;
        launchPoint.SetActive(false);

        launchPos = LaunchPointTransform.position;
    }

    private void OnMouseEnter()
    {
        Debug.Log("Mouse Enter");
        launchPoint.SetActive(true);
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse Exit");
        launchPoint.SetActive(false);
    }

    private void OnMouseDown()
    {
        aimingMode = true;

        projectile = Instantiate<GameObject>(prefabProjectile);
        projectile.transform.position = launchPos;

        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }
}
