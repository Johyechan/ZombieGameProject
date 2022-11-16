using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : ControllScene
{
	[SerializeField] MenuButtonController menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorFunctions animatorFunctions;
	[SerializeField] int thisIndex;
	public GameObject selectarrow;
	public string name;

    // Update is called once per frame
    void Update()
    {
		if(menuButtonController.index == thisIndex)
		{
			animator.SetBool ("selected", true);
			selectarrow.SetActive (true);
			if(Input.GetAxis ("Submit") == 1){
				animator.SetBool ("pressed", true);
				if (name == "StartGame")
					GoMain();
				if(name == "Setting")
					SettingPanUp();
				if (name == "Extra")
					OthersPanUp();
				if (name == "Quit")
					ExitGame();

			}else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;
			}
		}else{
			selectarrow.SetActive (false);
			animator.SetBool ("selected", false);
			animator.SetBool("pressed", false);
		}
    }
}
