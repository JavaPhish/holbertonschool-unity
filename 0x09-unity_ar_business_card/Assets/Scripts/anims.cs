using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class anims : MonoBehaviour, ITrackableEventHandler
{
    public Animator twitter_anim;
    public Animator medium_anim;
    public Animator github_anim;
    public Animator linkedin_anim;
    private TrackableBehaviour trackableBehaviour;

    void Start()
    {
        trackableBehaviour = GetComponent<TrackableBehaviour>();
        if (trackableBehaviour)
            trackableBehaviour.RegisterTrackableEventHandler(this);
    }

    public void OnTrackableStateChanged(
      TrackableBehaviour.Status previousStatus,
      TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            OnTrackingFound();

    }

    void OnTrackingFound()
    {
        twitter_anim.Play("Twitter", 0, 0);
        medium_anim.Play("medium", 0, 0);
        linkedin_anim.Play("linkeding", 0, 0);
        github_anim.Play("github_slide", 0, 0);        
    }
}
