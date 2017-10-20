using UnityEngine;
using System;

/// <summary>
/// You can put this class in a separate script.
/// </summary>
public class LevelBoundary
{
	readonly Camera camera;

	public LevelBoundary(Camera camera)
	{
		this.camera = camera;
	}

	public float Bottom
	{
		get { return -ExtentHeight; }
	}

	public float Top
	{
		get { return ExtentHeight; }
	}

	public float Left
	{
		get { return -ExtentWidth; }
	}

	public float Right
	{
		get { return ExtentWidth; }
	}

	public float ExtentHeight
	{
		get { return camera.orthographicSize; }
	}

	public float Height
	{
		get { return ExtentHeight * 2.0f; }
	}

	public float ExtentWidth
	{
		get { return camera.aspect * camera.orthographicSize; }
	}

	public float Width
	{
		get { return ExtentWidth * 2.0f; }
	}
}

public class LevelBoundarySetup : MonoBehaviour
{
	[Serializable]
	public class Boundary
	{
		public Transform transform;
		public float offset;
	}

	/// <summary>
	/// Drag your boundaries here.
	/// </summary>
	[SerializeField]
	public Boundary topBoundary, bottomBoundary, leftBoundary, rightBoundary;

	private LevelBoundary levelBoundary;

	protected virtual void Awake ()
	{
		Camera mainCamera = Camera.main;
		Vector3 cameraPosition = mainCamera.transform.position;

		levelBoundary = new LevelBoundary(mainCamera);

		// Move all the boundaries to each side of the camera.
		topBoundary.transform.position = new Vector2(cameraPosition.x, levelBoundary.Top + topBoundary.transform.localScale.y / 2 + cameraPosition.y + topBoundary.offset);
		bottomBoundary.transform.position = new Vector2(cameraPosition.x, levelBoundary.Bottom - bottomBoundary.transform.localScale.y / 2 + cameraPosition.y + bottomBoundary.offset);
		leftBoundary.transform.position = new Vector2(levelBoundary.Left - leftBoundary.transform.localScale.x / 2 + cameraPosition.x  + leftBoundary.offset, cameraPosition.y);
		rightBoundary.transform.position = new Vector2(levelBoundary.Right + rightBoundary.transform.localScale.x / 2 + cameraPosition.x + rightBoundary.offset, cameraPosition.y );

		// Then scale them with the camera's size.
		topBoundary.transform.localScale = bottomBoundary.transform.localScale = new Vector2(levelBoundary.Width, 1f);
		leftBoundary.transform.localScale = rightBoundary.transform.localScale = new Vector2(1f, levelBoundary.Height);
	}
	public Transform Top()
	{
		return topBoundary.transform;
	}

	public Transform Bottom()
	{
		return bottomBoundary.transform;
	}

	public Transform Left()
	{
		return leftBoundary.transform;
	}

	public Transform Right()
	{
		return rightBoundary.transform;
	}
}