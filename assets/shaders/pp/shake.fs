#version 330
uniform sampler2D s_texture;
uniform float time;
uniform float shakiness = 1;
in vec2 texCoord;

void main()
{
	vec4 color = texture2D(s_texture, 
		vec2(0.02, 0.02) + 0.96 * texCoord + 
		0.01 * shakiness * vec2(sin(time*50), 0.5 * cos(time*150)));
	gl_FragColor = color;
}