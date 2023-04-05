Shader "Learning/Unlit/TO RENAME"
{
    Properties
    {   
        _Albedo0("Albedo Map 0", 2D) = "white" {}
        _Albedo1("Albedo Map 1", 2D) = "white" {}
        _Mask("Opacity Map", 2D) = "white" {}
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
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;    
            };

            v2f vert (vertexInput v)
            {
                v2f o;
	            o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                return lerp(tex2D(_Albedo0, i.uv),
                            tex2D(_Albedo1, i.uv), 
                            tex2D(_Mask, i.uv).r);
            }
            
            ENDHLSL
        }
    }
}
