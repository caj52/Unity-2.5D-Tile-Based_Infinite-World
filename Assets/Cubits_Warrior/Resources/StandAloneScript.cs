using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandAloneScript : MonoBehaviour {

	public AudioClip clank_sound, jump_sound, attack_01, attack_02, attack_03, step_sound;
	public AudioSource source;
	public GameObject Cubits_Warrior;
	bool has_armor = true;
	public Text Armor_Button_Text;
	public GameObject[] armor_pieces;
	public SkinnedMeshRenderer Body_Mesh;
	public int current_armor, current_body = 0;

	//Hide this to work with WebGL
	//public ProceduralMaterial armor_substance, body_substance;

	public Texture2D[] eyes; 
	public Texture2D[] hairstyles;
	public Texture2D[] shield_emblems;
	public GameObject sword, shield;
	public Animator warrior_animator;
	public JumpScript jump_script_ref;


	public GameObject sword_hand_socket, sword_back_socket, shield_hand_socket, shield_back_socket, shield_cover_socket;

	public Scrollbar my_rotation_scrollbar;

	void Start()
	{
		//Body_Mesh.sharedMaterial.SetTexture ("_MainTex", body_premade_textures [current_body]);
		//sword.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_MainTex", armor_premade_textures[current_armor]);
		//Object[] proceduralMaterialObjects = Resources.LoadAll ("Substances", typeof(ProceduralMaterial));
		my_rotation_scrollbar.value = 0.5f;

		Armor_Button_Text.text = "Remove Armor";
		PutAwayWeapons ();

		//Hide this for WebGL USE
	//	armor_substance = armor_pieces [0].GetComponent<SkinnedMeshRenderer> ().sharedMaterial as ProceduralMaterial;
		//body_substance = Body_Mesh.sharedMaterial as ProceduralMaterial;

		warrior_animator = Cubits_Warrior.GetComponent<Animator> ();
	}

	public void UpdateRotation()
	{
		Cubits_Warrior.transform.rotation = Quaternion.Euler(new Vector3(0, -my_rotation_scrollbar.value * 360, 0));
	}

	public void Armor_On_Off()
	{
		if (has_armor) 
		{
			StartCoroutine (RemoveArmor ());
			has_armor = false;
			Armor_Button_Text.text = "Put Armor On";
		}

		else 
		{
			StartCoroutine (PutOnArmor ());
			has_armor = true;
			Armor_Button_Text.text = "Remove Armor";
		}
	}

	IEnumerator RemoveArmor()
	{
		source.clip = clank_sound;
		foreach (var item in armor_pieces) 
		{
			item.SetActive (false);
			//source.pitch = Random.Range (0.5f, 0.8f);
			source.Play ();
			yield return new WaitForSeconds (0.15f);
			source.Stop ();
		}

		shield.SetActive (true);
		sword.SetActive (true);
	}

	IEnumerator PutOnArmor()
	{
		source.clip = clank_sound;
		foreach (var item in armor_pieces) 
		{
			item.SetActive (true);
			//source.pitch = Random.Range (0.5f, 0.8f);
			source.Play ();
			yield return new WaitForSeconds (0.15f);
			source.Stop ();
		}


	}


	public void RandomizeArmor()
	{
		/*//Armor_Colors
		armor_substance.SetProceduralColor ("_Armor_Color_02", new Color(Random.value, Random.value, Random.value));
		armor_substance.SetProceduralColor ("_Armor_Color_03", new Color(Random.value, Random.value, Random.value));
		armor_substance.SetProceduralColor ("_Armor_Color_04", new Color(Random.value, Random.value, Random.value));

		//Shield Colors
		armor_substance.SetProceduralColor ("_Shield_Color_01", new Color(Random.value, Random.value, Random.value));
		armor_substance.SetProceduralColor ("_Shield_Color_02", new Color(Random.value, Random.value, Random.value));
		armor_substance.SetProceduralColor ("_Shield_Color_03", new Color(Random.value, Random.value, Random.value));
		armor_substance.SetProceduralColor ("_Shield_Emblem_Color_", new Color(Random.value, Random.value, Random.value));

		//SwordColors
		armor_substance.SetProceduralColor ("_Sword_Color_01", new Color(Random.value, Random.value, Random.value));
		armor_substance.SetProceduralColor ("_Sword_Color_02", new Color(Random.value, Random.value, Random.value));
		armor_substance.SetProceduralColor ("_Sword_Color_03", new Color(Random.value, Random.value, Random.value));
		armor_substance.SetProceduralColor ("_Sword_Color_04", new Color(Random.value, Random.value, Random.value));
		armor_substance.SetProceduralColor ("_Sword_Color_05", new Color(Random.value, Random.value, Random.value));

		//Shield Images, Color and Highlights
		armor_substance.SetProceduralTexture ("_Shield_Emblem_", shield_emblems[Random.Range(0, shield_emblems.Length)]);
		armor_substance.SetProceduralFloat("_Hightlight_Strenght_", Random.Range(0f, 1.0f));
		armor_substance.RebuildTextures ();*/

	}

	public void RandomizeBody()
	{
		/*body_substance.SetProceduralColor ("_Skin_Color_", new Color(Random.value, Random.value, Random.value, Random.value));
		body_substance.SetProceduralColor ("_Underwear_Color_", new Color(Random.value, Random.value, Random.value, Random.value));
		body_substance.SetProceduralColor ("_Beard_Color_", new Color(Random.value, Random.value, Random.value, Random.value));
		body_substance.SetProceduralColor ("_Pants_Color_Main_", new Color(Random.value, Random.value, Random.value, Random.value));
		body_substance.SetProceduralColor ("_Pants_Stitching_Color_", new Color(Random.value, Random.value, Random.value, Random.value));
		body_substance.SetProceduralColor ("_Skin_Color_", new Color(Random.value, Random.value, Random.value, Random.value));
		body_substance.SetProceduralColor ("_Shoes_Color_Main_", new Color(Random.value, Random.value, Random.value, Random.value));
		body_substance.SetProceduralColor ("_Shoes_Color_Details_", new Color(Random.value, Random.value, Random.value, Random.value));
		body_substance.SetProceduralColor ("_Shirt_Color_Main_", new Color(Random.value, Random.value, Random.value, Random.value));
		body_substance.SetProceduralColor ("_Shirt_Color_Details_", new Color(Random.value, Random.value, Random.value, Random.value));
		body_substance.SetProceduralColor ("_Vest_Color_Main_", new Color(Random.value, Random.value, Random.value, Random.value));
		body_substance.SetProceduralColor ("_Shirt_Color_Details_", new Color(Random.value, Random.value, Random.value, Random.value));

		body_substance.SetProceduralTexture("_Eyes_", eyes[Random.Range(0, eyes.Length)]);
		body_substance.SetProceduralTexture ("_Hairstyle_", hairstyles [Random.Range (0, hairstyles.Length)]);

		body_substance.RebuildTextures ();*/
	}

	public void PlayAnimation(string animation_name)
	{
		switch (animation_name) 

		{
		case "idle":
			warrior_animator.SetFloat ("speed", 0f);
			PutAwayWeapons ();
			break;

		case "walk":

			warrior_animator.SetFloat ("speed", 0.5f);
			PutAwayWeapons ();
			break;

		case "run":

			warrior_animator.SetFloat ("speed", 1.0f);		
			PutAwayWeapons ();
			break;

		case "attack":
			TakeOutWeapons ();

			int random_attack = Random.Range (0, 3);
			warrior_animator.SetFloat ("speed", 0);
			switch (random_attack) 
			{
			case 0:
				StartCoroutine(PlaySoundWithDelay(0.35f, attack_01));
				warrior_animator.SetTrigger ("attack_1");
				break;

			case 1:
				StartCoroutine(PlaySoundWithDelay(0.2f, attack_02));
				warrior_animator.SetTrigger ("attack_2");
				break;

			case 2:
				StartCoroutine(PlaySoundWithDelay(0.1f, attack_03));
				warrior_animator.SetTrigger ("attack_3");
				break;

			default:
				StartCoroutine(PlaySoundWithDelay(0.35f, attack_01));
				warrior_animator.SetTrigger ("attack_1");
				break;
			}

			break;

		case "ShieldCover":
			TakeOutWeaponsCover ();
			warrior_animator.SetTrigger ("ShieldCover");
			break;


		case "jump":

			if (jump_script_ref.can_jump) 
			{
				source.clip = jump_sound;
				PutAwayWeapons ();
				warrior_animator.SetTrigger ("jump");
				jump_script_ref.Jump ();
				source.Play ();
			}


			break;

		default:
			break;
		}
	}

	public void PutAwayWeapons()
	{
		shield.transform.position = shield_back_socket.transform.position;
		shield.transform.rotation = shield_back_socket.transform.rotation;
		shield.transform.SetParent (shield_back_socket.transform);

		sword.transform.position = sword_back_socket.transform.position;
		sword.transform.rotation = sword_back_socket.transform.rotation;
		sword.transform.SetParent (sword_back_socket.transform);
	}

	public void TakeOutWeapons()
	{
		shield.transform.position = shield_hand_socket.transform.position;
		shield.transform.rotation = shield_hand_socket.transform.rotation;
		shield.transform.SetParent (shield_hand_socket.transform);

		sword.transform.position = sword_hand_socket.transform.position;
		sword.transform.rotation = sword_hand_socket.transform.rotation;
		sword.transform.SetParent (sword_hand_socket.transform);
	}

	public void TakeOutWeaponsCover()
	{
		shield.transform.position = shield_cover_socket.transform.position;
		shield.transform.rotation = shield_cover_socket.transform.rotation;
		shield.transform.SetParent (shield_cover_socket.transform);

		sword.transform.position = sword_hand_socket.transform.position;
		sword.transform.rotation = sword_hand_socket.transform.rotation;
		sword.transform.SetParent (sword_hand_socket.transform);
	}

	public void OpenLink()
	{
		Application.OpenURL ("http://tinyurl.com/cutelowpoly");
	}

	IEnumerator ReturnWeapons(float time_to_wait)
	{
		yield return new WaitForSeconds (time_to_wait);
		PutAwayWeapons ();
	}

	IEnumerator PlaySoundWithDelay(float delay, AudioClip sound)
	{
		source.clip = sound;
		yield return new WaitForSeconds (delay);
		source.Play ();
	}

	public void PlaySteps()
	{
		InvokeRepeating ("PlaySoundStepRoutine", 0, 0.5f);
	}

	public void PlaySoundStepRoutine()
	{
		StartCoroutine (PlaySoundWithDelay (0, step_sound));
	}
}
