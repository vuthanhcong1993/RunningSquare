using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using UnityEngine.Events;

public class PlayerInputHandle : MonoBehaviour {
    public enum ClampType
    {
        None,
        Normalize,
        Direction4,
        ScaledDelta
    }

    // Event signature
    [System.Serializable] public class FingerEvent : UnityEvent<LeanFinger> { }
    [System.Serializable] public class Vector2Event : UnityEvent<Vector2> { }

    [Tooltip("Ignore fingers with StartedOverGui?")]
    public bool IgnoreStartedOverGui = true;

    [Tooltip("Ignore fingers with IsOverGui?")]
    public bool IgnoreIsOverGui;

    [Tooltip("Do nothing if this LeanSelectable isn't selected?")]
    public LeanSelectable RequiredSelectable;

    [Tooltip("Must the swipe be in a specific direction?")]
    public bool CheckAngle;

    [Tooltip("The required angle of the swipe in degrees, where 0 is up, and 90 is right")]
    public float Angle;

    [Tooltip("The left/right tolerance of the swipe angle in degrees")]
    public float AngleThreshold = 90.0f;

    [Tooltip("Should the swipe delta be modified before use?")]
    public ClampType Clamp;

    [Tooltip("The swipe delta multiplier, useful if you're using a Clamp mode")]
    public float Multiplier = 1.0f;

    [Tooltip("How many times must this finger tap before OnTap gets called? (0 = every time) Keep in mind OnTap will only be called once if you use this.")]
    public int RequiredTapCount = 0;

    [Tooltip("How many times repeating must this finger tap before OnTap gets called? (0 = every time) (e.g. a setting of 2 means OnTap will get called when you tap 2 times, 4 times, 6, 8, 10, etc)")]
    public int RequiredTapInterval;

    // Called on the first frame the conditions are met
    public FingerEvent OnSwipe;

    public Vector2Event OnSwipeDelta;
    [HideInInspector] public IPlayerCommand buttonUp, buttonDown, buttonSpace;
    private PlayerController playerController = null;

#if UNITY_EDITOR
    protected virtual void Reset()
    {
        Start();
    }
#endif

    

    protected bool CheckSwipe(LeanFinger finger, Vector2 swipeDelta)
    {
        // Invalid angle?
        if (CheckAngle == true)
        {
            var angle = Mathf.Atan2(swipeDelta.x, swipeDelta.y) * Mathf.Rad2Deg;
            var delta = Mathf.DeltaAngle(angle, Angle);

            if (delta < AngleThreshold * -0.5f || delta >= AngleThreshold * 0.5f)
            {
                return false;
            }
        }

        // Clamp delta?
        switch (Clamp)
        {
            case ClampType.Normalize:
                {
                    swipeDelta = swipeDelta.normalized;
                }
                break;

            case ClampType.Direction4:
                {
                    if (swipeDelta.x < -Mathf.Abs(swipeDelta.y)) swipeDelta = -Vector2.right;
                    if (swipeDelta.x > Mathf.Abs(swipeDelta.y)) swipeDelta = Vector2.right;
                    if (swipeDelta.y < -Mathf.Abs(swipeDelta.x)) swipeDelta = -Vector2.up;
                    if (swipeDelta.y > Mathf.Abs(swipeDelta.x)) swipeDelta = Vector2.up;
                }
                break;

            case ClampType.ScaledDelta:
                {
                    swipeDelta *= LeanTouch.ScalingFactor;
                }
                break;
        }

        // Call event
        if (OnSwipe != null)
        {
            OnSwipe.Invoke(finger);
        }

        if (OnSwipeDelta != null)
        {
            OnSwipeDelta.Invoke(swipeDelta * Multiplier);
        }

        if (Angle == 90 && !playerController.isDead)
        {
            buttonDown.Execute(playerController);
        }
        else if (Angle == 270 && !playerController.isDead)
        {
            buttonUp.Execute(playerController);
        }
        return true;
    }

    protected virtual void OnEnable()
    {
        // Hook events
        LeanTouch.OnFingerSwipe += FingerSwipe;
        LeanTouch.OnFingerTap += FingerTap;
    }

    protected virtual void Start()
    {
        if (RequiredSelectable == null)
        {
            RequiredSelectable = GetComponent<LeanSelectable>();
        }
        buttonUp = transform.parent.parent.GetComponent<ChangeUp>();
        buttonDown = transform.parent.parent.GetComponent<ChangeDown>();
        buttonSpace = transform.parent.parent.GetComponent<ChangeRole>();
        playerController = transform.parent.parent.GetComponent<PlayerController>();
    }

    protected virtual void OnDisable()
    {
        // Unhook events
        LeanTouch.OnFingerSwipe -= FingerSwipe;
        LeanTouch.OnFingerTap -= FingerTap;
    }

    private void FingerSwipe(LeanFinger finger)
    {
        // Ignore?
        if (IgnoreStartedOverGui == true && finger.StartedOverGui == true)
        {
            return;
        }

        if (IgnoreIsOverGui == true && finger.IsOverGui == true)
        {
            return;
        }

        if (RequiredSelectable != null && RequiredSelectable.IsSelected == false)
        {
            return;
        }

        // Perform final swipe check and fire event
        CheckSwipe(finger, finger.SwipeScreenDelta);

    }

    private void FingerTap(LeanFinger finger)
    {
        // Ignore?
        if (IgnoreStartedOverGui == true && finger.StartedOverGui == true)
        {
            return;
        }

        if (IgnoreIsOverGui == true && finger.IsOverGui == true)
        {
            return;
        }

        if (RequiredTapCount > 0 && finger.TapCount != RequiredTapCount)
        {
            return;
        }

        if (RequiredTapInterval > 0 && (finger.TapCount % RequiredTapInterval) != 0)
        {
            return;
        }



        if (RequiredSelectable != null && RequiredSelectable.IsSelected == false)
        {
            return;
        }
        if (Angle==90 && !playerController.isDead)
        {
            buttonSpace.Execute(playerController);
        }
        

    }
}
