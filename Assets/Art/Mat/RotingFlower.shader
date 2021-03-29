
Shader "ShaderMan/RotingFlower"
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
	Blend SrcAlpha OneMinusSrcAlpha

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

	fixed shine_f(){
    fixed x = _Time.y * 2.;
    return pow(sin(x/5.)*sin(x/2.)*sin(2.*x), 2.) + .2;
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
	
    fixed2 p = i.uv/1;
    fixed2 q = p - fixed2(.5, .5);
	q.x += 0.5;
	q /= 3;
    q.x *= 1 / 1;

    fixed3 sky = fixed3(7./255., 18./255., 27./255.);    
    fixed3 shine = fixed3(119./255., 199./255., 242./255.);

    fixed curve = 1.;
    curve = exp(length(q) * 5.) - 1.3;
    curve *= shine_f();
    curve *= 6.;
    curve += cos((atan2( q.y,q.x) + _Time.y * 2.) * 6.) * .3; 
    shine = lerp(fixed3(1.,1.,1.), shine, curve);
	shine = frac(shine);
	shine += 0.5f;

    return fixed4(shine, 0.3);

	}
	ENDCG
	}
  }
}

