Shader "Custom/BlackScreenSpread" {
	Properties{
		_Color("Main Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex("Base (RGB)", 2D) = "white" {}
	_Radius("ViewRadius", float) = 0.0
	}
		SubShader
	{
		Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag			
#include "UnityCG.cginc"

		fixed4 _Color;
	sampler2D _MainTex;
	float _Radius;

	struct v2f
	{
		float4  pos : SV_POSITION;
		float2  uv : TEXCOORD0;
	};

	v2f vert(appdata_base v)
	{
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.uv = v.texcoord;
		return o;
	}

	float4 frag(v2f i) : COLOR
	{
		float2 centerPoint = float2(_ScreenParams.x / 2, _ScreenParams.y / 2);
		if (distance(i.pos.xy, centerPoint) > _Radius)
		{
			return tex2D(_MainTex, i.uv) * _Color;
		}
		else
		{
			return tex2D(_MainTex, i.uv);
		}
	}
		ENDCG
	}
	}
		FallBack "Diffuse"
}
