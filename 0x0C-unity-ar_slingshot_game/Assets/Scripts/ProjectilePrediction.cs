using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProjectilePrediction : MonoBehaviour
{
    private Scene activeScene;
    private Scene predictionScene;

    private PhysicsScene activePhysicsScene;
    private PhysicsScene predictionPhysicsScene;

    private LineRenderer trajectoryLine;
    private GameObject fakeBall;

    void Start()
    {
        Physics.autoSimulation = false;

        activeScene = SceneManager.GetActiveScene();
        activePhysicsScene = activeScene.GetPhysicsScene();

        CreateSceneParameters parameters = new CreateSceneParameters(LocalPhysicsMode.Physics3D);
        predictionScene = SceneManager.CreateScene("Prediction", parameters);
        predictionPhysicsScene = predictionScene.GetPhysicsScene();

        trajectoryLine = GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
        if (activePhysicsScene.IsValid())
        {
            activePhysicsScene.Simulate(Time.fixedDeltaTime);
        }
    }

    public void PredictTrajectory(GameObject projectile, Vector3 force)
    {
        if (activeScene.IsValid() && predictionScene.IsValid())
        {

            fakeBall = Instantiate(projectile);
            SceneManager.MoveGameObjectToScene(fakeBall, predictionScene);

            fakeBall.transform.position = projectile.transform.position;
            fakeBall.transform.rotation = projectile.transform.rotation;
            fakeBall.GetComponent<Rigidbody>().isKinematic = false;
            fakeBall.GetComponent<Rigidbody>().AddForce(force);
            trajectoryLine.positionCount = 0;
            trajectoryLine.positionCount = 35;

            for (int i = 0; i < 35; i++)
            {
                trajectoryLine.SetPosition(i, fakeBall.transform.position);
                predictionPhysicsScene.Simulate(Time.fixedDeltaTime);
            }

            Destroy(fakeBall);
        }
    }
}
