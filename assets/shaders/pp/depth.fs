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

    depth = LinearizeDepth(depth);
	gl_FragColor = vec4(vec3(depth),1);
}