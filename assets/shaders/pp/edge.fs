#version 330
uniform sampler2D s_texture;
uniform float time;

in vec2 texCoord;

// 0 -1  0
//-1  4 -1
// 0 -1  0

void main()
{
	float offset = 0.002;
    vec4 color = 4 * texture2D(s_texture, texCoord) -
				1 * texture2D(s_texture, texCoord + vec2(offset, 0)) -
				 1 * texture2D(s_texture, texCoord + vec2(-offset, 0)) -
				 1 * texture2D(s_texture, texCoord + vec2(0, offset)) -
				 1 * texture2D(s_texture, texCoord + vec2(0, -offset));

	gl_FragColor = color;
}