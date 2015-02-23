Shader "Custom/Add" {
	Properties {
		_MainTex ("Sprite Texture", 2D) = "black" {}
	}
	SubShader {
		 Tags
		{
			"Queue"="Transparent"
			"IgnoreProjector"="True"
			"RenderType"="Transparent"
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}
 
		Cull Off
		Lighting Off
		ZWrite Off
		Fog { Mode Off }
		Blend SrcAlpha One
		
		Pass {
			CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag
				#pragma multi_compile DUMMY PIXELSNAP_ON

				#include "UnityCG.cginc"

				uniform sampler2D _MainTex;
				uniform float4 _Color;	

				struct vertexInput
				{
					float4 vertex : POSITION;
					float4 texcoord : TEXCOORD0;
				};

				struct fragmentInput
				{
					float4 pos : SV_POSITION;
					half2 uv : TEXCOORD0;
				};

				fragmentInput vert (vertexInput i)
				{
					fragmentInput o;
					o.pos = mul(UNITY_MATRIX_MVP, i.vertex);
					o.uv = i.texcoord;

					return o;
				}

				float4 frag (fragmentInput i) : COLOR
				{
					float4 o = float4(1, 0, 0, 1);

					half4 c = tex2D(_MainTex, i.uv);
					o.rgb = c.rgb;

					/*if(c.r < 0.5 && c.g < 0.5 && c.b < 0.5)
						o.a = 0;
					else
						o.a = 0.5;*/

					return o;
				}

			ENDCG
		}
	} 
	FallBack "Diffuse"
}
