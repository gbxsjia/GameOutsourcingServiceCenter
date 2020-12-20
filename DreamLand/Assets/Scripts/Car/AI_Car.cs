using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Car : AI_Base
{
    public CarBase Car;

    const int FrontRayCount = 5;
    private RayTraceResult[] FrontRayResult;
    private float CheckDegree=30;

    public float TargetSpeed;
    public Vector3 Destiny;

    private void Awake()
    {
        Car = GetComponent<CarBase>();
        FrontRayResult = new RayTraceResult[FrontRayCount];
        for (int i = 0; i < FrontRayCount; i++)
        {
            FrontRayResult[i] = new RayTraceResult();
        }
    }
    private void Start()
    {
        ChangeAction(MoveTo());
    }

    private Coroutine CurrentAction;

    private void ChangeAction(IEnumerator coroutine)
    {
        if (CurrentAction != null)
        {
            StopCoroutine(CurrentAction);
        }
        CurrentAction = StartCoroutine(coroutine);
    }
    private IEnumerator MoveTo()
    {
        Car.SetSteering(0);
        while (Vector3.Distance(transform.position, Destiny) >= 2f)
        {
            FrontRayTrace();
            Vector3 currentVelocity = Car.rb.velocity;
            float currentSpeed = currentVelocity.magnitude;
            if (currentSpeed < TargetSpeed)
            {
                Car.SetMotor(1);
            }
            else
            {
                Car.Brake(0.5f);
            }
            yield return null;
        }
        ChangeAction(Brake());
        print("Arrive");
    }
    private IEnumerator Avoid()
    {
        RayTraceResult SelectResult = null;
        foreach(RayTraceResult result in FrontRayResult)
        {
            if (!result.isHit)
            {
                SelectResult = result;
                break;
            }
        }
        if (SelectResult != null)
        {
            Vector3 outDirection = Quaternion.Euler(0, 0, SelectResult.angle) * transform.up;
            Car.SetSteering(SelectResult.angle);
            while (Vector3.Angle(transform.up, outDirection) >= 3)
            {
                yield return null;
            }
            ChangeAction(MoveTo());
        }
        else
        {
            ChangeAction(Brake());
        }
    }
    private IEnumerator Brake()
    {
        Car.Brake(1);
        while (true)
        {
            yield return null;
        }
    }
    public void SetTargetSpeed(float targetSpeed)
    {
        TargetSpeed = targetSpeed;
    }
    private void FrontRayTrace()
    {
        RaycastHit2D hit;
        float angle = 0;
        for (int i = 0; i < FrontRayCount; i++)
        {
            angle = CheckDegree * (2 * i / (FrontRayCount - 1f) - 1);
            print(angle);
            Debug.DrawLine(Car.frontTracePosition.position, Car.frontTracePosition.position+ Quaternion.Euler(0, 0, angle) * transform.up *5, Color.red, 0.02f);
            hit = Physics2D.Raycast(Car.frontTracePosition.position, Quaternion.Euler(0, 0, angle) * transform.up, 5f);
            FrontRayResult[i].isHit = hit;
            FrontRayResult[i].angle = angle;
            if (hit)
            {
                FrontRayResult[i].hitObject = hit.transform.gameObject;
                FrontRayResult[i].distance = hit.distance;               
            }
        }

        if (FrontRayResult[2].isHit)
        {
            ChangeAction(Avoid());
        }
    }
    [System.Serializable]
    public class RayTraceResult
    {
        public bool isHit;
        public GameObject hitObject;
        public float distance;
        public float angle;
    }
}
