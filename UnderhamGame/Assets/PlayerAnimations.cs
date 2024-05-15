using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    // Start is called before the first frame update
    public Player_Movment pMov;

    public Animator playerAnimator;
    public AnimationClip currentClip;
    public AnimationClip[] playerAnimations;

    void Start()
    {
        playerAnimator.Play(playerAnimations[0].name);
        currentClip = playerAnimations[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (GameTime.isPaused)
        {
            pMov.mState = Player_Movment.MovingState.idle;
        }
        switch (pMov.mState)
        {
            case Player_Movment.MovingState.idle:
                playerAnimator.Play(playerAnimations[0].name);
                currentClip = playerAnimations[0];
                break;
            case Player_Movment.MovingState.run:
                playerAnimator.Play(playerAnimations[1].name);
                currentClip = playerAnimations[1];
                break;
            case Player_Movment.MovingState.back:
                playerAnimator.Play(playerAnimations[2].name);
                currentClip = playerAnimations[2];
                break;
            case Player_Movment.MovingState.attack:
                playerAnimator.Play(playerAnimations[3].name);
                currentClip = playerAnimations[3];
                break;
            case Player_Movment.MovingState.shoot:
                playerAnimator.Play(playerAnimations[4].name);
                currentClip = playerAnimations[4];
                break;
        }

        


    }
}
