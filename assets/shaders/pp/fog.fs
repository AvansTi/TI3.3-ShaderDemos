#version 330
uniform sampler2D s_texture;
uniform sampler2D s_depth;
uniform float time;

in vec2 texCoord;

float LinearizeDepth(float z)
{
  float n = 0.01; // camera z near
  float f = 30.0; // camera z far
  return (2.0 * n) / (f + n - z * (f - n));	
}

void main()
{
	float depth = texture2D(s_depth, texCoord).x;
	vec4 color = texture2D(s_texture, texCoord);
    
    depth = LinearizeDepth(depth);
    depth = smoothstep(0, .75, depth);


    color = mix(color, vec4(.5,.5,.5,1), pow(depth,.7));


	gl_FragColor = color;
}