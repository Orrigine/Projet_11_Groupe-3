Shader "Learning/Unlit/Mentalist"
{
    Properties
    {   
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue
        _Albedo0("Gradient Map", 2D) = "white" {}
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
			
            
			struct vertexInput
            {
                float4 vertex : POSITION;
                float2 uv : TEXCCORD0;
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;   
                float2 uv : TEXCCORD0;
            };

            v2f vert (vertexInput v)
            {
                v2f o;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float d = distance(float2(0.5,0.5), i.uv);
                return tex2D(_Albedo0, d + _Speed * _Time.y); 
            }
            
            ENDHLSL
        }
    }
}
