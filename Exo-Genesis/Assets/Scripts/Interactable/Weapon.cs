using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Interactables
{
	public int damage = 30;

	public void UseWeapon(Enemy target)
	{
		if (target != null)
		{
			target.TakeDamage(damage);
		}
		else
		{
			Debug.Log("No target to attack!");
		}
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Enemy enemy = FindObjectOfType<Enemy>();
			UseWeapon(enemy);
		}
	}
}