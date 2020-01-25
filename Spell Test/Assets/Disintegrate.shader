Shader "Disintegrate"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BurnTexutre("Burn", 2D) = "white" {}
        _BurnY("Current Y of the Dissolve effect", Float) = 0
        _BurnSize("Size of the effect", Float) = 2
        _StartingY("Starting point of the effect", float) = -10
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldPos: TEXCORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _BurnTexture;
            float _BurnY;
            float _BurnSize;
            float _StartingY;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                clip(-1);
                return col;
            }
            ENDCG
        }
    }
}
