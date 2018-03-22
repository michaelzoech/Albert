Shader "Unlit/GoalShader"
{
	Properties
	{
		_Animate ("Animate", Float) = 0.0
	}
	SubShader
	{
		Tags { "Queue" = "Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
		LOD 100

		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
			ZWrite Off

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			float _Animate;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float2 d = abs(i.uv - float2(0.5, 0.5));
				float t = _Animate > 0.0 ? abs(frac(_SinTime.w / 2) - 0.5) : 0.0;
				float len = 1.0 - clamp(sqrt(d.x*d.x + d.y*d.y) + t, 0.0, 0.5) * 2;
				fixed4 col = fixed4(0.8, 0.7, 0.15, 1.0) * len;
				return col;
			}
			ENDCG
		}
	}
}
