Shader "Learning/Unlit/MyFirstShader"
{
    Properties
    {
        // NOM_VARIABLE("NOM_AFFICHE_DANS_L'INSPECTOR", Shaderlab type) = defaultValue
        _MainColor("Main Color", Color) = (0.1,0.5,0.3)
    }

        SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert  
            #pragma fragment frag

            #include "UnityCG.cginc"

            float4 _MainColor;
			
			struct vertexInput
            {
                float4 vertex : POSITION;						
            };
			
            struct v2f
            {
                float4 vertex : SV_POSITION;    
            };


            //Vertex Shader
            //Execute pour chaque vertex
            v2f vert (vertexInput v)
            {
                v2f o;
	            o.vertex = mul(UNITY_MATRIX_MVP, v.vertex); //:Etape obligatoire: calcul de la positio du vertex das l'espace
                return o;
            }


            //Fragment / pixel shader
            //Execute pour shaque fragmet/pixel couvert par les polygones

            float4 frag(v2f i) : SV_Target
            {
                return _MainColor;
            }
            
            ENDHLSL
        }
    }
}
