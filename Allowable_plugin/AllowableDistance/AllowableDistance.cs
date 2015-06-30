using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AllowableDistance: MonoBehaviour
{
	[HideInInspector]
	public float allowableDistance = 1.0f;

	private float currentDistance;
	
	private Transform myTransform;

	private bool isEnter = false;

	private AllowableDistance Distance;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake()
	{
		Distance = GetComponent<AllowableDistance>();
	}

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() 
	{
		this.myTransform = this.transform;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update()
	{
        //<!--Criar um controler de buscar os objeto que tem a Tag player , apenas uma vez, e quando for instanciado outro objeto em cena, este codigo
        // está parte do codigo está gastando processamento desnecessario
		GameObject[] _target = GameObject.FindGameObjectsWithTag("Player");

		if (_target != null) 
		{
			foreach (GameObject target in _target)
			{
				this.currentDistance = Vector3.Distance (target.transform.position, this.myTransform.position);
				
				if (!this.isEnter)
				{
					if (this.currentDistance <= Distance.allowableDistance)
					{
						SendMessage ("OnEnterAllowableDistance", target.transform); 
						
						this.isEnter = true;
					}
				}
				
				if (this.isEnter) 
				{
					if (this.currentDistance <= Distance.allowableDistance)

						SendMessage ("OnStayAllowableDistance", target.transform);
					
					if (this.currentDistance > Distance.allowableDistance) 
					{
						SendMessage ("OnExitAllowableDistance", target.transform); 

						this.isEnter = false;
					}
				}
			}
		}
	}

	/// <summary>
	/// Raises the enter allowable distance event.
	void OnEnterAllowableDistance(Transform other){
        // No implementation
    }
	/// <summary>
	/// Raises the exit allowable distance event.
	void OnExitAllowableDistance(Transform other){
		// No implementation
	}

	/// <summary>
	/// Raises the stay allowable distance event.
	void OnStayAllowableDistance(Transform other){
		// No implementation
	}
}
