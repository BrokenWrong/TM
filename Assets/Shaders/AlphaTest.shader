// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/AlphaTest" {
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
	_Mask("Base (RGB)", 2D) = "white" {}			//遮罩图
	_AreaMask("AreaMask", Color) = (1,0,0,0)		//区块显隐配置（可完全显示的），按 r g b位运算，最多24块区域

		_AlphaVal("AlphaVal", Range(0,5)) = 1.0			//控制动态显示的变化值，乘以 mask.color.a， 让其从强到弱慢慢显示出来
		_AnimAreaMask("AnimAreaMask", Color) = (1,0,0,0)	//当前要随AlphaVal变化而显示变化过程的区块配置，按 r g b位运算，最多24块区域
		_AlphaThreshold("AlphaThreshold",float) = 0.4 //mask的alpha乘以AlphaVal后 显隐阈值，不到则不显示



		_Color("Tint", Color) = (1,1,1,1)
		_StencilComp("Stencil Comparison", Float) = 8
		_Stencil("Stencil ID", Float) = 0
		_StencilOp("Stencil Operation", Float) = 0
		_StencilWriteMask("Stencil Write Mask", Float) = 255
		_StencilReadMask("Stencil Read Mask", Float) = 255
		_ColorMask("Color Mask", Float) = 15
		[Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip("Use Alpha Clip", Float) = 0
	}

		SubShader
	{
		Tags
	{
		"Queue" = "Transparent"
		"IgnoreProjector" = "True"
		"RenderType" = "Transparent"
		"PreviewType" = "Plane"
		"CanUseSpriteAtlas" = "True"
	}

		Stencil
	{
		Ref[_Stencil]
		Comp[_StencilComp]
		Pass[_StencilOp]
		ReadMask[_StencilReadMask]
		WriteMask[_StencilWriteMask]
	}

		Cull Off
		Lighting Off
		ZWrite Off
		ZTest[unity_GUIZTestMode]
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMask[_ColorMask]

		Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"
#include "UnityUI.cginc"

#pragma multi_compile __ UNITY_UI_ALPHACLIP

		struct a2v
	{
		fixed2 uv : TEXCOORD0;
		half4 vertex : POSITION;
		float4 color    : COLOR;
	};


	struct v2f
	{
		fixed2 uv : TEXCOORD0;
		half4 vertex : SV_POSITION;
		float4 color    : COLOR;
	};

	sampler2D _MainTex;
	sampler2D _Mask;

	float _AlphaVal;

	fixed4 _Color;
	fixed4 _AreaMask;
	fixed4 _AnimAreaMask;
	float _AlphaThreshold;

	v2f vert(a2v i)
	{
		v2f o;
		o.vertex = UnityObjectToClipPos(i.vertex);
		o.uv = i.uv;

		o.color = i.color * _Color;
		return o;
	}

	fixed4 frag(v2f i) : COLOR
	{
		half4 color = tex2D(_MainTex, i.uv) * i.color;
		half4 mask = tex2D(_Mask, i.uv);
		//color.a *= mask.a;  //原半透明遮罩算法

		int maskr = round(mask.r * 255.0);
		int maskg = round(mask.g * 255.0);
		int maskb = round(mask.b * 255.0);
		int t = ((int)round(_AreaMask.r * 255.0) & maskr)
			| ((int)round(_AreaMask.g * 255.0) & maskg)
			| ((int)round(_AreaMask.b * 255.0) & maskb); //mask 和 配置的颜色块进行位运算，> 0表示符合开启条件
		int t2 = ((int)round(_AnimAreaMask.r * 255.0) & maskr)
			| ((int)round(_AnimAreaMask.g * 255.0) & maskg)
			| ((int)round(_AnimAreaMask.b * 255.0) & maskb); //mask 和 配置的颜色块进行位运算，> 0表示符合开启条件
		float ma = mask.a * _AlphaVal;
		color.a *= step(1, t)*mask.a * 5 + step(1, t2) * ((ma - _AlphaThreshold) * 5 * step(_AlphaThreshold, ma));
		/* 上面的算式相当于下面的逻辑判断
		if(t > 0)
		{
		color.a *= mask.a*5;	//显示这个区域 (或者 mask.a==0时不显示）
		}
		else if(t2 > 0)				//逐渐显示的区域
		{
		if (ma > _AlphaThreshold)	//超过阈值才显示
		{
		color.a *= (ma - _AlphaThreshold) * 5;  //color.a *= ma 边缘会有明显轮廓，改进了一下算法，让边缘柔和些。5可以随便调整一下
		}
		else
		{
		color.a = 0;
		}
		}
		else
		{
		color.a = 0;
		} */

		return color;
	}
		ENDCG
	}
	}
}
