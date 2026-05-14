using Sandbox;

public sealed class PlayerBike : Component
{
	[Property] public float MoveSpeed { get; set; } = 300f;
	[Property] public float TurnSpeed { get; set; } = 180f;

	protected override void OnFixedUpdate()
	{
		// Turn left/right
		float turnInput = 0f;

		if ( Input.Down( "Left" ) )
			turnInput += 1f;

		if ( Input.Down( "Right" ) )
			turnInput -= 1f;

		WorldRotation *= Rotation.FromYaw( turnInput * TurnSpeed * Time.Delta );

		// Always move forward at constant speed
		WorldPosition += WorldRotation.Forward * MoveSpeed * Time.Delta;
	}
}