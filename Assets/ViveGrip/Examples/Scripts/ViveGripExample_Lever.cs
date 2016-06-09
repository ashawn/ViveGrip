﻿using UnityEngine;
using System.Collections;

public class ViveGripExample_Lever : MonoBehaviour {
  private ViveGrip_ControllerHandler controller;
  private float oldXRotation;
  private float MAX_VIBRATION_STRENGTH = 0.5f;
  private float MAX_VIBRATION_ANGLE = 45f;

  void Start () {
    oldXRotation = transform.eulerAngles.x;
  }

  void ViveGripGrabStart(ViveGrip_GripPoint gripPoint) {
    controller = gripPoint.controller;
  }

  void ViveGripGrabStop() {
    controller = null;
  }

  void Update () {
    float newXRotation = transform.eulerAngles.x;
    if (controller != null) {
      float distance = Mathf.Min(Mathf.Abs(newXRotation - oldXRotation), MAX_VIBRATION_ANGLE);
      float vibrationStrength = (distance / MAX_VIBRATION_ANGLE) * MAX_VIBRATION_STRENGTH;
      controller.Vibrate(50, vibrationStrength);
    }
    oldXRotation = newXRotation;
  }
}
