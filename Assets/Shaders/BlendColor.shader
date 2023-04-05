Shader "Shaders/BlendColor"
{
    Properties
    {   
        _Albedo0("Albedo Map 0", 2D) = "white" {}
        _Albedo1("Albedo Map 1", 2D) = "white" {}
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" }

		Pass
        {
			HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _Albedo0, _Albedo1, _Mask;

			
			struct vertexInput
            {
                float4 vertex : POSITION;		
                float2 uv : TEXCOORD0;		
                float4 worldSpacePos : TEXCOORD1;		
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;    
            };

            v2f vert (vertexInput v)
            {
                v2f o;

	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex)
                o.uv = v.uv;
                o.worldSpacePos = mul(unity_ObjectToWorld, v.vertex)

                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float d = distance(_WorldSpaceCameraPos, i.worldSpacePos);
                float t = clamp(d, 0, 1);
                return lerp(tex2D(_Albedo0, i.uv),
                            tex2D(_Albedo1, i.uv), 
                            t);
            }
            
            ENDHLSL
        }
    }
}
