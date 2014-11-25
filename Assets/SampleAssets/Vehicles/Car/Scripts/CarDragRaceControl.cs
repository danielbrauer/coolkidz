using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;
using UnitySampleAssets.Vehicles.Car;

[RequireComponent(typeof (CarController))]
public class CarDragRaceControl : MonoBehaviour
{
	[SerializeField] private string inputAxis;
    private CarController car; // the car controller we want to use


    private void Awake()
    {
        // get the car controller
        car = GetComponent<CarController>();
    }


    private void FixedUpdate()
    {
		// Vector3 trackPosition = track.InverseTransformPoint(transform.position);
		// float h = -trackPosition.x*correctionStrength;
        // pass the input to the car!
        // float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis(inputAxis);
        car.Move(0f, v);
    }
}