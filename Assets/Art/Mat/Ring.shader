
Shader "ShaderMan/Ring"
	{

	Properties{
	//Properties
	}

	SubShader
	{
	Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }

	Pass
	{
	ZWrite Off
	
	BLENDOP max
	Blend SrcAlpha DstAlpha

	CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag
	#include "UnityCG.cginc"

	struct VertexInput {
    fixed4 vertex : POSITION;
	fixed2 uv:TEXCOORD0;
    fixed4 tangent : TANGENT;
    fixed3 normal : NORMAL;
	//VertexInput
	};


	struct VertexOutput {
	fixed4 pos : SV_POSITION;
	fixed2 uv:TEXCOORD0;
	//VertexOutput
	};

	//Variables

	fixed distCircle(fixed2 uv, fixed2 pos, fixed size) {
    fixed d = length(uv - pos);
    return smoothstep(size, size-0.03, d);
}
fixed edge(fixed2 uv, fixed2 pos, fixed size) {
    uv /= size;
    fixed d = length(uv - pos);
    fixed m = 0.3/d - abs(uv.x * uv.y)*50.;
    m -= d*1.;
    m = clamp(0.,1.,m);
    fixed sub = 0.;
    fixed r = 0.215;
    fixed m1 = distCircle(uv, fixed2(-sub,-sub), r);

    
    return m - m1;
}

fixed3 halo(fixed2 uv) {
    fixed3 col = fixed3(0,0,0);
     col.r += edge(uv, fixed2(0,0), 0.95)*1.1;
     col.g += edge(uv, fixed2(0,0), 1.);
     col.b += edge(uv, fixed2(0,0), 1.05)*0.8;
     return col;
}





	VertexOutput vert (VertexInput v)
	{
	VertexOutput o;
	o.pos = UnityObjectToClipPos (v.vertex);
	o.uv = v.uv;
	//VertexFactory
	return o;
	}
	fixed4 frag(VertexOutput i) : SV_Target
	{
	
    fixed2 uv = i.uv - 0.5;
	uv *= sin(_Time.z*5)*0.1 + 2;
    fixed3 col = fixed3(0,0,0);
    
    col += halo(uv);
    return fixed4(col,1);

	}
	ENDCG
	}
  }
}

