﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSelectionUIController : MonoBehaviour {
    public GameObject animationTilePrefab;
    public Transform contentPanel;
    public SessionManager sessionManager;

	// Use this for initialization
	void Start () {
        InitAnimationTiles();
	}
	
    private void InitAnimationTiles(){
		List<AnimationClip> animClips = AssetLogger.GetAnimations ();
		for (int i = 0; i < animClips.Count; i++)
        {
            GameObject animTile = Instantiate<GameObject>(animationTilePrefab, contentPanel);
            animTile.GetComponent<AnimationTileController>().animSelUICtrl = this;
			animTile.GetComponent<AnimationTileController>().SetAnimation(animClips[i]);
            animTile.name = "animation tile " + i;
        }
    }

    public void SetSelectedAnimation(AnimationClip animClip){
        Debug.Log("Animation " + animClip.name + " selected.");
        sessionManager.sessionAnim = animClip;
        sessionManager.OnAnimationSelected();
        Destroy(gameObject);
    }
}
