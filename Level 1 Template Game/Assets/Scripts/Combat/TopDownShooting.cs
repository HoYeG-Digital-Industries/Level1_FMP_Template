using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
  public GameObject bullet;
  public GameObject firePoint;
  float angle;

  // Update is called once per frame
  void Update()
  {
    Debug.Log(angle);
    if(Input.GetButtonDown("Fire1")){
      Shoot();
    }
  }

  void Shoot(){
    GameObject clone = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
    Destroy(clone, 10f);
  }

  void Rotate()
  {
    Vector2 lookDir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
    angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
    
    transform.eulerAngles = new Vector3(0, 0, angle - 90f);
  }
}
