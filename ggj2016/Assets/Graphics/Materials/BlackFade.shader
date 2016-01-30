Shader "Custom/BlackFade" {
	Properties{
		_MainTex("Texture", 2D) = "white" {}
		_Visibility("visibility", float) = 1
	}
	SubShader{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		Cull Off

		CGPROGRAM
		#pragma surface surf Lambert alpha
		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

		sampler2D _MainTex;
		sampler2D _BumpMap;
		float _Visibility;

		void surf(Input IN, inout SurfaceOutput o) {
			o.Albedo = 0;
			o.Alpha = distance(IN.uv_MainTex, float2(0.5, 0.5)) -1 + (_Visibility*2);
		}
		ENDCG
	}
}
