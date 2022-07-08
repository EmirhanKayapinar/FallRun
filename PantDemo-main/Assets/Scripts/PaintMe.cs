using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[RequireComponent(typeof(Collider))]
public class PaintMe : MonoBehaviour {

	public Color ClearColour;
	public Material PaintShader;
	public RenderTexture PaintTarget;
	private RenderTexture TempRenderTarget;
	private Material ThisMaterial;
	float _currentTime = 10;
	[SerializeField] GameObject _rankPanel,_paintWallText;
	[SerializeField] Text _rankScreenText, _finalRankText;

	void Init()
	{
		if (ThisMaterial == null)
			ThisMaterial = this.GetComponent<Renderer>().material;

		//	already setup
		if (PaintTarget != null )
			if (ThisMaterial.mainTexture == PaintTarget)
				return;

		//	copy texture
		if (ThisMaterial.mainTexture != null)
		{
			if (PaintTarget == null)
				PaintTarget = new RenderTexture(ThisMaterial.mainTexture.width, ThisMaterial.mainTexture.height, 0);
			Graphics.Blit(ThisMaterial.mainTexture, PaintTarget);
			ThisMaterial.mainTexture = PaintTarget;
		}
		else
		{
			if (PaintTarget == null)
				PaintTarget = new RenderTexture(1024,1024, 0);

			//	clear if no existing texture
			Texture2D ClearTexture = new Texture2D(1, 1);
			ClearTexture.SetPixel(0, 0, ClearColour);
			Graphics.Blit(ClearTexture, PaintTarget);
			ThisMaterial.mainTexture = PaintTarget;

		}
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hitInfo = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		// OnMouseDown
		if (Input.GetMouseButton(0))
		{
			if (Physics.Raycast(ray, out hitInfo))
			{
				hitInfo.collider.SendMessage("HandleClick", hitInfo, SendMessageOptions.DontRequireReceiver);
			}
		}
		
        if (_currentTime<0)
        {
			Debug.Log("Bitti");
			GetComponent<PaintMe>().enabled = false;
			_rankPanel.SetActive(true);
			_finalRankText.text = $"Rank: {_rankScreenText.text }";
		}

		
		

	}

    private void Start()
    {
		_paintWallText.SetActive(true);
    }
    private void FixedUpdate()
    {
		_currentTime -= Time.deltaTime;
		_paintWallText.GetComponent<Text>().text = $"Paint the Wall : {(int)_currentTime}";
	}

	
    void HandleClick(RaycastHit Hit)
	{
		Vector2 LocalHit2 = Hit.textureCoord;
		PaintAt(LocalHit2);
	}


	void PaintAt(Vector2 Uv)
	{
		Init();

		if ( TempRenderTarget == null )
		{
			TempRenderTarget = new RenderTexture(PaintTarget.width, PaintTarget.height, 0);
		}
		PaintShader.SetVector("PaintUv", Uv);
		Graphics.Blit(PaintTarget, TempRenderTarget);
		Graphics.Blit(TempRenderTarget,PaintTarget, PaintShader);
	}
}
