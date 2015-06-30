using UnityEngine;
using System.Collections;

public class E : MonoBehaviour
{
	void OnEnterAllowableDistance( Transform other )
	{
		print("Este objeto entrou no meu raio" + " :: O nome é " + other.name);
	}
	void OnExitAllowableDistance( Transform other )
	{
        print("Este objeto saiu do meu raio" + " :: O nome é " + other.name);
	}
	void OnStayAllowableDistance( Transform other )
	{
        print("Este objeto está dentro do meu raio" + " :: O nome é " + other.name);
	}
}
