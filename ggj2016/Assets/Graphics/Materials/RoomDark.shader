Shader "Custom/RoomDark" {
	Properties{
		_MainTex("Texture", 2D) = "white" {}
		_Alpha1("AlphaDoor", 2D) = "white" {}
		_DoorPosition("DoorPosition", float) = 0 //0 or 1 for the side of the door which is being opened
		_Visibility("visibility", float) = 1
	}
		SubShader{
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }
		LOD 200
		Cull Off

		CGPROGRAM
		#pragma surface surf Lambert alpha
		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
		};

		sampler2D _MainTex;
		sampler2D _Alpha1;
		float _DoorPosition;
		float _Visibility;

		void surf(Input IN, inout SurfaceOutput o) {
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
			
			float2 mirrorTexCoords = IN.uv_MainTex;
			if(_DoorPosition>0.5f)
				mirrorTexCoords = float2(1-IN.uv_MainTex.x, IN.uv_MainTex.y);

			float alphaDoor = tex2D(_Alpha1, mirrorTexCoords).r;
			float alphaCloud = tex2D(_Alpha1, IN.uv_MainTex).g;

			o.Alpha = (1-(alphaDoor + alphaCloud)) - 1 + (_Visibility * 3);

		}
		ENDCG
	}
}
