using UnityEngine;

public class ScaleByVelocity : MonoBehaviour
{

	public float bias = 1f;
	public float strength = 1f;
	public new Rigidbody2D rigidbody;

	private Vector2 startScale;

	private void Start ()
	{
		startScale = transform.localScale;
	}

	private void Update ()
	{
		var velocity = rigidbody.velocity.magnitude;

		if (Mathf.Approximately (velocity, 0f))
			return;

		var amount = velocity * strength + bias;
		var inverseAmount = (1f / amount) * startScale.magnitude;
		transform.localScale = new Vector3 (inverseAmount, amount, 1f);
	}
}