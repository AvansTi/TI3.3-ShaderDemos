#version 330
uniform sampler2D s_texture;
uniform float time;

in vec2 texCoord;

//	0 1 0
//	1 1 1 
//	0 1 0
void main()
{
	float offset = 1/512.0;
    vec4 color = texture2D(s_texture, texCoord + vec2(offset, 0)) +
				 texture2D(s_texture, texCoord + vec2(-offset, 0)) +
				 texture2D(s_texture, texCoord + vec2(0, offset)) +
				 texture2D(s_texture, texCoord + vec2(0, -offset)) +
				 texture2D(s_texture, texCoord);
	color /= 5.0;

	gl_FragColor = color;
}